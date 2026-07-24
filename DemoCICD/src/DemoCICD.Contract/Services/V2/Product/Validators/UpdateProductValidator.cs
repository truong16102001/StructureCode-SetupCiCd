using DemoCICD.Contract.Services.V2.Product;
using FluentValidation;

namespace DemoCICD.Contract.Services.V2.Product.Validators;
public class UpdateProductValidator : AbstractValidator<Command.UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Price).GreaterThan(0);
    }
}
