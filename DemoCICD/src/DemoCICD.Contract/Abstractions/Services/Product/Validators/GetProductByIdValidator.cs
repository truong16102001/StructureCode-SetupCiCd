using FluentValidation;

namespace DemoCICD.Contract.Abstractions.Services.Product.Validators;
public class GetProductByIdValidator : AbstractValidator<Query.GetProductByIdQuery>
{
    public GetProductByIdValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
