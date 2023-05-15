using Consid_TestUppgift.Models;

namespace Consid_TestUppgift.Interfaces
{
    public interface IWarehouseRespository
    {
        public Task AddNewWarehouse(Warehouse warehouse);
        public Task DeleteWarehouse(int id);
        public Task UpdateWarehouse(Warehouse warehouse);
        public Task<Warehouse>GetWarehouseById(int id);
        public Task<IEnumerable<Warehouse>> GetAllWarehouses();
        public Task UpdateQuantityOfProductInWarehouse(int productId, int warehouseId, ProductWarehouse product);

    }
}
