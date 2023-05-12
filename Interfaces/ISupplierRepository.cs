using Consid_TestUppgift.Models;

namespace Consid_TestUppgift.Interfaces
{
    public interface ISupplierRepository
    {
        public Task AddNewSupplier(Supplier supplier);
        public Task DeleteSupplier(int id);
        public Task UpdateSupplier(Supplier supplier);
        public Task<IEnumerable<Supplier>> GetAllSuppliers();
        public Task<Supplier> GetSupplierById(int id);
    }
}
