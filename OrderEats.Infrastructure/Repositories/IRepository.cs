using OrderEats.Core.Abstractions.Data;

namespace OrderEats.Infrastructure.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll { get; }
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
