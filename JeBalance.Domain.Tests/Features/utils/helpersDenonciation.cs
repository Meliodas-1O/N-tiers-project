using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Tests.Features.utils
{
	public class helpersDenonciation
	{
		public Adresse Adresse { get; private set; }
		public Personne Informateur { get; private set; }
		public Personne Suspect { get; private set; }
		public Denonciation Denonciation { get; private set; }

		public helpersDenonciation(
			string updatedHorodatage,
			string updatedInformateurFirstName,
			string updatedInformateurLastName,
			string updatedInformateurType,
			int updatedInformateurWarningCount,
			int updatedInformateurStreetNumber,
			string updatedInformateurStreetName,
			int updatedInformateurPostalCode,
			string updatedInformateurCommune,
			string updatedSuspectFirstName,
			string updatedSuspectLastName,
			string updatedSuspectType,
			int updatedSuspectWarningCount,
			int updatedSuspectStreetNumber,
			string updatedSuspectStreetName,
			int updatedSuspectPostalCode,
			string updatedSuspectCommune,
			string updatedDelit,
			string updatedPaysEvasion)
		{
			Adresse = new Adresse(
				numeroVoie: updatedInformateurStreetNumber,
				nomVoie: updatedInformateurStreetName,
				codePostal: updatedInformateurPostalCode,
				nomCommune: updatedInformateurCommune);

			Informateur = new Personne(
				prenom: updatedInformateurFirstName,
				nom: updatedInformateurLastName,
				typePersonne: Enum.Parse<TypePersonne>(updatedInformateurType),
				nombreAvertissement: updatedInformateurWarningCount,
				adresse: Adresse);

			Suspect = new Personne(
				prenom: updatedSuspectFirstName,
				nom: updatedSuspectLastName,
				typePersonne: Enum.Parse<TypePersonne>(updatedSuspectType),
				nombreAvertissement: updatedSuspectWarningCount,
				adresse: new Adresse(
					numeroVoie: updatedSuspectStreetNumber,
					nomVoie: updatedSuspectStreetName,
					codePostal: updatedSuspectPostalCode,
					nomCommune: updatedSuspectCommune));

			Denonciation = new Denonciation(
				horodatage: DateTime.Parse(updatedHorodatage),
				informateur: Informateur,
				suspect: Suspect,
				delit: Enum.Parse<Delit>(updatedDelit),
				paysEvasion: updatedPaysEvasion,
				reponse: null);
		}
	}
}
