using AutoMapper;
using DemoCICD.Contract.Abstractions.Services.Product;
using DemoCICD.Domain.Entities;

namespace DemoCICD.Application.Mapper;
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Product, Response.ProductResponse>().ReverseMap();
    }
}
