using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.Application.Services.Interfaces;
using NadinSoft.Domain.Models;
using System.Text.Json.Serialization;

namespace NadinSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult<ProductModel>> GetProductForEdit(int productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPut("{productId}")]
        [Authorize]
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
        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<ActionResult> RemoveProduct(int productId)
        {
            //It's better to use soft delete by making "IsDelete" property True but for now we're gonna delete the record from database
            //For soft delete its better to create a base entity which has IsDelete property and each entity must impliment the base entity
            var res = await _productService.RemoveProduct(productId);
            if (res == true)
            {
                return NoContent();

            }
            else
            {
                return NotFound("محصولی برای حذف یافت نشد");
            }
        }

    }
}
