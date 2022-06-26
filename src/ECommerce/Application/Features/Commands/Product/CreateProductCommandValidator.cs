using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.RequestModels;
using FluentValidation;

namespace Application.Features.Commands.Product
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(i => i.Name)
                .NotNull()
                .MaximumLength(100)
                .WithMessage("{PropertyName} must be a maximum of {MaxLength} characters");

            RuleFor(i => i.Description)
                .NotNull()
                .MaximumLength(500)
                .WithMessage("{PropertyName} must be a maximum of {MaxLength} characters");
        }
    }
}