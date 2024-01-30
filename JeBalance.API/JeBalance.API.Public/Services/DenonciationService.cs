using JeBalance.API.Public.Ressources;
using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Queries.DenonciationQueries;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.Domain.Queries.ReponseQueries;
using JeBalance.DomainCommands.PersonneCommands;
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
			var existingDenonciationCommand = new FindOneDenonciationQuery(denonciation.Id);
			var existingDenonciation = await _mediator.Send(existingDenonciationCommand);

			if (existingDenonciation != null)
			{
				return existingDenonciation.Id;
			}

			var newPersonCommand = new CreateDenonciationCommand(DateTime.Now, denonciation.InformateurId, denonciation.SuspectId, denonciation.Delit, denonciation.PaysEvasion.Value,null);
			return await _mediator.Send(newPersonCommand);
		}

		public async Task<DenonciationAPI?> GetDenonciation(string id)
		{
            ReponseAPI reponseApi;
			PersonneAPI informateurApi;
			PersonneAPI suspectApi;

            FindOneDenonciationQuery query = new (id);
			var denonciation = await _mediator.Send(query);
			if (denonciation == null)
			{
				return null;
			}
			string informateurId = denonciation.InformateurId;
            FindOnePersonneQuery getInformateurQuery = new (informateurId);
            Personne informateur = await _mediator.Send(getInformateurQuery);
			if (informateur == null)
			{
				return null;
			}
            informateurApi = PersonneAPI.FromPersonne(informateur);
            string suspectId = denonciation.SuspectId;
            FindOnePersonneQuery getSuspectQuery = new (suspectId);
            Personne suspect = await _mediator.Send(getSuspectQuery);
			suspectApi = PersonneAPI.FromPersonne(suspect);
			if(suspect == null)
			{
				return null;
			}
			string reponseId;
			if (denonciation.ReponseId == null)
			{
				return DenonciationAPI.FromDenonciation(denonciation, informateurApi, suspectApi, null); ;
            }
            reponseId = denonciation.ReponseId;
            FindOneReponseQuery getReponseQuery = new (reponseId);
            DenonciationReponse reponse = await _mediator.Send(getReponseQuery);
            reponseApi = ReponseAPI.FromReponse(reponse);
            return DenonciationAPI.FromDenonciation(denonciation, informateurApi, suspectApi, reponseApi); ;
		}
	}
}
