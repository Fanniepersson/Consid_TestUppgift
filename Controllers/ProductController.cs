using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consid_TestUppgift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository? _product;

        public ProductController(IProductRepository? product)
        {
            _product = product;
        }

        //Get all products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _product.GetAllProducts();
            return Ok(products);
        }

        //Get product by name
        [HttpGet("{productName}")]
        public async Task<IActionResult> GetByName(string productName)
        {
            var product = await _product.GetProductByName(productName);
            return Ok(product);
        }


        //Create new product
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _product.AddNewProduct(product);
            return CreatedAtAction(nameof(Create),new { id = product.ProductId }, product);
        }

        //Update product
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != 0)
            {
               await _product.UpdateProduct(product);
                return Ok(product);
            }
            return NotFound("Product not found");
        }

        //Delete product
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
               await _product.DeleteProduct(id);
                return Ok();
            }
            return NotFound("Product not found");
        }
    }
}
