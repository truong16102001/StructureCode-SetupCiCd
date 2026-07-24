using AutoMapper;
using DemoCICD.Contract.Abstractions.Shared;
using DemoCICD.Domain.Entities;

namespace DemoCICD.Application.Mapper;
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Product, DemoCICD.Contract.Services.V1.Product.Response.ProductResponse>().ReverseMap();
        CreateMap<PagedResult<Product>, PagedResult<DemoCICD.Contract.Services.V1.Product.Response.ProductResponse>>().ReverseMap();
        CreateMap<Product, DemoCICD.Contract.Services.V2.Product.Response.ProductResponse>().ReverseMap();
        CreateMap<PagedResult<Product>, PagedResult<DemoCICD.Contract.Services.V2.Product.Response.ProductResponse>>().ReverseMap();
    }
}
