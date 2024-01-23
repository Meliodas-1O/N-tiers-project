using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.ValueObjects;
using JeBalance.Domain.Models.Person;

namespace JeBalance.Public.API.Ressources
{
    public class DenonciationAPI
    {
        public DateTime Date { get; set; }
        public PersonneAPI Informateur { get; set; }
        public PersonneAPI Suspect { get; set; }
        public string PaysEvasion { get; set; } = null!;
        public Delit delit { get; set; }

        public DenonciationAPI() { }

        public Denonciation ToDenonciation()
        {
            Denonciation denonciation = new Denonciation(Date, Informateur.ToPersonne(), Suspect.ToPersonne(), delit, PaysEvasion,null);
            return denonciation;
        }
    }
}
