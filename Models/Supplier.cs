using System.ComponentModel.DataAnnotations;

namespace Consid_TestUppgift.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        public string? SupplierName { get; set; }

        public virtual ICollection<ProductSupplier>? Products { get; set; }
    }
}
