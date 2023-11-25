using AutoMapper;
using BackEnd_ApiTech.Shared.Extensions;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ApiTech.TechXPrime.Controllers;

[ApiController]
[Route("api/v1/requests")]
public class RequestsController : ControllerBase
{
    private readonly IRequestService _requestService;
    private readonly IMapper _mapper;

    public RequestsController(IRequestService requestService, IMapper mapper)
    {
        _requestService = requestService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<RequestResource>> GetAllAsync()
    {
        var requests = await _requestService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Request>,
            IEnumerable<RequestResource>>(requests);
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<RequestResource> GetByIdAsync(int id)
    {
        var request = await _requestService.FindById(id);
        var resource = _mapper.Map<Request, RequestResource>(request);
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody]
        SaveRequestResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var request = _mapper.Map<SaveRequestResource, Request>(resource);
        var result = await _requestService.SaveAsync(request);
        if (!result.Success)
            return BadRequest(result.Message);
        var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);
        return Ok(requestResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _requestService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);
        return Ok(requestResource);
    }
}