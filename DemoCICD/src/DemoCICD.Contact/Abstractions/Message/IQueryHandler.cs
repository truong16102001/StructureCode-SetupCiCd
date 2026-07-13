using DemoCICD.Contract.Shared;
using MediatR;

namespace DemoCICD.Contract.Asbtractions.Message;
public interface IQueryHandler<TQuery, TResponse>: IRequestHandler<TQuery, Result<TResponse>>  
    where TQuery : IQuery<TResponse>
{
}
