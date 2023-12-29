namespace Dto.AuthDto
{
    public class RegisterDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public UserDto user { get; set; }
    }
}
