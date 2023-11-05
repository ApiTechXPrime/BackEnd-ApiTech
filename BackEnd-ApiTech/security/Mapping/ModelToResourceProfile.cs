using AutoMapper;
using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.security.Resources;
using BackEnd_ApiTech.security.Services.Communication;

namespace BackEnd_ApiTech.security.Mapping;
public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResources>();
    }
}