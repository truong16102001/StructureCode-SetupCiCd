using AutoMapper;
using DemoCICD.Contract.Abstractions.Services.Product;
using DemoCICD.Contract.Asbtractions.Message;
using DemoCICD.Contract.Shared;
using DemoCICD.Domain.Abstractions.Repositories;
using DemoCICD.Domain.Exceptions;

namespace DemoCICD.Application.Usercases.V1.Queries.Product;
public sealed class GetProductByIdQueryHandler : IQueryHandler<Query.GetProductByIdQuery, Response.ProductResponse>
{
    private readonly IRepositoryBase<DemoCICD.Domain.Entities.Product, Guid> _productRepository;

    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IRepositoryBase<DemoCICD.Domain.Entities.Product, Guid> productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<Result<Response.ProductResponse>> Handle(Query.GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.Id)
           ?? throw new ProductException.ProductNotFoundException(request.Id);

        var result = _mapper.Map<Response.ProductResponse>(product);

        return Result.Success(result);
    }
}
