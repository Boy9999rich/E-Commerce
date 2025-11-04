using OrderService.Dtos.OrderItemDto;

namespace OrderService.Dtos.OrderDto
{
    public class OrderGetDto
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<OrderItemDetailedDto> Items { get; set; } = new List<OrderItemDetailedDto>();
    }
}
