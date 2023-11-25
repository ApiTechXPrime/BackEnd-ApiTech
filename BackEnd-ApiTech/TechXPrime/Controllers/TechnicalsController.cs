using AutoMapper;
using BackEnd_ApiTech.Shared.Extensions;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;
using BackEnd_ApiTech.TechXPrime.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ApiTech.TechXPrime.Controllers;

[ApiController]
[Route("api/v1/technicals")]
public class TechnicalsController : ControllerBase
{
    private readonly ITechnicalService _technicalService;
    private readonly IMapper _mapper;

    public TechnicalsController(ITechnicalService technicalService, IMapper mapper)
    {
        _technicalService = technicalService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TechnicalResource>> GetAllAsync()
    {
        var technicals = await _technicalService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Technical>,
            IEnumerable<TechnicalResource>>(technicals);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveTechnicalResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var technical = _mapper.Map<SaveTechnicalResource, Technical>(resource);
        var result = await _technicalService.SaveAsync(technical);
        if (!result.Success)
            return BadRequest(result.Message);
        var technicalResource = _mapper.Map<Technical, TechnicalResource>(result.Resource);
        return Ok(technicalResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveTechnicalResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var technical = _mapper.Map<SaveTechnicalResource, Technical>(resource);
        var result = await _technicalService.UpdateAsync(id, technical);
        if (!result.Success)
            return BadRequest(result.Message);
        var technicalResource = _mapper.Map<Technical, TechnicalResource>(result.Resource);
        return Ok(technicalResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _technicalService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var technicalResource = _mapper.Map<Technical, TechnicalResource>(result.Resource);
        return Ok(technicalResource);
    }
}