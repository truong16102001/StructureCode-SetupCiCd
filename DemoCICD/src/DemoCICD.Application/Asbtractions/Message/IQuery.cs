using DemoCICD.Domain.Shared;
using MediatR;

namespace DemoCICD.Application.Asbtractions.Message;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
