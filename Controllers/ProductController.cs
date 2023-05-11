using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consid_TestUppgift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IGenericRepository<Product>? _product;

        public ProductController(IGenericRepository<Product>? product)
        {
            _product = product;
        }

        //Get all products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _product.GetAll();
            return Ok(products);
        }

        //Get product by Id
        [HttpGet]
        [Route("Id")]
        [ActionName("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var product = _product.GetEntityById(id);
            return Ok(product);
        }


        //Create new product
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _product.AddEntity(product);
            return CreatedAtAction(nameof(CreateProduct),new { id = product.ProductId }, product);
        }

        //Update product
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != 0)
            {
                _product.UpdateEntity(product);
                return Ok(product);
            }
            return NotFound("Product not found");
        }

        //Delete product
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id != 0)
            {
                _product.DeleteEntity(id);
                return Ok();
            }
            return NotFound("Product not found");
        }
    }
}
