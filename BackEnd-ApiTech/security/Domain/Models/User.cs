using System.Text.Json.Serialization;

namespace BackEnd_ApiTech.security.Domain.Models;

public class User
{
   
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Birthday { get; set; }
    
    [JsonIgnore]
    public string Password { get; set; }
    
    [JsonIgnore]
    public string ConfirmPassword { get; set; }

}