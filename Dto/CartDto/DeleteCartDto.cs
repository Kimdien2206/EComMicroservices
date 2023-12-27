namespace Dto.CartDto
{
    public class DeleteCartDto
    {

        public bool IsDeleteAll { get; set; } = false;
        public List<CartDetailDto> Details { get; set; }
    }
}
