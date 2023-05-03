using Microsoft.AspNetCore.Mvc;
using OrderEats.Core.DTO.Cart;
using OrderEats.Infrastructure.Services.Cart;

namespace OrderEats.Api.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly ICartService _service;
        public CartController(ICartService cartService)
        {
            _service = cartService;
        }

        [HttpGet("{id}", Name = "getCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<CartDto> GetByIdAsync(long id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpGet("User/{id}", Name = "getByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<CartDto> GetByUserIdAsync(long id)
        {
            return _service.GetByUserIdAsync(id);
        }

        [HttpGet(Name = "getAllCarts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IReadOnlyCollection<CartDto>> GetAllAsync()
        {
            return _service.GetAllAsync();
        }

        [HttpPost("Product/{productId}/Quantity/{quantity}", Name = "addProductToCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<long> AddProductToCartAsync(long productId, int quantity)
        {
            return _service.AddUpdateProductToCartAsync(productId, quantity);
        }

        [HttpDelete("{cartId}/Product/{productId}", Name = "deletProductFromCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<bool> DeleteProductFromCartAsync(long cartId, long productId)
        {
            return _service.RemoveProductFromCartAsync(cartId, productId);
        }

        [HttpDelete("{id}", Name = "deleteCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<bool> DeleteAsync(long id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
