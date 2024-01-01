using Dto.CartDto;

namespace Messages.CartMessages
{
    public class CreateCart : ICommand
    {
        public CreateCartDto newCart { get; set; }
    }
}
