namespace Consid_TestUppgift.Interfaces
{
    public interface IGenericRepository<T>
    {
        public Task AddEntity(T entity);
        public Task DeleteEntity(int id);
        public Task UpdateEntity(T entity);
        public Task<T> GetEntityById(int id);
        public Task<IEnumerable<T>> GetAll();
    }
}
