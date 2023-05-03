using Microsoft.AspNetCore.Mvc;
using OrderEats.Core.DTOs.Category;
using OrderEats.Infrastructure.Services.Category;

namespace OrderEats.Api.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id}", Name = "getCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<CategoryInfoDto> GetCategoryAsync(int id)
        {
            return  _service.GetByIdAsync<CategoryInfoDto>(id);
        }

        [HttpGet(Name = "getAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IReadOnlyCollection<CategoryInfoDto>> GetAllAsync()
        {
            return _service.GetAllAsync<CategoryInfoDto>();
        }

        [HttpPost(Name = "createCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<long> CreateAsync([FromBody] CategoryCreateDto dto)
        {
            return _service.CreateAsync(dto);
        }

        [HttpPut(Name = "updateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<CategoryUpdateDto> UpdateAsync([FromBody] CategoryUpdateDto dto)
        {
            return _service.UpdateAsync(dto);
        }

        [HttpDelete("{id}", Name = "deleteCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<bool> DeleteAsync(int id)
        {
            return _service.DeleteAsync<CategoryInfoDto>(id);
        }
    }
}
