namespace Messages.OrderMessages
{
    public class GetAllOrdersByPhonenumber : ICommand
    {
        public string? PhoneNumber { get; set; }
    }
}
