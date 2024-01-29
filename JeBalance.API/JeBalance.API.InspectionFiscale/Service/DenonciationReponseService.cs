using JeBalance.API.InspectionFiscale.Ressources;
using JeBalance.Domain.Commands.DenonciationCommands;
using JeBalance.Domain.Commands.ReponseCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Parameters;
using JeBalance.Domain.Queries.DenonciationQueries;
using JeBalance.Domain.Services;
using MediatR;

namespace JeBalance.API.InspectionFiscale.Service
{
    public class DenonciationReponseService : IDenonciationReponseService
    {
        private readonly IMediator _mediator;

        public DenonciationReponseService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<Denonciation>> GetUnansweredDenonciation(IDenonciationParameters parameter)
        {
            var denonciationQuery = new FindDenonciationQuery(
                parameter.Limit > 0 ? parameter.Limit : int.MaxValue,
                parameter.Offset,
                parameter.PaysEvasion,
                false
                );
            var denonciation = await _mediator.Send(denonciationQuery);
            return denonciation;
        }

        public async Task<Denonciation> FindDenonciation(string denonciationId)
        {
            var query = new FindOneDenonciationQuery(denonciationId);
            var denonciation = await _mediator.Send(query);
            return denonciation;
        }

        public async Task<string> CreateReponse(string  denonciationId, TypeReponse type, int retribution)
        {
            var reponseQuery = new CreateReponseCommand(DateTime.Now, type, retribution, denonciationId);
            var reponseId = await _mediator.Send(reponseQuery);
            return reponseId;
        }

        public async Task<Denonciation> SetReponseInDenonciation(string denonciationId, string reponseId)
        {
            var denonciationUpdateQuery = new SetReponseCommand(denonciationId, reponseId);
            Denonciation denonciationUpdate = await _mediator.Send(denonciationUpdateQuery);
            return denonciationUpdate;
        }

    }
}
