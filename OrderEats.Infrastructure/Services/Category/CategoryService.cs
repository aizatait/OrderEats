using OrderEats.Infrastructure.Repositories;

namespace OrderEats.Infrastructure.Services.Category
{
    public class CategoryService : CrudService<Core.Models.Category, long>, ICategoryService
    {
        public CategoryService(IRepository<Core.Models.Category, long> repository) : base(repository)
        {
        }
    }
}
