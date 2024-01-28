using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.API.Admin.Ressources
{
	public class PersonneAPI : PersonneAPICreation
	{
		public string Id { get; set; }
		public PersonneAPI() { }

		public override Personne ToPersonne()
		{
			Adresse adresse = new (Adresse.NumeroVoie, Adresse.NomVoie, Adresse.CodePostal, Adresse.Commune);
			Personne personne = new (Id, Prenom, Nom, TypePersonne.VIP, 0, adresse);;
			return personne;
		}

		public static new PersonneAPI FromPersonne(Personne personne)
		{
			return new PersonneAPI
			{
				Id = personne.Id,
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
