namespace ProductServic.Dtos
{
    public class ProductGetDto
    {
        public long ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; } = null!;
    }
}
