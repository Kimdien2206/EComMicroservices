namespace Dto.CartDto
{
    public class DeleteCartDto
    {

        public bool IsDeleteAll { get; set; } = false;
        public CartDto? Detail { get; set; }
    }
}
