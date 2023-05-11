using Consid_TestUppgift.Data;
using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace Consid_TestUppgift.Repositories
{
    public class SupplierRepository : IGenericRepository<Supplier>
    {
        private readonly ApplicationContext _context;
        public SupplierRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddEntity(Supplier entity)
        {
            _context.Suppliers.Add(entity);
          await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var supplierToDelete = await _context.Suppliers.FindAsync(id);
            if (supplierToDelete != null)
            {
                _context.Suppliers.Remove(supplierToDelete);
                 await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("No supplier found with the specified ID", nameof(id));
            }
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetEntityById(int id)
        {
           var selectedSupplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id);

            if (selectedSupplier != null)
            {
             return selectedSupplier;
            }
            else
            {
                throw new ArgumentException("No supplier found with the specified ID", nameof(id));
            }
        }

        public async Task UpdateEntity(Supplier entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
