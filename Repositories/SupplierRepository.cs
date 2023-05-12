using Consid_TestUppgift.Data;
using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace Consid_TestUppgift.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationContext _context;
        public SupplierRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddNewSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplier(int id)
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

        public async Task<Supplier> GetSupplierById(int id)
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

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task UpdateSupplier(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
