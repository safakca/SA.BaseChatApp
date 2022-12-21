using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities;

public class AppRole : IdentityRole<int>
{
    public string RoleName { get; set; }
}
