namespace Messages.UserMessages
{
    public class GetAllUsersCommand : ICommand
    {
        public string SagaId { get; set; }
    }
}
