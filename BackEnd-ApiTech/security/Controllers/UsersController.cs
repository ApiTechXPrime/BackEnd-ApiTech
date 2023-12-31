﻿using AutoMapper;
using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.security.Domain.Services.Communication;
using BackEnd_ApiTech.security.Resources;
using BackEnd_ApiTech.security.Services.Communication;
using BackEnd_ApiTech.security.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_ApiTech.security.Controllers;
[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]

public class UsersController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    
    

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest
        request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>,
            IEnumerable<UserResources>>(users);
        return Ok(resources);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResources>(user);
        return Ok(resource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }




}