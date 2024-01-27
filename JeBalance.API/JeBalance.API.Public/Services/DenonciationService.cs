using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.DenonciationQueries;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.DomainCommands.PersonneCommands;
using MediatR;

namespace JeBalance.API.Public.Services
{
	public class DenonciationService
	{
		private readonly IMediator _mediator;

		public DenonciationService(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<string> GetOrCreateDenonciation(Denonciation denonciation)
		{
			var existingDenonciationCommand = new FindOneDenonciationQuery(denonciation.Id);
			var existingDenonciation = await _mediator.Send(existingDenonciationCommand);

			if (existingDenonciation != null)
			{
				return existingDenonciation.Id;
			}

			var newPersonCommand = new CreateDenonciationCommand(DateTime.Now, denonciation.InformateurId, denonciation.SuspectId, denonciation.Delit, denonciation.PaysEvasion.Value,null);
			return await _mediator.Send(newPersonCommand);
		}

		public async Task<Denonciation> GetDenonciation(string id)
		{
			var query = new FindOneDenonciationQuery(id);
			var denonciation = await _mediator.Send(query);
			return denonciation;
		}
	}
}
