using Consid_TestUppgift.Data;
using Consid_TestUppgift.Interfaces;
using Consid_TestUppgift.Models;
using Microsoft.EntityFrameworkCore;

namespace Consid_TestUppgift.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddNewProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
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

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductById(int id)
        {
            var selectedProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            if (selectedProduct != null)
            {
              var productInWarehouse = await _context.Products.Where(x => x.ProductId == id).Include(p => p.Warehouses).ToListAsync();

                return productInWarehouse;
            }
            else
            {
                throw new ArgumentException("No product found with the specified ID", nameof(id));
            }
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllSuppliersWithProductsInWarehouse()
        {
            return await _context.Products.Include(p => p.Suppliers).Include(w => w.Warehouses).ToListAsync();
        }
    }
}
