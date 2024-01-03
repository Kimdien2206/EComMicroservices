namespace Dto.ReceiptDto
{
    public class ReceiptDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Cost { get; set; }

        public char Status { get; set; }

        public string? VoucherCode { get; set; }

        public int OrderId { get; set; }

        public OrderDto.OrderDto? Order { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public virtual OrderDto.OrderDto OrderInfo { get; set; }
    }
}
