using AutoMapper;
using ECom.Services.Billing.Constant;
using ECom.Services.Billing.Data;
using ECom.Services.Billing.Services;
using ECom.Services.Sales.Utility;
using Messages;
using Messages.ReceiptMessages;
using Microsoft.Extensions.Configuration;
using NServiceBus.Logging;

namespace ECom.Services.Billing.Handler
{
    public class PaymentHandler : IHandleMessages<CreateVNPayUrl>, IHandleMessages<ValidateReceiptPayment>
    {
        IConfiguration configuration;
        private readonly ILog log = LogManager.GetLogger(typeof(PaymentHandler));
        VnPayService payService;
        private IMapper mapper;
        public PaymentHandler()
        {
            configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            payService = new VnPayService();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }
        public async Task Handle(CreateVNPayUrl message, IMessageHandlerContext context)
        {
            var response = new Response<string>();

            // GET ALL VNPAY CONFIG VARIABLE

            string apiURL = configuration["VNPay:ApiURL"];
            string version = configuration["VNPay:Version"];
            string command = configuration["VNPay:Command"];
            string tmnCode = configuration["VNPay:TmnCode"];
            string hashSecret = configuration["VNPay:HashSecret"];
            string bankCode = configuration["VNPay:BankCode"];
            string currCode = configuration["VNPay:CurrCode"];
            string locale = configuration["VNPay:Locale"];
            string orderType = configuration["VNPay:OrderType"];
            string returnUrl = configuration["VNPay:ReturnUrl"].ToString() + message.OrderId;
            string defaultOrderInfor = configuration["VNPay:DefaultOrderInfor"];

            payService.AddRequestData("vnp_Version", version);
            payService.AddRequestData("vnp_Command", command);
            payService.AddRequestData("vnp_TmnCode", tmnCode);
            payService.AddRequestData("vnp_Amount", (message.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            payService.AddRequestData("vnp_CreateDate", message.CreateDate.ToString());
            payService.AddRequestData("vnp_CurrCode", currCode);
            payService.AddRequestData("vnp_IpAddr", "127.0.0.1");
            payService.AddRequestData("vnp_Locale", locale);
            payService.AddRequestData("vnp_OrderInfo", defaultOrderInfor + message.TxnRef);
            payService.AddRequestData("vnp_OrderType", orderType); //default value: other
            payService.AddRequestData("vnp_ReturnUrl", returnUrl);
            payService.AddRequestData("vnp_TxnRef", message.TxnRef.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            string paymentUrl = payService.CreateRequestUrl(apiURL, hashSecret);

            log.InfoFormat("VNPAY URL: {0}", paymentUrl);

            response.responseData = new List<string>() { paymentUrl };
            response.ErrorCode = 200;

            await context.Reply(response);
        }

        public async Task Handle(ValidateReceiptPayment message, IMessageHandlerContext context)
        {
            var response = new Response<string>();

            payService.AddResponseData("vnp_Amount", message.vnp_Amount.ToString());
            payService.AddResponseData("vnp_BankCode", message.vnp_BankCode);
            payService.AddResponseData("vnp_BankTranNo", message.vnp_BankTranNo);
            payService.AddResponseData("vnp_CardType", message.vnp_CardType);
            payService.AddResponseData("vnp_OrderInfo", message.vnp_OrderInfo);
            payService.AddResponseData("vnp_PayDate", message.vnp_PayDate);
            payService.AddResponseData("vnp_ResponseCode", message.vnp_ResponseCode);
            payService.AddResponseData("vnp_TmnCode", message.vnp_TmnCode);
            payService.AddResponseData("vnp_TransactionNo", message.vnp_TransactionNo.ToString());
            payService.AddResponseData("vnp_TransactionStatus", message.vnp_TransactionStatus);
            payService.AddResponseData("vnp_TxnRef", message.vnp_TxnRef.ToString());

            string hashSecret = configuration["VNPay:HashSecret"];
            log.Info("hashSecret: " + hashSecret);
            bool isValid = payService.ValidateSignature(message.vnp_SecureHash, hashSecret);
            log.Info("is Valid: " + isValid);

            if (isValid)
            {
                var receipt = DataAccess.Ins.DB.Receipts.First(ele => ele.Id == message.vnp_TxnRef);

                if (receipt != null)
                {
                    receipt.Status = (char)ReceiptStatus.PAID;
                    DataAccess.Ins.DB.SaveChanges();
                    response.ErrorCode = 200;
                }
                else
                {
                    response.ErrorCode = 404;
                }
            }
            else
            {
                response.ErrorCode = 400;
            }

            await context.Reply(response);
        }
    }
}
