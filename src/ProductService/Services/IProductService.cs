using ProductServic.Dtos;
using ProductServic.Entities;

namespace ProductServic.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductGetDto>> GetAllAsync();
        Task<ProductGetDto?> GetByIdAsync(long id);
        Task<long> CreateAsync(ProductCreateDto dto);
        Task<ProductGetDto?> UpdateAsync(ProductUpdateDto dto);
        Task<bool> DeleteAsync(long id);

    }
}
