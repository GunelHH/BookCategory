using System;
using FluentValidation;

namespace HomeTaskBookCategory.DTOs.Category
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }

    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("The name field cannot be up than 50").NotEmpty().WithMessage("Please fill Name field");
        }
    }
}

