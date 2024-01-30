using JeBalance.Domain.Models.Denonciation;

namespace JeBalance.API.InspectionFiscale.Ressources
{
    public class DenonciationAPI
    {
        public ReponseAPI? Reponse { get; set; }
        public DateTime Horodatage { get; set; }
        public string? Id { get; set; }
        public PersonneAPI Informateur { get; set; }
        public PersonneAPI Suspect { get; set; }
        public string PaysEvasion { get; set; } = null!;
        public Delit Delit { get; set; }
        public DenonciationAPI() { }

        public Denonciation ToDenonciation()
        {
            Denonciation denonciation = new(DateTime.Now, (string)Informateur.Id!, (string)Suspect.Id!, Delit, PaysEvasion, null);
            return denonciation;
        }

        public static DenonciationAPI FromDenonciation(Denonciation denonciation)
        {
            return new DenonciationAPI
            {
                Id = denonciation.Id,
                Informateur = PersonneAPI.FromPersonne(denonciation.Informateur!),
                Suspect = PersonneAPI.FromPersonne(denonciation.Suspect!),
                Reponse = denonciation.Reponse != null ? ReponseAPI.FromReponse(denonciation.Reponse) : null,
                Horodatage = denonciation.Horodatage,
                Delit = denonciation.Delit,
                PaysEvasion = denonciation.PaysEvasion.Value,
            };
        }
    }
}
