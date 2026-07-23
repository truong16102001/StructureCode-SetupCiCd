using DemoCICD.Contract.Services.Product;
using FluentValidation;

namespace DemoCICD.Contract.Services.Product.Validators;
public class DeleteProductValidator : AbstractValidator<Command.DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}

