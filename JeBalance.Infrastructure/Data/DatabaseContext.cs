using JeBalance.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PersonneSQLite> Personnes => Set<PersonneSQLite>();
        public DbSet<DenonciationSQLite> Denonciations => Set<DenonciationSQLite>();

        public DbSet<ReponseSQLite> Reponses => Set<ReponseSQLite>();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<PersonneSQLite>()
				.HasIndex(p => new { p.Nom, p.Prenom, p.Adresse,p.TypePersonne})
				.IsUnique();
		}
	}
}
