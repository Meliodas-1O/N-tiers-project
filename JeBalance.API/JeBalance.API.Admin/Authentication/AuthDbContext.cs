using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.API.Admin.Authentication;
public class AuthDbContext : IdentityDbContext<AdminUser>
{
	public AuthDbContext()
	{
	}

	public AuthDbContext(DbContextOptions<DbContext> options)
	: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.HasDefaultSchema("auth");
		base.OnModelCreating(builder);
	}
}
