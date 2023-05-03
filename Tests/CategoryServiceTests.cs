using Moq;
using OrderEats.Core.DTOs.Category;
using OrderEats.Core.Models;
using OrderEats.Infrastructure.Repositories;
using OrderEats.Infrastructure.Services.Category;

namespace Tests
{
    public class CategoryServiceTests
    {
        private readonly CategoryService _categoryService;
        private readonly Mock<IRepository<Category, long>> _categoryMock = new();

        public CategoryServiceTests()
        {
            _categoryService = new CategoryService(_categoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_CategoriesList_Success()
        {
            //Arrange
            _categoryMock.Setup(p => p.GetAllAsync()).ReturnsAsync(GetTestCategory());

            //Act
            var result = await _categoryService.GetAllAsync<CategoryInfoDto>();

            //Assert
            Assert.Equal(GetTestCategory().Count, result.Count);
        }

        [Fact]
        public async Task GetByIdAsync_WhenCategoryExist_Success()
        {
            //Arrange
            int categoryId = 1;

            _categoryMock.Setup(repo => repo.GetByIdAsync(categoryId))
                .ReturnsAsync(GetTestCategory().FirstOrDefault(entity => entity.Id == categoryId));

            //Act
            var result = await _categoryService.GetByIdAsync<CategoryInfoDto>(categoryId);

            //Assert
            Assert.Equal(categoryId, result.Id);
        }

        /* [Fact]
         public async Task GetByIdAsync_WhenCategoryNotExist_Fail()
         {
             //Arrange
             _categoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception("Bad request product by id not found."));

             //Act
             var result = await _categoryService.GetByIdAsync<CategoryDto>(It.IsAny<int>());

            //Assert
         } */

        [Fact]
        public async Task CreateAsync_NewCategory_Success()
        {
            //Arrange
            var categoryDto = new CategoryCreateDto()
            {
                //Id = 4,
                Name = "Gift"
            };

            var category = new Category();

            var test = _categoryMock.Setup(repo => repo.AddAsync(It.IsAny<Category>()))
                .Callback<Category>(entity =>
                {
                    category = entity;
                });

            //Act
            var result = await _categoryService.CreateAsync(categoryDto);

            //Assert
            Assert.Equal(category.Id, result);
        }

        [Fact]
        public async Task UpdateAsync_WhenCategoryExist_Success()
        {
            //Arrange
            var categoryDto = new CategoryUpdateDto()
            {
                Id = 1,
                Name = "Soup"
            };

            var category = new Category();

            _categoryMock.Setup(repo => repo.Update(It.IsAny<Category>()))
            .Callback<Category>(entity =>
           {
               category = entity;
           });

            //Act
            var result = await _categoryService.UpdateAsync(categoryDto);

            //Assert
            Assert.Equal(categoryDto.Name, result.Name);
            Assert.Equal(category.Name, result.Name);
        }

        [Fact]
        public async Task DeleteAsync_WhenCategoryExist_Success()
        {
            //Arrange
            int categoryId = 1;


            _categoryMock.Setup(repo => repo.GetByIdAsync(categoryId))
                .ReturnsAsync(GetTestCategory().FirstOrDefault(entity => entity.Id == categoryId));

            //Act
            var result = await _categoryService.DeleteAsync<CategoryInfoDto>(categoryId);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_WhenCategoryNotExist_Fail()
        {
            //Arrange
            _categoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
              .ReturnsAsync(() => null);

            //Act
            var result = await _categoryService.DeleteAsync<CategoryInfoDto>(It.IsAny<int>());

            //Assert
            Assert.False(result);
        }

        private List<Category> GetTestCategory()
        {
            var categories = new List<Category>
            {
            new Category { Id = 1, Name = "Pizza" },
            new Category { Id = 2, Name = "Drinks" },
            new Category { Id = 3, Name = "Dessert" }
            };
            return categories;
        }
    }
}