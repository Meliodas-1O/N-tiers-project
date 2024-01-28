using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.PersonneCommands
{
	public class UpdateTypePersonneCommand : IRequest<Personne>
	{
		public string Id { get; }
		public TypePersonne TypePersonne { get; }

		public UpdateTypePersonneCommand(
			string id,
			TypePersonne typePersonne
		)
		{
			Id = id;
			TypePersonne = typePersonne;
		}
	}
}
