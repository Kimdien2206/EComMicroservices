namespace Messages.OrderMessages
{
    public class GetOrderById : ICommand
    {
        public int ID { get; set; }
    }
}
