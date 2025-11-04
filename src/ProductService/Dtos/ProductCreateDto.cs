namespace ProductServic.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockCount { get; set; }
        public long CategoryId { get; set; }
        public IFormFile file { get; set; }
    }
}
