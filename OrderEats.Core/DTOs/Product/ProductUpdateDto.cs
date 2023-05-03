using FluentValidation;
using OrderEats.Core.Abstractions.DTO;
using OrderEats.Core.DTOs;

namespace OrderEats.Core.DTO.Product
{
    public class ProductUpdateDto : BaseEntityDto
    {
        public long CategoryId { get; set; }

        public string Name { get; set; }

        public string? Picture { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public ICollection<ProductPropertyDto> ProductProperties { get; set; }
    }

    public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateValidator()
        {
            RuleFor(p => p.Id).NotEmpty().GreaterThan(0);
            RuleFor(p => p.Name).NotEmpty().MaximumLength(256).WithMessage("Enter product name");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Choose category");
            RuleFor(p => p.Picture).MaximumLength(256);
            RuleFor(p => p.Description).MaximumLength(256);
        }
    }
}
