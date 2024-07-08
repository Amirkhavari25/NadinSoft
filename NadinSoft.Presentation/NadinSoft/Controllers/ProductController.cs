using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Application.Services.Interfaces;
using NadinSoft.Domain.Models;
using System.Text.Json.Serialization;

namespace NadinSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            var res = await _productService.GetAllProducts();
            if (res.ToList().Count == 0)
            {
                return NotFound("موردی برای نمایش وجود ندارد");
            }
            return Ok(res);
        }
    }
}
