using Consid_TestUppgift.Data;
using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Consid_TestUppgift.Repositories
{
    public class WarehouseRepository : IGenericRepository<Warehouse>
    {
        private readonly ApplicationContext _context;

        public WarehouseRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddEntity(Warehouse entity)
        {
            _context.Warehouses.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
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

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
           return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse> GetEntityById(int id)
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

        public async Task UpdateEntity(Warehouse entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
