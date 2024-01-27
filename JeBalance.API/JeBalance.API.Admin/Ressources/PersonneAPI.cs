using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.API.Admin.Ressources
{
	public class PersonneAPI
	{
		public string Prenom { get; set; }
		public string Nom { get; set; }
		public AdresseAPI Adresse { get; set; }
        public PersonneAPI() { }

		public Personne ToPersonne()
		{
			Adresse adresse = new(Adresse.NumeroVoie, Adresse.NomVoie, Adresse.CodePostal, Adresse.Commune);
			Personne personne = new (Prenom, Nom, TypePersonne.VIP,0, adresse);
			return personne;
		}
	}

}
