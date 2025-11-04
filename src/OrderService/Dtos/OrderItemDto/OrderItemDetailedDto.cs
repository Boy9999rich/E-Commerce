namespace OrderService.Dtos.OrderItemDto
{
    public class OrderItemDetailedDto
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
