using Mapster;
using Microsoft.EntityFrameworkCore;
using OrderEats.Core.DTO.Cart;
using OrderEats.Core.Models;
using OrderEats.Infrastructure.Data;

namespace OrderEats.Infrastructure.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly long _userId = 1;

        public CartService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CartDto> GetByIdAsync(long id)
        {
            var CartInfoDto = await _dbContext.Carts
                 .Include(c => c.CartItems)
                 .ThenInclude(i => i.Product)
                 .AsNoTracking()
                 .Where(c => c.Id == id)
                 .ProjectToType<CartDto>()
                 .SingleOrDefaultAsync();

            if (CartInfoDto == null)
                throw new Exception("Bad request cart by id not found.");

            CartInfoDto.TotalPrice = GetTotalPrice(CartInfoDto.CartItems);

            foreach (var item in CartInfoDto.CartItems)
            {
                item.TotalPrice = item.Product.Price * item.Quantity;
            }

            return CartInfoDto;
        }

        public async Task<CartDto> GetByUserIdAsync(long userId)
        {
            var CartInfoDto = await _dbContext.Carts
                .Where(c => c.UserId == userId)
                .Include(p => p.CartItems)
                .AsNoTracking()
                .ProjectToType<CartDto>()
                .SingleOrDefaultAsync();

            if (CartInfoDto == null)
                throw new Exception("Bad request cart by user id not found.");

            CartInfoDto.TotalPrice = GetTotalPrice(CartInfoDto.CartItems);

            foreach (var item in CartInfoDto.CartItems)
            {
                item.TotalPrice = item.Product.Price * item.Quantity;
            }

            return CartInfoDto;
        }

        public async Task<IReadOnlyCollection<CartDto>> GetAllAsync()
        {
            var CartInfoDto = await _dbContext.Carts
               .Include(c => c.CartItems)
               .AsNoTracking()
               .ProjectToType<CartDto>()
               .ToListAsync();

            foreach (var item in CartInfoDto)
            {
                foreach (var cartItem in item.CartItems)
                {
                    cartItem.TotalPrice = cartItem.Product.Price * cartItem.Quantity;
                }

                item.TotalPrice = GetTotalPrice(item.CartItems);
            }

            return CartInfoDto;
        }

        public async Task<long> AddUpdateProductToCartAsync(long productId, int quantity)
        {
            var cart = _dbContext.Carts
                .Where(c => c.UserId == _userId)
                .Include(c => c.CartItems.Where(i => i.ProductId == productId))
                .SingleOrDefault();

            var cartItem = cart?.CartItems.FirstOrDefault();

            if (cart == null)
                cart = new Core.Models.Cart() { UserId = _userId };

            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    ProductId = productId,
                    Quantity = quantity
                };

                cart.CartItems.Add(cartItem);

                var entityEntry = cart.Id > 0 ? _dbContext.Carts.Update(cart) : await _dbContext.Carts.AddAsync(cart);
            }
            else if (quantity > 0)
            {
                cartItem.Quantity = quantity;
            }
            else
            {
                _dbContext.CartItems.Remove(cartItem);
            }


            await _dbContext.SaveChangesAsync();

            return cart.Id;
        }

        public async Task<bool> RemoveProductFromCartAsync(long cartId, long productId)
        {
            var entity = await _dbContext.CartItems
                .SingleOrDefaultAsync(i => i.CartId == cartId && i.ProductId == productId);

            if (entity == null)
                return false;

            _dbContext.CartItems.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _dbContext.Carts.FindAsync(id);

            if (entity == null)
                return false;

            _dbContext.Carts.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        private static decimal GetTotalPrice(ICollection<CartItemDto> items)
        {
            decimal total = 0;

            if (items != null)
                total = items.Aggregate(total, (q, p) => (decimal)(q + (p.Quantity * p.Product.Price!)), q => q);

            return total;
        }
    }
}
