namespace BackEnd_ApiTech.security.Resources;

public class UserResources
{
    public enum UserRole
    {
        Client,
        Technical
    }
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Birthday { get; set; }
    public UserRole Role { get; set; }
}