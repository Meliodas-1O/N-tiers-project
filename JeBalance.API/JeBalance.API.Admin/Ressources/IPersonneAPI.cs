using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.API.Admin.Ressources
{
	public class IPersonneAPI
	{
		public string Prenom { get; set; }
		public string Nom { get; set; }
		public IAdresseAPI Address { get; set; }
		public IPersonneAPI() { }

		public Personne ToPersonne()
		{
			Adresse adresse = new(Address.StreetNumber, Address.StreetName, Address.PostalCode, Address.CityName);
			Personne personne = new (new int(), Prenom, Nom, TypePersonne.VIP,0, adresse);

			return personne;
		}
	}

}
