using FluentValidation;

namespace DemoCICD.Contract.Abstractions.Services.Product.Validators;
public class DeleteProductValidator : AbstractValidator<Command.DeleteProduct>
{
    public DeleteProductValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

