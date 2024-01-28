using JeBalance.API.Public.Services;
using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.DenonciationQueries;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.Domain.ValueObjects;
using JeBalance.DomainCommands.PersonneCommands;
using JeBalance.Public.API.Ressources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.Public.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DenonciationController : ControllerBase
    {
		private readonly PersonneService _personneService;
		private readonly DenonciationService _denonciationService;

		public DenonciationController(PersonneService personneService,DenonciationService denonciationService)
        {
			_personneService = personneService;
            _denonciationService = denonciationService;
        }
        [HttpPost]
        public async Task<ActionResult> CreateDenonciation([FromBody] DenonciationAPI denonciationApi)
        {
            Personne informateur = denonciationApi.Informateur.ToPersonne();
            Personne suspect = denonciationApi.Suspect.ToPersonne();

            if (!(informateur != null && suspect != null))
            {
                return StatusCode(500, $"Une erreur s'est produite lors du traitement de la requête. Veuillez réessayer ultérieurement");
            }
            var informateurId = await _personneService.GetOrCreatePersonId(informateur);
            var suspectId = await _personneService.GetOrCreatePersonId(suspect);

            Denonciation denonciation = new Denonciation(DateTime.Now, informateurId, suspectId, denonciationApi.delit, denonciationApi.PaysEvasion, null);

            string id = await _denonciationService.GetOrCreateDenonciation(denonciation);
            if (String.IsNullOrEmpty(id)) { 
				return StatusCode(500, $"Une erreur s'est produite lors du traitement de la requête. Veuillez réessayer ultérieurement");
		    }
			return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindDenonciation(string id)
        {
            Denonciation denonciation = await _denonciationService.GetDenonciation(id);
			if (denonciation == null)
			{
				return StatusCode(404, $"Aucune Dénonciation correspondante n'a été trouvée. Veuillez vérifier l'Id de la dénonciation ou réessayer ultérieurement");
			}
			return Ok(denonciation);
        }
	}
}
