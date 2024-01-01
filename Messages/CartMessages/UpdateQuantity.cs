using Dto.CartDto;

namespace Messages.CartMessages
{
    public class UpdateQuantity : ICommand
    {
        public UpdateCartDto CartDto { get; set; }
    }
}
