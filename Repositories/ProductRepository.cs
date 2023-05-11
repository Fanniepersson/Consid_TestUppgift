using Consid_TestUppgift.Data;
using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace Consid_TestUppgift.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddEntity(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);

            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("No product found with the specified ID", nameof(id));
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetEntityById(int id)
        {
            var selectedProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            if (selectedProduct != null)
            {
                return selectedProduct;
            }
            else
            {
                throw new ArgumentException("No product found with the specified ID", nameof(id));
            }
        }

        public async Task UpdateEntity(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
