using System.ComponentModel.DataAnnotations;

namespace Consid_TestUppgift.Models
{
    public class ProductWarehouse
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int QuantityInStock { get; set; }


        public Product? Product { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
