using DemoCICD.Contract.Shared;
using MediatR;

namespace DemoCICD.Contract.Asbtractions.Message;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
