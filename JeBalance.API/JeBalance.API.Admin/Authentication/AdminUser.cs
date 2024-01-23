using Microsoft.AspNetCore.Identity;

namespace JeBalance.API.Admin.Authentication
{
    public class AdminUser : IdentityUser
    {
        public int AdminId { get; set; }
    }
}
