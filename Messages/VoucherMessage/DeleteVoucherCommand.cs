namespace Messages.VoucherMessage
{
    public class DeleteVoucherCommand : ICommand
    {
        public required string Code { get; set; }
    }
}
