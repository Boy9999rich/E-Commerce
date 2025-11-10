using OrderService.Dtos.OrderItemDto;

namespace OrderService.Dtos.OrderDto
{
    public class OrderCreateDto
    {
        public long UserId { get; set; }
        public List<OrderItemDetailedDto> Items { get; set; } = new List<OrderItemDetailedDto>();
    }
}
