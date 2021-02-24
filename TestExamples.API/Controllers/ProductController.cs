using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestExamples.API.DTOs;
using TestExamples.API.Services.Abstract;

namespace TestExamples.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductAsync().ConfigureAwait(false);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductDTO productDTO)
        {
            await _productService.AddProductAsync(productDTO).ConfigureAwait(false);
            return NoContent();
        }
    }
}
