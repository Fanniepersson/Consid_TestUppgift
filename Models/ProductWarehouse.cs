namespace Consid_TestUppgift.Models
{
    public class ProductWarehouse
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int QuantityInStock { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
    }
}
