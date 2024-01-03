using Dto.AuthDto;
using Dto.OrderDto;

namespace SagaData.Recommendation
{
    public class RecommendSagaData : ContainSagaData
    {
        public string SagaId { get; set; }

        public List<UserDto> Users { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}
