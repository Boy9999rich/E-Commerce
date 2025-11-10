using Microsoft.EntityFrameworkCore;
using ProductServic.Dtos;
using ProductServic.Entities;
using ProductServic.Persistence;

namespace ProductServic.Services
{
    public class ProductServicess : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductServicess(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> CreateAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockCount = dto.StockCount,
                CategoryId = dto.CategoryId,
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null) return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductGetDto>> GetAllAsync()
        {
            return await _dbContext.Products
                .Select(p => new ProductGetDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    StockCount = p.StockCount,
                    ImageUrl = p.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<ProductGetDto?> GetByIdAsync(long id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null) return null;

            return new ProductGetDto
            {
                ProductId = product.ProductId,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                StockCount = product.StockCount,
                ImageUrl = product.ImageUrl
            };
        }

        public async Task<ProductGetDto?> UpdateAsync(ProductUpdateDto dto)
        {
            var product = await _dbContext.Products.FindAsync(dto.ProductId);
            if (product == null) return null;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.StockCount = dto.StockCount;
            product.CategoryId = dto.CategoryId;
            product.ImageUrl = dto.ImageUrl;

            await _dbContext.SaveChangesAsync();

            return new ProductGetDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                StockCount = product.StockCount,
                ImageUrl = product.ImageUrl
            };

        }
    }
}
