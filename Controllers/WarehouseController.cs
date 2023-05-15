using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consid_TestUppgift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRespository _warehouse;

        public WarehouseController(IWarehouseRespository warehouse)
        {
            _warehouse = warehouse;
        }

        //Get all warehouses
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehouses = _warehouse.GetAllWarehouses();
            return Ok(await warehouses);
        }


        //Get warehouse by Id
        [HttpGet]
        [Route("Id")]
        [ActionName("GetWarehouseById")]
        public async Task<IActionResult>GetById(int id)
        {
            var productsInWarehouse = _warehouse.GetProductsInWarehouseById(id);
            return Ok(await productsInWarehouse);
        }

        //Create new warehouse
        [HttpPost]
        public async Task<IActionResult> Create(Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _warehouse.AddNewWarehouse(warehouse);
            return CreatedAtAction(nameof(Create), new { id = warehouse.WarehouseId }, warehouse);
        }

        //Update warehouse
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, Warehouse warehouse)
        {
            if (id != 0)
            {
                await _warehouse.UpdateWarehouse(warehouse);
                return Ok(warehouse);
            }
            return NotFound("Warehouse not found");
        }


        //Delete warehouse
        [HttpDelete]
        [Route("{id:int}")]
        public async Task <IActionResult> Delete(int id)
        {
            if (id != 0)
            {
               await _warehouse.DeleteWarehouse(id);
                return Ok();
            }
            return NotFound("Warehouse not found");
        }
    }
}
