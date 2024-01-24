using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Public.API.Ressources
{
    public class PersonneAPI
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public AdresseAPI Address { get; set; }
        public PersonneAPI() { }

        public Personne ToPersonne()
        {
            Adresse adresse = new(Address.NumeroVoie, Address.NomVoie, Address.CodePostal, Address.Commune);
            Personne personne = new(-1234, Prenom, Nom, TypePersonne.VIP, 0, adresse);

            return personne;
        }

        public static PersonneAPI FromPersonne(Personne personne)
        {
            PersonneAPI personneApi = new()
            {
                Prenom = personne.Prenom.Value,
                Nom = personne.Nom.Value,
                Address = AdresseAPI.FromAdresse(personne.Adresse),
            };
            return personneApi;
        }
    }

}
