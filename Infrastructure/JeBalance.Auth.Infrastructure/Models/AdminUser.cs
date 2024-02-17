using Microsoft.AspNetCore.Identity;

namespace JeBalance.Auth.Infrastructure.Models;

public class AdminUser : IdentityUser
{
	public string AdminId { get; set; }
}
