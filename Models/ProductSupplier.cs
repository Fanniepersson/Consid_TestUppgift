using System.Security.Principal;

namespace Consid_TestUppgift.Models
{
    public class ProductSupplier
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int QuantityForSale { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}
