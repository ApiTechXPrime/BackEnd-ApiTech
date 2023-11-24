using AutoMapper;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ApiTech.TechXPrime.Controllers;

[ApiController]
[Route("api/v1/technicalId/{id}/orders")]
public class TechnicalOrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public TechnicalOrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllByMonthAsync(int id)
    {
        var orders = await _orderService.ListByTechnicalId(id);
        var resources = _mapper.Map<IEnumerable<Order>, 
            IEnumerable<OrderResource>>(orders);
        return resources;
    }
}