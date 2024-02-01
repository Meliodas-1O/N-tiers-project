using JeBalance.API.InspectionFiscale.Models;
using JeBalance.Domain.Models.Denonciation;
using System.Globalization;

namespace JeBalance.API.InspectionFiscale.Ressources
{
    public class DenonciationAPI
    {
        public string Horodatage { get; set; }
        public string? Id { get; set; }
        public PersonneAPI Informateur { get; set; }
        public PersonneAPI Suspect { get; set; }
        public string PaysEvasion { get; set; } = null!;
        public Delit Delit { get; set; }
        public DenonciationAPI() { }

        public static DenonciationAPI FromDenonciation(Denonciation denonciation)
        {
            CultureInfo culture = new ("fr-FR");

            DateTime date = denonciation.Horodatage;
            string formatedReponseTime = $"{date.ToString("dddd, dd MMMM yyyy", culture)}, {date.ToString("HH'h' mm", culture)}";

            return new DenonciationAPI
            {
                Id = denonciation.Id,
                Informateur = PersonneAPI.FromPersonne(denonciation.Informateur!),
                Suspect = PersonneAPI.FromPersonne(denonciation.Suspect!),
                Horodatage = formatedReponseTime,
                Delit = denonciation.Delit,
                PaysEvasion = denonciation.PaysEvasion.Value,
            };
        }
        public static Pagination PaginationFromDenonciations(IEnumerable<Denonciation> denonciations)
        {
            Pagination pagination = new ()
            {
                Data = denonciations.Select(d => FromDenonciation(d)),
                Length = denonciations.Count()
            };
            return pagination;
        }
    }
}
