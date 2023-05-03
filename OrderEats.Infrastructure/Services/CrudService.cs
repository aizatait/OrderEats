using Mapster;
using OrderEats.Core.Abstractions.Data;
using OrderEats.Core.Abstractions.DTO;
using OrderEats.Infrastructure.Repositories;

namespace OrderEats.Infrastructure.Services
{
    public class CrudService<TEntity, TKey> : ICrudService<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
    {
        public CrudService(IRepository<TEntity, TKey> repository)
        {
            Repository = repository;
        }

        protected IRepository<TEntity, TKey> Repository { get; }

        public virtual async Task<IReadOnlyCollection<TDto>> GetAllAsync<TDto>() where TDto : class, IDto
        {
            var entity = await Repository.GetAllAsync();
            return entity.Adapt<IReadOnlyCollection<TDto>>();
        }

        public virtual async Task<TDto> GetByIdAsync<TDto>(TKey id) where TDto : class, IDto
        {
            var entity = await Repository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception($"Bad request {typeof(TEntity).Name} by id not found.");

            return entity.Adapt<TDto>();
        }
        public virtual async Task<TKey> CreateAsync<TDto>(TDto dto) where TDto : class, IDto
        {
            var entity = dto.Adapt<TEntity>();
            await Repository.AddAsync(entity);
            await Repository.SaveChangesAsync();

            return entity.Id;
        }

        public virtual async Task<TDto> UpdateAsync<TDto>(TDto dto) where TDto : class, IDto
        {
            var entity = dto.Adapt<TEntity>();
            Repository.Update(entity);
            await Repository.SaveChangesAsync();
            return entity.Adapt<TDto>();
        }

        public virtual async Task<bool> DeleteAsync<TDto>(TKey id) where TDto : class, IDto
        {
            TEntity entity = await Repository.GetByIdAsync(id);

            if (entity == null)
                return false;

            Repository.Delete(entity);
            await Repository.SaveChangesAsync();

            return true;
        }
    }
}
