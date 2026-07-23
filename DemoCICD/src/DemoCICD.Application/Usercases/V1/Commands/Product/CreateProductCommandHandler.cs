using DemoCICD.Contract.Asbtractions.Message;
using DemoCICD.Contract.Services.Product;
using DemoCICD.Contract.Shared;
using DemoCICD.Domain.Abstractions;
using DemoCICD.Domain.Abstractions.Repositories;
using DemoCICD.Persistence;
using MediatR;

namespace DemoCICD.Application.Usercases.V1.Commands.Product;
public sealed class CreateProductCommandHandler : ICommandHandler<Command.CreateProductCommand>
{
    private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepository;

    private readonly IUnitOfWork _unitOfWork; // SQL-SERVER-STRATEGY-2

    private readonly ApplicationDbContext _context; // SQL-SERVER-STRATEGY-1

    private readonly IPublisher _publisher;

    public CreateProductCommandHandler(IRepositoryBase<Domain.Entities.Product, Guid> productRepository, 
        ApplicationDbContext applicationDb, IUnitOfWork unitOfWork, IPublisher publisher)

    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _context = applicationDb;
        _publisher = publisher;
    }

    public async Task<Result> Handle(Command.CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Domain.Entities.Product.CreateProduct(Guid.NewGuid(), request.Name, request.Price, request.Description);

        _productRepository.Add(product);

        //await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _context.SaveChangesAsync();

        // Try to get product ID
        var productCreated = await _productRepository.FindByIdAsync(product.Id);

        var productSecond = Domain.Entities.Product.CreateProduct(Guid.NewGuid(),
            productCreated.Name + " Second",
            productCreated.Price,
            productCreated.Id.ToString());

        _productRepository.Add(productSecond);

        await _context.SaveChangesAsync();

        // Send email
        await _publisher.Publish(new DomainEvent.ProductCreated(productSecond.Id), cancellationToken);

        return Result.Success();
    }
}
