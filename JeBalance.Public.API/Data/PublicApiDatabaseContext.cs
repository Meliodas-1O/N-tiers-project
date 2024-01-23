using Microsoft.EntityFrameworkCore;
using JeBalance.Domain.Models.Person;
using JeBalance.Public.API.Ressources;
using JeBalance.Domain.ValueObjects;



namespace JeBalance.Public.API.Data
{
    public class PublicApiDatabaseContext : DbContext
    {
        public DbSet<Personne> Personnes => Set<Personne>();

        public PublicApiDatabaseContext(DbContextOptions<PublicApiDatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Personne>().HasData(GetPersonnes());
        }

        private static IEnumerable<Personne> GetPersonnes()
        {
            List<Personne> informateurs = new List<Personne>
            {
                new PersonneAPI
                {
                    Prenom = "string1",
                    Nom = "string2",
                    Address = new AdresseAPI
                    {
                        NumeroVoie = 123,
                        NomVoie = "Rue de l'Example",
                        CodePostal = 45678,
                        Commune = "Cityville"
                    }
                }.ToPersonne(),
                new PersonneAPI
                {
                    Prenom = "string3",
                    Nom = "string4",
                    Address = new AdresseAPI
                    {
                        NumeroVoie = 789,
                        NomVoie = "Avenue des Exemples",
                        CodePostal = 98765,
                        Commune = "Townsville"
                    }
                }.ToPersonne()
            };
            return informateurs;
        }
    }
}
