using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.DomainCommands.PersonneCommands;
using MediatR;

namespace JeBalance.API.Public.Services
{
	public class PersonneService
	{
		private readonly IMediator _mediator;

		public PersonneService(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<string> GetOrCreatePersonId(Personne personne)
		{
			var existingPersonneCommand = new FindOnePersonneQuery(personne.Id);
			var existingPersonne = await _mediator.Send(existingPersonneCommand);

			if (existingPersonne != null)
			{
				return existingPersonne.Id;
			}

			var newPersonCommand = new CreatePersonneCommand(personne.Prenom.Value, personne.Nom.Value, TypePersonne.NONE, 0, personne.Adresse);
			return await _mediator.Send(newPersonCommand);
		}
	}

}
