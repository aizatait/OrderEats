using FluentValidation;
using OrderEats.Core.DTO.Product;
using OrderEats.Core.DTOs.Category;
using OrderEats.Infrastructure.Repositories;
using OrderEats.Infrastructure.Services.Cart;
using OrderEats.Infrastructure.Services.Category;
using OrderEats.Infrastructure.Services.Product;

namespace OrderEats.Api.Extensions
{
    internal static class ServiceProviderExtensions
    {
        public static void AppServicesProvider(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICartService, CartService>();

            services.AddTransient<IValidator<ProductCreateDto>, ProductCreateValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateValidator>();
            services.AddTransient<IValidator<ProductPropertyDto>, ProductPropertyValidator>();
            services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
        }
    }
}
