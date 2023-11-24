using AutoMapper;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ApiTech.TechXPrime.Controllers;

[ApiController]
[Route("api/v1/technicalId/{id}/requests")]
public class TechnicalRequestsController : ControllerBase
{
    private readonly IRequestService _requestService;
    private readonly IMapper _mapper;

    public TechnicalRequestsController(IRequestService requestService, IMapper mapper)
    {
        _requestService = requestService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<RequestResource>> GetAllByMonthAsync(int id)
    {
        var requests = await _requestService.ListByTechnicalId(id);
        var resources = _mapper.Map<IEnumerable<Request>, 
            IEnumerable<RequestResource>>(requests);
        return resources;
    }
}