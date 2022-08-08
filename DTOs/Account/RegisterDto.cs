using System;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskBookCategory.DTOs.Account
{
    public class RegisterDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(r => r.Name).MaximumLength(30).NotEmpty();
            RuleFor(r => r.Surname).MaximumLength(35).NotEmpty();
            RuleFor(r => r.Username).MaximumLength(20).NotEmpty();
            RuleFor(r => r.Email).MaximumLength(20).NotEmpty().EmailAddress(mode:FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
            RuleFor(r => r).Custom((r, context) =>
            {
                if (r.Email!=r.ConfirmPassword)
                {
                    context.AddFailure(new ValidationFailure("Password","Password and Confirm Password doesn't matched "));
                }
            });
        }
    }
}

