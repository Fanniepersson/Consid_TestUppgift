using System.ComponentModel.DataAnnotations;

namespace Consid_TestUppgift.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [Required]
        public string? WarehouseName { get; set; }
        public decimal Capacity { get; set; }

        public ICollection<ProductWarehouse>? Products { get; set; }
    }
}
