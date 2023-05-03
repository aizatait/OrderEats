using FluentValidation;
using OrderEats.Core.Models;

namespace OrderEats.Core.DTO.Product
{
    public class ProductPropertyDto : TrackingEntity
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ValueType { get; set; }

        public int? IntValue { get; set; }

        public string? StringValue { get; set; }

        public bool? BooleanValue { get; set; }

        public decimal? DecimalValue { get; set; }
    }

    public class ProductPropertyValidator : AbstractValidator<ProductPropertyDto>
    {
        public ProductPropertyValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(256);
            RuleFor(p => p.ValueType).NotEmpty().MaximumLength(256);
            RuleFor(p => p.StringValue).MaximumLength(256);
        }
    }
}
