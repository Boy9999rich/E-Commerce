using OrderService.Dtos.OrderItemDto;

namespace OrderService.Dtos.OrderDto
{
    public class OrderCreateDto
    {
        public long UserId { get; set; }
        public List<OrderItemmDto> Items { get; set; } = new List<OrderItemmDto>();
    }
}
