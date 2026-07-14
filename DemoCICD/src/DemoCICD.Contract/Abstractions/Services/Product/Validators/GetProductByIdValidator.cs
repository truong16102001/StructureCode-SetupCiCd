using FluentValidation;

namespace DemoCICD.Contract.Abstractions.Services.Product.Validators;
public class GetProductByIdValidator : AbstractValidator<Query.GetProductById>
{
    public GetProductByIdValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
