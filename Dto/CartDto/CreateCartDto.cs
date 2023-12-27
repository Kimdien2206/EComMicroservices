namespace Dto.CartDto
{
    public class CreateCartDto
    {
        public string PhoneNumber { get; set; }

        public List<CartDetailDto> Details { get; set; }
    }
}
