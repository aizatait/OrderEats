using OrderEats.Core.Abstractions.Data;
using OrderEats.Core.Abstractions.DTO;

namespace OrderEats.Infrastructure.Services
{
    public interface ICrudService<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
    {
        Task<TDto> GetByIdAsync<TDto>(TKey id)
            where TDto : class, IDto;

        Task<IReadOnlyCollection<TDto>> GetAllAsync<TDto>()
            where TDto : class, IDto;

        Task<TKey> CreateAsync<TDto>(TDto dto)
            where TDto : class, IDto;

        Task<TDto> UpdateAsync<TDto>(TDto dto)
            where TDto : class, IDto;

        Task<bool> DeleteAsync<TDto>(TKey id)
            where TDto : class, IDto;
    }
}
