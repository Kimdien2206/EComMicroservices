using Dto.AuthDto;

namespace Messages.UserMessages
{
    public class GetAllUsersResponse : IMessage
    {
        public string SagaId { get; set; }

        public List<UserDto> Users { get; set; }
    }
}
