using Consid_TestUppgift.Data;
using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace Consid_TestUppgift.Repositories
{
    public class WarehouseRepository : IWarehouseRespository
    {
        private readonly ApplicationContext _context;

        public WarehouseRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddNewWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task AddQuantityOfProductInWarehouse(int productId, int warehouseId, int amount, ProductWarehouse product)
        {
            var productInWarehouseToUpdate = await _context.ProductWarehouse.Where(x => x.WarehouseId == warehouseId).FirstOrDefaultAsync(p => p.ProductId == productId);

            if (productInWarehouseToUpdate != null)
            {
                if (amount > 0)
                {
                    productInWarehouseToUpdate.QuantityInStock = productInWarehouseToUpdate.QuantityInStock + amount;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Can not add the selected amount, must be greater than 0");
                }
            }
        }
        public async Task RemoveQuantityOfProductInWarehouse(int productId, int warehouseId, int amount, ProductWarehouse product)
        {
            var productInWarehouseToUpdate = await _context.ProductWarehouse.Where(x => x.WarehouseId == warehouseId).FirstOrDefaultAsync(p => p.ProductId == productId);

            if (productInWarehouseToUpdate != null)
            {
                if (amount < productInWarehouseToUpdate.QuantityInStock)
                {
                    productInWarehouseToUpdate.QuantityInStock = productInWarehouseToUpdate.QuantityInStock - amount;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("Can not remove the selected amount");
                }
            }
        }


        public async Task DeleteWarehouse(int id)
        {
            var warehouseToDelete = await _context.Warehouses.FindAsync(id);

            if (warehouseToDelete != null)
            {
                _context.Remove(warehouseToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("No warehouse found with the specified ID", nameof(id));
            }
        }

        public async Task<IEnumerable<Warehouse>> GetAllWarehouses()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse> GetWarehouseById(int id)
        {
            var selectedWarehouse = await _context.Warehouses.FirstOrDefaultAsync(x => x.WarehouseId == id);

            if (selectedWarehouse != null)
            {
                return selectedWarehouse;
            }
            else
            {
                throw new ArgumentException("No warehouse found with the specified ID", nameof(id));
            }
        }

        public async Task UpdateWarehouse(Warehouse warehouse)
        {
            _context.Entry(warehouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
