using DemoCICD.Contract.Shared;
using MediatR;

namespace DemoCICD.Contract.Asbtractions.Message;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
