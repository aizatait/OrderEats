using FluentValidation;
using OrderEats.Core.DTOs;

namespace OrderEats.Core.DTOs.Category
{
    public class CategoryUpdateDto : BaseEntityDto
    {
        public string Name { get; set; }
    }

    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(p => p.Id).NotEmpty().GreaterThan(0);
            RuleFor(p => p.Name).NotEmpty().MaximumLength(256);
        }
    }
}
