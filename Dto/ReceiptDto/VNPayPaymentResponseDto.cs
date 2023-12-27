namespace Dto.ReceiptDto
{
    public class VNPayPaymentResponseDto
    {
        //vnp_TxnRef: Ma don hang merchant gui VNPAY tai command=pay    
        //vnp_TransactionNo: Ma GD tai he thong VNPAY
        //vnp_ResponseCode:Response code from VNPAY: 00: Thanh cong, Khac 00: Xem tai lieu
        //vnp_SecureHash: HmacSHA512 cua du lieu tra ve

        public int vnp_Amount { get; set; }
        public string vnp_BankCode { get; set; }
        public string vnp_BankTranNo { get; set; }
        public string vnp_CardType { get; set; }
        public string vnp_OrderInfo { get; set; }
        public string vnp_TmnCode { get; set; }
        public string vnp_PayDate { get; set; }
        public int vnp_TxnRef { get; set; }
        public string vnp_TransactionStatus { get; set; }
        public int vnp_TransactionNo { get; set; }
        public string vnp_ResponseCode { get; set; } = "";
        public string vnp_SecureHash { get; set; }
    }
}
