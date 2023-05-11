using System.ComponentModel.DataAnnotations;

namespace Consid_TestUppgift.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ProductSupplier>? Suppliers { get; set; }
        public virtual ICollection<ProductWarehouse>? Warehouses { get; set; }
    }
}
