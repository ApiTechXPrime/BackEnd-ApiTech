using AutoMapper;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ApiTech.TechXPrime.Controllers;

[ApiController]
[Route("api/v1/month/{month}/analytics")]
public class MonthAnalyticsController : ControllerBase
{
    private readonly IAnalyticService _analyticService;
    private readonly IMapper _mapper;

    public MonthAnalyticsController(IAnalyticService analyticService, IMapper mapper)
    {
        _analyticService = analyticService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AnalyticResource>> GetAllByMonthAsync(int month)
    {
        var analytics = await _analyticService.ListByMonthAsync(month);
        var resources = _mapper.Map<IEnumerable<Analytic>, 
            IEnumerable<AnalyticResource>>(analytics);
        return resources;
    }
}