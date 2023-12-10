using Dto.ProductDto;

namespace Messages.VoucherMessage
{
    public class CreateVoucherCommand : ICommand
    {
        public required VoucherDto Voucher { get; set; }
    }
}
