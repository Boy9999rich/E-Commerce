namespace ProductServic.Dtos
{
    public class ProductUpdateDto
    {
        public long ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public long CategoryId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
