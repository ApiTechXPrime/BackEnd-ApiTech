namespace BackEnd_ApiTech.security.Services.Communication;

public class UpdateRequest
{
    public enum UserRole
    {
        Client,
        Technical
    }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Birthday { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public UserRole Role { get; set; }

}