using DemoCICD.Contract.Asbtractions.Message;
using static DemoCICD.Contract.Abstractions.Services.Product.Response;

namespace DemoCICD.Contract.Abstractions.Services.Product;
public static class Query
{
    public record GetProducts() : IQuery<List<ProductResponse>>;

    public record GetProductById(Guid Id) : IQuery<ProductResponse>;
}
