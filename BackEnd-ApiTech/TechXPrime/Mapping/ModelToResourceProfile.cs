using AutoMapper;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Resources;

namespace BackEnd_ApiTech.TechXPrime.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Analytic, AnalyticResource>();
        CreateMap<Order, OrderResource>();
        CreateMap<Request, RequestResource>();
        CreateMap<Technical, TechnicalResource>();
    }
}