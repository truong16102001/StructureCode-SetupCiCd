using DemoCICD.Contract.Asbtractions.Message;

namespace DemoCICD.Contract.Abstractions.Services.Product;
public static class Command
{
    public record CreateProduct(string Name, decimal Price, string Description) : ICommand;

    public record UpdateProduct(Guid Id, string Name, decimal Price, string Description) : ICommand;

    public record DeleteProduct(Guid Id) : ICommand;
}
