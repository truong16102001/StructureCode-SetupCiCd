using FluentValidation;

namespace DemoCICD.Contract.Abstractions.Services.Product.Validators;
public class UpdateProductValidator : AbstractValidator<Command.UpdateProduct>
{
    public UpdateProductValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Price).GreaterThan(0);
    }
}
