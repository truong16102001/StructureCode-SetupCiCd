namespace DemoCICD.Contract.Shared;
public interface IValidationResult
{
    Error[] Errors { get; }

    public static readonly Error ValidationError = new("ValidationError", "A validation problem occurred");
}
