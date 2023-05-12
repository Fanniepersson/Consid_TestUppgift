using Consid_TestUppgift.Models;

namespace Consid_TestUppgift.Interfaces
{
    public interface IProductRepository
    {
        public Task AddNewProduct(Product product);
        public Task DeleteProduct(int id);
        public Task UpdateProduct(Product product);
        public Task<List<Product>> GetProductById(int id);
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<IEnumerable<Product>> GetAllSuppliersWithProductsInWarehouse();

    }
}
