using JeBalance.API.Public.Ressources;
using JeBalance.Domain.Models.Denonciation;
using System.Text.Json.Serialization;

namespace JeBalance.Public.API.Ressources
{
    public class DenonciationAPI : DenonciationAPICreation
    {
        public ReponseAPI? Reponse { get; set; }
        public DateTime Horodatage { get; set; }

        public DenonciationAPI() { }
        public static DenonciationAPI? FromDenonciation(Denonciation denonciation)
        {
            if(denonciation == null)
            {
                return null;
            }
            return new DenonciationAPI
            {
                Id = denonciation.Id,
                Informateur = PersonneAPI.FromPersonne(denonciation.Informateur!),
                Suspect =  PersonneAPI.FromPersonne(denonciation.Suspect!),
                Reponse = denonciation.Reponse!=null ? ReponseAPI.FromReponse(denonciation.Reponse):null,
                Horodatage = denonciation.Horodatage,
                Delit = denonciation.Delit,
                PaysEvasion = denonciation.PaysEvasion.Value,
            };
        }
    }

    public class DenonciationAPICreation
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public PersonneAPI Informateur { get; set; }
        public PersonneAPI Suspect { get; set; }
        public string PaysEvasion { get; set; } = null!;
        public Delit Delit { get; set; }
        public DenonciationAPICreation() { }

        public Denonciation ToDenonciation()
        {
            Denonciation denonciation = new(DateTime.Now, (string)Informateur.Id!, (string)Suspect.Id!, Delit, PaysEvasion, null);
            return denonciation;
        }
    }
}
