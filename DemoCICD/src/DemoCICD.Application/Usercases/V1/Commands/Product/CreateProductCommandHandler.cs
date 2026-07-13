using DemoCICD.Contract.Asbtractions.Message;
using DemoCICD.Contract.Shared;

namespace DemoCICD.Application.Usercases.V1.Commands.Product;
public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    public Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
