using System.ComponentModel.DataAnnotations;

namespace BackEnd_ApiTech.security.Services.Communication;

public class RegisterRequest
{
    public enum UserRole
    {
        Client,
        Technical
    }
    
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Birthday { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
    [Required]
    public UserRole Role { get; set; }
    
}