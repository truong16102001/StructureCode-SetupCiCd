using DemoCICD.Contract.Services.Product;
using FluentValidation;

namespace DemoCICD.Contract.Services.Product.Validators;
public class GetProductByIdValidator : AbstractValidator<Query.GetProductByIdQuery>
{
    public GetProductByIdValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
