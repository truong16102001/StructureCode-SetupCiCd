using DemoCICD.Contract.Asbtractions.Message;
using DemoCICD.Contract.Shared;

namespace DemoCICD.Application.Usercases.V1.Queries.Product;
public sealed class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, GetProductsResponse>
{
    public Task<Result<GetProductsResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
