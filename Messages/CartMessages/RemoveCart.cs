using Dto.CartDto;

namespace Messages.CartMessages
{
    public class RemoveCart : ICommand
    {
        public int CartId { get; set; }
        public bool IsDeleteAll { get; set; }
        public List<CartDetailDto> RemoveDetails { get; set; }
    }
}
