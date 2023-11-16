namespace ECom.Gateway.Models
{
    public class Discount
    {
        public int Id { get; set; }

        public double DiscountAmount { get; set; }

        public string Name { get; set; } = null!;
    }
}
