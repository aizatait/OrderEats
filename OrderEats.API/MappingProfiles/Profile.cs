using Mapster;
using OrderEats.Core.DTO.Cart;
using OrderEats.Core.DTO.Product;
using OrderEats.Core.DTOs.Category;
using OrderEats.Core.Models;

namespace OrderEats.API.MappingProfiles
{
    internal class Profile : IRegister
    {
        /// <inheritdoc />
        /// <remarks>
        /// Naming notation:
        /// d - destination
        /// s - source
        /// </remarks>
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CategoryCreateDto, Category>()
                .Ignore(d => d.Id)
                .Ignore(d => d.CreatedById)
                .Ignore(d => d.CreatedAt)
                .Ignore(d => d.UpdatedById)
                .Ignore(d => d.UpdatedAt);

            config.NewConfig<CategoryUpdateDto, Category>()
                .Ignore(d => d.CreatedById)
                .Ignore(d => d.CreatedAt)
                .Ignore(d => d.UpdatedById)
                .Ignore(d => d.UpdatedAt);

            config.NewConfig<ProductCreateDto, Product>()
                .Ignore(d => d.Id)
                .Ignore(d => d.CreatedById)
                .Ignore(d => d.CreatedAt)
                .Ignore(d => d.UpdatedById)
                .Ignore(d => d.UpdatedAt)
                .Ignore(d => d.Category);

            config.NewConfig<ProductUpdateDto, Product>()
                .Ignore(d => d.CreatedById)
                .Ignore(d => d.CreatedAt)
                .Ignore(d => d.UpdatedById)
                .Ignore(d => d.UpdatedAt)
                .Ignore(d => d.Category);

            config.NewConfig<ProductPropertyDto, ProductProperty>()
                .Ignore(d => d.Product);

            config.NewConfig<Cart, CartDto>()
                .Ignore(d => d.TotalPrice)
                .MaxDepth(3);

            config.NewConfig<CartItem, CartItemDto>()
                .Ignore(d => d.TotalPrice);
        }
    }
}
