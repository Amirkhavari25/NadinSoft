using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Application.Services.Interfaces;
using NadinSoft.Domain.Models;
using System.Text.Json.Serialization;

namespace NadinSoft.Controllers
{
    [Route("api/[controller]/[action]")]
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
        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                await _productService.AddProduct(model);
                return Created();
            }
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductModel>> GetProductForEdit(int productId)
        {
            var product = await _productService.GetProductForEdit(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct(int productId, ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var res = await _productService.UpdateProduct(productId, model);
            if (res == true)
            {
                return NoContent();

            }
            else
            {
                return NotFound("محصولی برای ویرایش یافت نشد");
            }
        }

    }
}
