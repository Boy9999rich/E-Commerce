using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServic.Services;

namespace ProductServic.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromForm] Dtos.ProductCreateDto dto)
        {
            if (dto.file != null && dto.file.Length > 0)
            {
                // Faylni serverga saqlash yoki cloud storage ga yuklash
                var fileName = $"{Guid.NewGuid()}_{dto.file.FileName}";
                var filePath = Path.Combine("wwwroot/images/products", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.file.CopyToAsync(stream);
                }
            }

            var productId = await _productService.CreateAsync(dto);
            return Ok(productId);
        }

        [HttpDelete("Delete/{id}")]

        public async Task<IActionResult> Delete(long id)
        {
            var result = await _productService.DeleteAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("GetById")]

        public async Task<IActionResult> GetById(long id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPut("Update")]

        public async Task<IActionResult> Update([FromBody] Dtos.ProductUpdateDto dto)
        {
            var updatedProduct = await _productService.UpdateAsync(dto);
            if (updatedProduct == null)
                return NotFound();
            return Ok(updatedProduct);
        }
    }
}
