using OrderEats.Core.DTO.Cart;

namespace OrderEats.Infrastructure.Services.Cart
{
    public interface ICartService
    {
        Task<CartDto> GetByIdAsync(long id);
        Task<CartDto> GetByUserIdAsync(long userId);
        Task<IReadOnlyCollection<CartDto>> GetAllAsync();
        Task<long> AddUpdateProductToCartAsync(long productId, int quaintity);
        Task<bool> RemoveProductFromCartAsync(long cartId, long productId);
        Task<bool> DeleteAsync(long id);
    }
}
