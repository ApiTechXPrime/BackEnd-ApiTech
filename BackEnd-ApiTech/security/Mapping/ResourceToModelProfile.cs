using AutoMapper;
using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.security.Services.Communication;

namespace BackEnd_ApiTech.security.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) &&
                        string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
            ));
    }
}