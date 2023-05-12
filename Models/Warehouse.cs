using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Consid_TestUppgift.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [Required]
        public string? WarehouseName { get; set; }
        //TODO RADERA 
        public decimal Capacity { get; set; }

        public virtual ICollection<ProductWarehouse>? Products { get; set; }
    }
}
