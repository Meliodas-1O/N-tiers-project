using JeBalance.Domain.Models.Denonciation;
using System.Text.Json.Serialization;

namespace JeBalance.Public.API.Ressources
{
    public class DenonciationAPI
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public PersonneAPI Informateur { get; set; }
        public PersonneAPI Suspect { get; set; }
        public string PaysEvasion { get; set; } = null!;
        public Delit delit { get; set; }

        public DenonciationAPI() { }

        public Denonciation ToDenonciation()
        {
            Denonciation denonciation = new (DateTime.Now, (string)Informateur.Id!, (string)Suspect.Id!, delit, PaysEvasion,null);
            return denonciation;
        }
    }
}
