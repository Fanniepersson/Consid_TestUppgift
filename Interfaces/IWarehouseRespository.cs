using Consid_TestUppgift.Models;

namespace Consid_TestUppgift.Interfaces
{
    public interface IWarehouseRespository
    {
        public Task AddNewWarehouse(Warehouse warehouse);
        public Task DeleteWarehouse(int id);
        public Task UpdateWarehouse(Warehouse warehouse);
        public Task<Warehouse>GetWarehouseById(int id);
        public Task<IEnumerable<ProductWarehouse>> GetProductsInWarehouseById(int id);

        public Task<IEnumerable<Warehouse>> GetAllWarehouses();
        public Task<Product> GetProductByIdInWarehouse(int id);
        //public Task ChangeQuantityOfProductInWarehouse(int id, ProductWarehouse product);

    }
}
