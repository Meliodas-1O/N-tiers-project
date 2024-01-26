using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.API.Admin.Ressources
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
			Personne personne = new (Prenom, Nom, TypePersonne.VIP,0, adresse);
			return personne;
		}
	}

}
