using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Consid_TestUppgift.Models
{
    public class ProductSupplier
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int QuantityForSale { get; set; }

        public Product? Product { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
