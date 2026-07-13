using AutoMapper;
using DemoCICD.Contract.Abstractions.Services.Product;
using DemoCICD.Contract.Asbtractions.Message;
using DemoCICD.Contract.Shared;
using DemoCICD.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoCICD.Application.Usercases.V1.Queries.Product;
public sealed class GetProductsQueryHandler : IQueryHandler<Query.GetProducts, List<Response.ProductResponse>>
{
    private readonly IRepositoryBase<DemoCICD.Domain.Entities.Product, Guid> _productRepository;

    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IRepositoryBase<DemoCICD.Domain.Entities.Product, Guid> productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<Result<List<Response.ProductResponse>>> Handle(Query.GetProducts request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.FindAll().ToListAsync();

        var result = _mapper.Map<List<Response.ProductResponse>>(products);
        return result;
    }
}
