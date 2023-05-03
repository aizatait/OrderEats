using OrderEats.Core.DTO.Product;

namespace OrderEats.Infrastructure.Services.Product
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<ProductInfoDto>> GetByCategoryIdAsync(int id);
        Task<ProductInfoDto> GetByIdAsync(int id);
        Task<long> CreateAsync(ProductCreateDto dto);
        Task<ProductInfoDto> UpdateAsync(ProductUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
