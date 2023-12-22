using Dto.ProductDto;

namespace Messages.VoucherMessage
{
    public class UpdateVoucherCommand : ICommand
    {
        public required string Code { get; set; }
        public required VoucherDto Voucher { get; set; }
    }
}
