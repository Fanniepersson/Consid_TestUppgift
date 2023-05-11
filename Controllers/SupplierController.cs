using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consid_TestUppgift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IGenericRepository<Supplier>? _supplier;

        public SupplierController(IGenericRepository<Supplier>? supplier)
        {
            _supplier = supplier;   
        }


    }
}
