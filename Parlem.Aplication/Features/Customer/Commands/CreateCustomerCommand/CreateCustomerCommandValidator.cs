using FluentValidation;

namespace Parlem.Aplication.Features.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
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
