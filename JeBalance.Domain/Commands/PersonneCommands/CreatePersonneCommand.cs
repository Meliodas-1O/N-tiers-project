using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.DomainCommands.PersonneCommands
{
    public class CreatePersonneCommand : IRequest<int>
	{
		public Personne Personne { get; set; }
		public CreatePersonneCommand(
			string prenom,
			string nom,
			TypePersonne typePersonne,
			int nombreAvertissement,
			Adresse adresse)
		=> Personne = new Personne(prenom, nom,typePersonne, nombreAvertissement, adresse);
	}
}
