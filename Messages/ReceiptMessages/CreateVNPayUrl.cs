namespace Messages.ReceiptMessages
{
    public class CreateVNPayUrl : ICommand
    {
        public uint Amount { get; set; }
        public string CreateDate { get; set; }
        public uint TxnRef { get; set; }
    }
}
