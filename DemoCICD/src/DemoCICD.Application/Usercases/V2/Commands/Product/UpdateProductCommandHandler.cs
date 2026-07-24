using DemoCICD.Contract.Asbtractions.Message;
using DemoCICD.Contract.Services.V2.Product;
using DemoCICD.Contract.Shared;
using DemoCICD.Domain.Abstractions;
using DemoCICD.Domain.Abstractions.Repositories;
using DemoCICD.Domain.Exceptions;
using DemoCICD.Persistence;
using MediatR;

namespace DemoCICD.Application.Usercases.V2.Commands.Product;
public sealed class UpdateProductCommandHandler : ICommandHandler<Command.UpdateProductCommand>
{
    private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepository;

    private readonly IUnitOfWork _unitOfWork; // SQL-SERVER-STRATEGY-2

    private readonly ApplicationDbContext _context; // SQL-SERVER-STRATEGY-1

    private readonly IPublisher _publisher;

    public UpdateProductCommandHandler(IRepositoryBase<Domain.Entities.Product, Guid> productRepository, ApplicationDbContext applicationDb, IUnitOfWork unitOfWork, IPublisher publisher)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _context = applicationDb;
        _publisher = publisher;
    }

    public async Task<Result> Handle(Command.UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.Id) ?? throw new ProductException.ProductNotFoundException(request.Id);

        product.Update(request.Name, request.Price, request.Description);

        // Send email
        await _publisher.Publish(new DomainEvent.ProductUpdated(product.Id), cancellationToken);

        return Result.Success();
    }
}
