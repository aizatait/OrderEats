using Microsoft.AspNetCore.Mvc;
using OrderEats.Core.DTO;
using OrderEats.Core.DTO.Product;
using OrderEats.Infrastructure.Services.Product;

namespace OrderEats.Api.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}", Name = "getProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ProductInfoDto> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }

        [HttpGet("Category/{id}", Name = "getByCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IReadOnlyCollection<ProductInfoDto>> GetByCategoryIdAsync(int id)
        {
            return _service.GetByCategoryIdAsync(id);
        }

        [HttpPost(Name = "createProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<long> CreateAsync([FromBody] ProductCreateDto dto)
        {
            return _service.CreateAsync(dto);
        }

        [HttpPut(Name = "updateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ProductInfoDto> UpdateAsync([FromBody] ProductUpdateDto dto)
        {
            return _service.UpdateAsync(dto);
        }

        [HttpDelete("{id}", Name = "deleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<bool> DeleteAsync(int id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
