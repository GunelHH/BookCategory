using System;
using FluentValidation;

namespace HomeTaskBookCategory.DTOs.Book
{
    public class BookPostDto
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public short Price { get; set; }

    }
    public class BookPostDtoValidator : AbstractValidator<BookPostDto>
    {
        public BookPostDtoValidator()
        {
            RuleFor(c => c.Name).MaximumLength(100).WithMessage("The name field cannot be up than 100").NotEmpty().WithMessage("Please fill Name field");
            RuleFor(c => c.Author).MaximumLength(60).WithMessage("The author field cannot be up than 60").NotEmpty().WithMessage("Please fill author field");
            RuleFor(c => c.Price).NotEmpty().WithMessage("Please fill price field").LessThanOrEqualTo((short)2000).WithMessage("Price cannot be over  2000");
        }
    }
}

