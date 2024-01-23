using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.ValueObjects;


namespace JeBalance.Domain.Models.Denonciation
{
    public class Denonciation : Entity
    {
        public DateTime Horodatage { get; set; }
        public Personne Informateur { get; set; } = null!;
        public Personne Suspect { get; set; } = null!;
		public Delit Delit { get; set; }
        public PaysEvasion PaysEvasion { get; set; } = null!;
		public DenonciationReponse? Reponse { get; set; }
		public Denonciation(int id, DateTime horodatage, Personne informateur, Personne suspect, Delit delit, string paysEvasion, DenonciationReponse? reponse)
			: base(id)
		{
			Horodatage = horodatage;
			Informateur = informateur;
			Suspect = suspect;
			Delit = delit;
			PaysEvasion = new PaysEvasion(paysEvasion);
			Reponse = reponse;
		}

		public Denonciation(DateTime horodatage, Personne informateur, Personne suspect, Delit delit, string paysEvasion, DenonciationReponse? reponse)
			: base(0)
		{
			Horodatage = horodatage;
			Informateur = informateur;
			Suspect = suspect;
			Delit = delit;
			PaysEvasion = new PaysEvasion(paysEvasion);
			Reponse = reponse;
		}
	}
}
