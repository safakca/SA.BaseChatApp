using Microsoft.AspNetCore.Identity; 

namespace Entity.Concrete; 
public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public string ImageUrl { get; set; }
    public List<Message> Messages { get; set; }
}
