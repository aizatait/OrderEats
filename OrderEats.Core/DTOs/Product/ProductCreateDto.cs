using FluentValidation;
using OrderEats.Core.Abstractions.DTO;

namespace OrderEats.Core.DTO.Product
{
    public class ProductCreateDto : IDto
    {
        public long CategoryId { get; set; }

        public string Name { get; set; }

        public string? Picture { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public ICollection<ProductPropertyDto> ProductProperties { get; set; }
    }

    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(256).WithMessage("Enter product name");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Choose category");
            RuleFor(p => p.Picture).MaximumLength(256);
            RuleFor(p => p.Description).MaximumLength(256);
        }
    }
}
