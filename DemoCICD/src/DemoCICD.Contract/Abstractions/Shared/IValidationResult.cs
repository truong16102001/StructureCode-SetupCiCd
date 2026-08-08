namespace DemoCICD.Contract.Shared;
public interface IValidationResult
{
    Error[] Errors { get; }

    static readonly Error ValidationError = new ("ValidationError", "A validation problem occurred");
}
