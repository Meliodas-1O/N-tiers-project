using JeBalance.API.Admin.Services.Models;
using JeBalance.Domain.Commands.PersonneCommands;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Parameters;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.DomainCommands.PersonneCommands;
using MediatR;

namespace JeBalance.API.Admin.Services
{
	public class VIPService : IVIPService
    {
		private readonly IMediator _mediator;

		public VIPService(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<string> DeleteVIP(string id)
		{
			var personne = await GetOneVIP(id);
			if(personne == null)
			{
				return id;
			}
			var command = new DeletePersonneCommand(id);
			await _mediator.Send(command);
			return id;
		}

		public async Task<IEnumerable<Personne>> GetAll(IPersonneParameters parameter)
		{
			var query = new FindPersonneQuery(
				parameter.Limit <= 0 ?int.MaxValue : parameter.Limit,
				parameter.Offset,
				parameter.Prenom,
				parameter.Nom,
				TypePersonne.VIP,
				parameter.Adresse);
			var response = await _mediator.Send(query);
			return response;
		}

		public async Task<Personne> GetOneVIP(string id)
		{
			var query = new FindOneVIPQuery(id);
			var vip = await _mediator.Send(query);
			return vip;
		}

		public async Task<string> GetOrCreateVIPId(Personne personne)
		{
			var existingVIPQuery = new FindPersonneQuery(int.MaxValue, 0, personne.Prenom.Value, personne.Nom.Value, TypePersonne.VIP, personne.Adresse.Value);
			var existingVIP = await _mediator.Send(existingVIPQuery);

			if (existingVIP == null || !existingVIP.Any())
			{
				var newVIPCommand = new CreatePersonneCommand(personne.Prenom.Value, personne.Nom.Value, TypePersonne.VIP, 0, personne.Adresse);
				return await _mediator.Send(newVIPCommand);
			}

			return existingVIP.First().Id;
		}

		public async Task<Personne> SetType(string id, TypePersonne type)
		{
			var personne = await GetOneVIP(id);
			if(personne.TypePersonne == type)
			{
				return personne;
			}
			var command = new UpdateTypePersonneCommand(id, type);
			var updatedVIP = await _mediator.Send(command);
			return updatedVIP;
		}

		public async Task<Personne> UpdateVIP(string id, Personne personne)
		{
			var dbPersonne = await GetOneVIP(id);
			bool sameNom = dbPersonne.Nom.Value == personne.Nom.Value;
			bool samePrenom = dbPersonne.Prenom.Value == personne.Prenom.Value;
			bool sameAdresse = dbPersonne.Adresse.Value == personne.Adresse.Value;
			bool isSame = sameNom && samePrenom & sameAdresse;
			if (isSame)
			{
				return personne;
			}
			var command = new UpdatePersonneCommand(id, personne.Prenom.Value, personne.Nom.Value, personne.TypePersonne, personne.NombreAvertissement, personne.Adresse);
			var updatedVIP = await _mediator.Send(command);
			return updatedVIP;
		}
	}
}
