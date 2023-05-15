using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consid_TestUppgift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWarehouseController : ControllerBase
    {
        private readonly IWarehouseRespository _warehouse;

        public ProductWarehouseController(IWarehouseRespository warehouse)
        {
            _warehouse = warehouse;
        }


        //Update product quantity
        [HttpPut]
        public async Task<IActionResult> UpdateQuantityOfProduct(int productId, int warehouseId, ProductWarehouse product)
        {
            if (warehouseId != 0)
            {
                await _warehouse.UpdateQuantityOfProductInWarehouse(productId, warehouseId, product);
                return Ok(product);
            }
            return NotFound("Warehouse & product not found");
        }

    }
}
