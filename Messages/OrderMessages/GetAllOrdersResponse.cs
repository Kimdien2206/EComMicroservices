using Dto.OrderDto;

namespace Messages.OrderMessages
{
    public class GetAllOrdersResponse : IMessage
    {
        public string SagaId { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}
