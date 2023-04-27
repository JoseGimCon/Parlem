using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Features.Customer.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.DocType)
                .NotEmpty().WithMessage("{PropertyName} campo obligatorio")
                .MaximumLength(3).WithMessage("{PropertyName} caracteres maximos {MaxLength}");


            RuleFor(p => p.DocNum)
                .NotEmpty().WithMessage("{PropertyName} campo obligatorio")
                .MaximumLength(10).WithMessage("{PropertyName} caracteres maximos {MaxLength}");

            RuleFor(p => p.GivenName)
                .NotEmpty().WithMessage("{PropertyName} campo obligatorio")
                .MaximumLength(80).WithMessage("{PropertyName} caracteres maximos {MaxLength}");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} campo obligatorio")
                .EmailAddress().WithMessage("{PropertyName}direccion de email no valido")
                .MaximumLength(80).WithMessage("{PropertyName} caracteres maximos {MaxLength}");

            RuleFor(p => p.FamilyName1)
                .NotEmpty().WithMessage("{PropertyName} campo obligatorio")
                .MaximumLength(80).WithMessage("{PropertyName} caracteres maximos {MaxLength}");

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("{PropertyName} campo obligatorio")
                .MaximumLength(9).WithMessage("{PropertyName} caracteres maximos {MaxLength}");
        }
    }
}
