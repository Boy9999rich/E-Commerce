namespace OrderService.Dtos.OrderItemDto
{
    public class OrderItemmDto
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
