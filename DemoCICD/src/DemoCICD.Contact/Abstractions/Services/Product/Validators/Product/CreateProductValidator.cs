using FluentValidation;

namespace DemoCICD.Contract.Abstractions.Services.Product.Validators.Product;
public class CreateProductValidator : AbstractValidator<Command.CreateProduct>
{
    public CreateProductValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Price).GreaterThan(0);
    }
}
