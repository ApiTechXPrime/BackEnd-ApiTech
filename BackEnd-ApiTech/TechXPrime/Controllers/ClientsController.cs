﻿using AutoMapper;
using BackEnd_ApiTech.Shared.Extensions;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ApiTech.TechXPrime.Controllers;

[ApiController]
[Route("api/v1/clients")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;

    public ClientsController(IClientService clientService, IMapper mapper)
    {
        _clientService = clientService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ClientResource>> GetAllAsync()
    {
        var clients = await _clientService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
        return resources;
    }

    [HttpGet("email")]
    public async Task<ClientResource> GetClientByEmailAsync(string email)
    {
        var client = await _clientService.FindByEmailAsync(email);
        var resource = _mapper.Map<Client, ClientResource>(client);
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var client = _mapper.Map<SaveClientResource, Client>(resource);
        var result = await _clientService.SaveAsync(client);
        if (!result.Success)
            return BadRequest(result.Message);
        var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
        return Ok(clientResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var client = _mapper.Map<SaveClientResource ,Client>(resource);
        var result = await _clientService.UpdateAsync(id, client);
        if (!result.Success)
            return BadRequest(result.Message);
        var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
        return Ok(clientResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _clientService.DeleteAsync(id);
        if (!result.Success)
            BadRequest(result.Message);
        var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
        return Ok(clientResource);
    }
}