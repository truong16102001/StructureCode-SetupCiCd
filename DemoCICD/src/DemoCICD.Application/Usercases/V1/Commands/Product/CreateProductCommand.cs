using DemoCICD.Contract.Asbtractions.Message;
namespace DemoCICD.Application.Usercases.V1.Commands.Product;
public sealed class CreateProductCommand : ICommand
{
    public string Name {  get; set; }
}
