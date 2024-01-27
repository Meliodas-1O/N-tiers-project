using Microsoft.AspNetCore.Identity;

namespace JeBalance.API.Admin.Authentication;

public class AdminUser : IdentityUser
{
    public string AdminId { get; set; }
}
