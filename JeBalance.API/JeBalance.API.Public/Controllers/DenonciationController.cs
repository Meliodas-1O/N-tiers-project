using JeBalance.API.Public.Services;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Public.API.Ressources;
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

			if (informateur == null || suspect == null)
			{
				return StatusCode(500, "Une erreur s'est produite lors du traitement de la requête. Les informations sur l'informateur ou le suspect sont invalides.");
			}

			bool estCalomniateur = await _personneService.EstCalomniateur(informateur);
			if (estCalomniateur)
			{
				return StatusCode(403, "Vous êtes banni de ce site et n'avez plus le droit de créer des dénonciations.");
			}

			string informateurId = await _personneService.GetOrCreatePersonId(informateur);
			bool estVIP = await _personneService.EstVIP(suspect);
			if (estVIP)
			{
				Personne calomniateurInformateur = await _personneService.ChangeStatus(informateurId, TypePersonne.CALOMNIATEUR);
				if (calomniateurInformateur != null)
				{
					return StatusCode(403, "Vous êtes banni de ce site et n'avez plus le droit de créer des dénonciations.");
				}
				return StatusCode(500, "Une erreur s'est produite lors du traitement de la requête. Veuillez réessayer ultérieurement.");
			}
			string suspectId = await _personneService.GetOrCreatePersonId(suspect);
			Denonciation denonciation = new (DateTime.Now, informateurId, suspectId, denonciationApi.delit, denonciationApi.PaysEvasion, null);

			string id = await _denonciationService.GetOrCreateDenonciation(denonciation);
			if (string.IsNullOrEmpty(id))
			{
				return StatusCode(500, "Une erreur s'est produite lors du traitement de la requête. Veuillez réessayer ultérieurement.");
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
