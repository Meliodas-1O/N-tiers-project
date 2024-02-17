using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace JeBalance.API.Admin.Ressources
{
	public class PersonneAPICreation
	{
		public string Prenom { get; set; }
		public string Nom { get; set; }
		public AdresseAPI Adresse { get; set; }
        public PersonneAPICreation() { }

		public virtual Personne ToPersonne()
		{
			Adresse adresse = new(Adresse.NumeroVoie, Adresse.NomVoie, Adresse.CodePostal, Adresse.Commune);
			Personne personne = new (Prenom, Nom, TypePersonne.VIP,0, adresse);
			return personne;
		}

		public static PersonneAPICreation FromPersonne(Personne personne)
		{
			return new PersonneAPICreation
			{
				Prenom = personne.Prenom.Value,
				Nom = personne.Nom.Value,
				Adresse = new AdresseAPI
				{
					NumeroVoie = personne.Adresse.NumeroVoie.Value,
					NomVoie = personne.Adresse.NomVoie.Value,
					CodePostal = personne.Adresse.CodePostal.Value,
					Commune = personne.Adresse.NomCommune.Value,
				}
			};
		}
	}

}
