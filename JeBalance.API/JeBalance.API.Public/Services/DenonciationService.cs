using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Queries.DenonciationQueries;
using JeBalance.Public.API.Ressources;
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
            FindOneDenonciationQuery existingDenonciationCommand = new (denonciation.Id);
			Denonciation existingDenonciation = await _mediator.Send(existingDenonciationCommand);

			if (existingDenonciation != null)
			{
				return existingDenonciation.Id;
			}

            CreateDenonciationCommand newPersonCommand = new (DateTime.Now, denonciation.InformateurId, denonciation.SuspectId, denonciation.Delit, denonciation.PaysEvasion.Value,null);
			return await _mediator.Send(newPersonCommand);
		}

		public async Task<DenonciationAPI?> GetDenonciation(string id)
		{
            FindOneDenonciationQuery query = new (id);
			Denonciation denonciation = await _mediator.Send(query);
			return DenonciationAPI.FromDenonciation(denonciation);
		}
	}
}
