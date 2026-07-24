using DemoCICD.Contract.Asbtractions.Message;
using DemoCICD.Contract.Services.V2.Product;
using DemoCICD.Contract.Shared;
using DemoCICD.Domain.Abstractions;
using DemoCICD.Domain.Abstractions.Repositories;
using DemoCICD.Domain.Exceptions;
using DemoCICD.Persistence;
using MediatR;

namespace DemoCICD.Application.Usercases.V2.Commands.Product;
public sealed class DeleteProductCommandHandler : ICommandHandler<Command.DeleteProductCommand>
{
    private readonly IRepositoryBase<Domain.Entities.Product, Guid> _productRepository;

    private readonly IUnitOfWork _unitOfWork; // SQL-SERVER-STRATEGY-2

    private readonly ApplicationDbContext _context; // SQL-SERVER-STRATEGY-1

    private readonly IPublisher _publisher;

    public DeleteProductCommandHandler(IRepositoryBase<Domain.Entities.Product, Guid> productRepository, IUnitOfWork unitOfWork, IPublisher publisher, ApplicationDbContext context)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _context = context;
        _publisher = publisher;
    }

    public async Task<Result> Handle(Command.DeleteProductCommand request, CancellationToken cancellationToken)
    {

        var product = await _productRepository.FindByIdAsync(request.Id) ?? throw new ProductException.ProductNotFoundException(request.Id); // Solution 1
        //var product = await _productRepository.FindSingleAsync(x => x.Id.Equals(request.Id)) ?? throw new ProductException.ProductNotFoundException(request.Id); // Solution 2

        _productRepository.Remove(product);

        // Send Email
        await _publisher.Publish(new DomainEvent.ProductDeleted(product.Id), cancellationToken);

        return Result.Success();
    }
}
