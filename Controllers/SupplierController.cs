using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consid_TestUppgift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository? _supplier;

        public SupplierController(ISupplierRepository? supplier)
        {
            _supplier = supplier;   
        }


        //Get all suppliers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = _supplier.GetAllSuppliers();
            return Ok(await suppliers);
        }


        //Create new supplier
        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _supplier.AddNewSupplier(supplier);
            return CreatedAtAction(nameof(Create), new { id = supplier.SupplierId }, supplier);
        }

        //Update supplier
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, Supplier supplier)
        {
            if (id != 0)
            {
                await _supplier.UpdateSupplier(supplier);
                return Ok(supplier);
            }
            return NotFound("Supplier not found");
        }

        //Delete supplier
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
               await _supplier.DeleteSupplier(id);
                return Ok();
            }
            return NotFound("Supplier not found");
        }
    }
}
