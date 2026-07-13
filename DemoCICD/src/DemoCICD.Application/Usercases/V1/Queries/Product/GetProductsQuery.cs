using DemoCICD.Contract.Asbtractions.Message;

namespace DemoCICD.Application.Usercases.V1.Queries.Product;
public sealed class GetProductsQuery : IQuery<GetProductsResponse>
{
    public string Name {  get; set; }
}
