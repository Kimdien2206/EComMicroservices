using Dto.CartDto;

namespace Messages.CartMessages
{
    public class RemoveCart : ICommand
    {
        public string PhoneNumber { get; set; }
        public bool IsDeleteAll { get; set; }
        public CartDto RemoveDetail { get; set; }
    }
}
