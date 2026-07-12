using DemoCICD.Domain.Shared;
using MediatR;

namespace DemoCICD.Application.Asbtractions.Message;
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> 
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}

