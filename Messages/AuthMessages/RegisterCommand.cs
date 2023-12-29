using Dto.AuthDto;

namespace Messages.AuthMessages
{
    public class RegisterCommand : ICommand
    {
        public RegisterDto Register { get; set; }
    }
}
