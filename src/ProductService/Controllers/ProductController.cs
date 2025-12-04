using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServic.Dtos;
using ProductServic.Services;
using ProductService.Services;

namespace ProductServic.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        public ProductController(IProductService productService, IImageService imageService)
        {
            _productService = productService;
            _imageService = imageService;
        }

        [HttpPost("Create")]

        public async Task<IActionResult> Create([FromForm] ProductCreateDto dto)
        {


            // 2. ProductService ichida DBga yozish
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
