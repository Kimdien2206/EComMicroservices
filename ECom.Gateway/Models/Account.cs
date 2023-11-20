namespace ECom.Gateway.Models
{
    public class Account
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsAdmin { get; set; }
    }
}
