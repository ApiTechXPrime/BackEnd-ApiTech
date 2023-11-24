using AutoMapper;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Resources;

namespace BackEnd_ApiTech.TechXPrime.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAnalyticResource, Analytic>();
        CreateMap<SaveOrderResource, Order>();
    }
}