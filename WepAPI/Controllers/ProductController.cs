using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto item)
        {
            var result = await _productService.Create(item);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var paginationRequest = new PaginationRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var result = await _productService.GetAllProductPaged(paginationRequest);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id);
            return Ok("Ürün Başarıyla Silindi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto item)
        {
            var result = await _productService.Update(item);
            return Ok(result);
        }
    }
}
