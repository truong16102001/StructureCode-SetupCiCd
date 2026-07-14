using DemoCICD.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens.Experimental;

namespace DemoCICD.Application.Exceptions;
public sealed class ValidationException : DomainException
{
    public IReadOnlyCollection<ValidationError> Errors { get; }

    public ValidationException(IReadOnlyCollection<ValidationError> errors)
        : base("Validation Failure", "One or more validation errors occurred")
        => Errors = errors;
}

public record ValidationError(string PropertyName, string ErrorMessage);
