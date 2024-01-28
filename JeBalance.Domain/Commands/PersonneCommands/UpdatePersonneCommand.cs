using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.DomainCommands.PersonneCommands
{
    public class UpdatePersonneCommand : IRequest<Personne>
	{
		public string Id { get; }
		public Personne Personne { get; }

		public UpdatePersonneCommand(
			string id,
			string prenom,
			string nom,
			TypePersonne typePersonne,
			int nombreAvertissement,
			Adresse adresse)
		{
			Id = id;
			Personne = new Personne (prenom, nom, typePersonne, nombreAvertissement, adresse);
		}
	}
}
