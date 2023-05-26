namespace eBet.Data.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(ICollection<TEntity> entities);
        void Remove(TEntity entity);
    }
}