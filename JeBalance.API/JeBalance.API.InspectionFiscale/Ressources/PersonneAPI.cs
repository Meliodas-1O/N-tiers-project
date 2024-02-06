using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace JeBalance.API.InspectionFiscale.Ressources
{
    public class PersonneAPI
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public AdresseAPI Adresse { get; set; }
        public string? TypePersonne { get; set; }
        public PersonneAPI() { }

        public static PersonneAPI FromPersonne(Personne personne)
        {
            PersonneAPI personneApi = new()
            {
                Prenom = personne.Prenom.Value,
                Nom = personne.Nom.Value,
                Adresse = new AdresseAPI(personne.Adresse.NumeroVoie.Value, personne.Adresse.NomVoie.Value, personne.Adresse.CodePostal.Value, personne.Adresse.NomCommune.Value)
            };
            return personneApi;
        }
    }
}
