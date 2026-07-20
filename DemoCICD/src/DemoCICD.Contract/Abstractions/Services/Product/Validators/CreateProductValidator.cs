using FluentValidation;

namespace DemoCICD.Contract.Abstractions.Services.Product.Validators;
public class CreateProductValidator : AbstractValidator<Command.CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(150);
        RuleFor(c => c.Description).NotEmpty().MaximumLength(500);
        RuleFor(c => c.Price).GreaterThan(0);
    }
}
