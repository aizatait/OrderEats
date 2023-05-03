using FluentValidation;
using OrderEats.Core.Abstractions.DTO;

namespace OrderEats.Core.DTOs.Category
{
    public class CategoryCreateDto : IDto
    {
        public string Name { get; set; }
    }

    public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(256);
        }
    }
}
