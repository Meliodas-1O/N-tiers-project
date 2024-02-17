using JeBalance.Domain.Commands.PersonneCommands;
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
			var existingPersonneCommand = new FindPersonneQuery(int.MaxValue, 0, personne.Prenom.Value, personne.Nom.Value, TypePersonne.NONE, personne.Adresse.Value);
			var existingPersonne = await _mediator.Send(existingPersonneCommand);

			if (existingPersonne == null || !existingPersonne.Any())
			{
				var newVIPCommand = new CreatePersonneCommand(personne.Prenom.Value, personne.Nom.Value, TypePersonne.NONE, 0, personne.Adresse);
				return await _mediator.Send(newVIPCommand);
			}
            return existingPersonne.First().Id;
        }

        public async Task<bool> EstCalomniateur(Personne personne)
		{
			return await EstTypePersonne(personne, TypePersonne.CALOMNIATEUR);
		}

		public async Task<bool> EstVIP(Personne personne)
		{
			return await EstTypePersonne(personne, TypePersonne.VIP);
		}

		private async Task<bool> EstTypePersonne(Personne personne, TypePersonne type)
		{
            FindPersonneQuery existingPersonneQuery = new (int.MaxValue, 0, personne.Prenom.Value, personne.Nom.Value, type, personne.Adresse.Value);
			IEnumerable<Personne> existingPersonne = await _mediator.Send(existingPersonneQuery);
			return existingPersonne.Any();
		}
		
		public async Task<Personne> GetOnePersonne(string id)
		{
			var query = new FindOnePersonneQuery(id);
			var personne = await _mediator.Send(query);
			return personne;
		}

		public async Task<Personne> ChangeStatus(string informateurId, TypePersonne type)
		{
			var command = new UpdateTypePersonneCommand(informateurId, type);
			var updatedVIP = await _mediator.Send(command);
			return updatedVIP;
		}
	}

}
