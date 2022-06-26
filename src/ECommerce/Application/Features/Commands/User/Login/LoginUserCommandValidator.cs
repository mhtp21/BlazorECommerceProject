using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.RequestModels;
using FluentValidation;

namespace Application.Features.Commands.User.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(i => i.Email)
                .NotNull()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("{PropertyName} not a valid email address");

            RuleFor(i => i.Password)
            .NotNull()
            .MinimumLength(8)
            .MaximumLength(20)
            .WithMessage("{PropertyName} must be a minimum of {MinLenght} and a maximum of {MaxLength} characters");
        }
    }
}
