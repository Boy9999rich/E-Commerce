namespace ProductService.Entities
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public long CategoryId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
