using Mapster;
using Microsoft.EntityFrameworkCore;
using OrderEats.Core.DTO.Product;
using OrderEats.Infrastructure.Data;

namespace OrderEats.Infrastructure.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<ProductInfoDto>> GetByCategoryIdAsync(int id)
        {
            return await _dbContext.Products
                .Where(c => c.CategoryId == id)
                .Include(p => p.ProductProperties)
                .AsNoTracking()
                .ProjectToType<ProductInfoDto>()
                .ToListAsync();

        }

        public async Task<ProductInfoDto> GetByIdAsync(int id)
        {
            var result = await _dbContext.Products
                 .Include(p => p.ProductProperties)
                 .AsNoTracking()
                 .Where(p => p.Id == id)
                 .ProjectToType<ProductInfoDto>()
                 .SingleOrDefaultAsync();

            if (result == null)
                throw new Exception("Bad request product by id not found.");

            return result;

        }

        public async Task<long> CreateAsync(ProductCreateDto dto)
        {
            var entity = dto.Adapt<Core.Models.Product>();

            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<ProductInfoDto> UpdateAsync(ProductUpdateDto dto)
        {
            var entity = dto.Adapt<Core.Models.Product>();

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Adapt<ProductInfoDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Products.FindAsync(id);

            if (entity == null)
                return false;

            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
