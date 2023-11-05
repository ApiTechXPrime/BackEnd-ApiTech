using System.ComponentModel.DataAnnotations;

namespace BackEnd_ApiTech.security.Services.Communication;

public class AuthenticateRequest
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}