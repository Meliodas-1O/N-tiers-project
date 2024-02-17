using JeBalance.API.Public.Services;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Public.API.Ressources;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.Public.API.Controllers
{
    [ApiController]
    [Route("api/denonciations")]
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
		public async Task<ActionResult> CreateDenonciation([FromBody] DenonciationAPICreation denonciationApi)
		{
			try { 
				Personne informateur = denonciationApi.Informateur.ToPersonne();
				Personne suspect = denonciationApi.Suspect.ToPersonne();
				if (informateur == null || suspect == null)
				{
					return StatusCode(500, "Une erreur s'est produite lors du traitement de la requ�te. Les informations sur l'informateur ou le suspect sont invalides.");
				}

				bool estCalomniateur = await _personneService.EstCalomniateur(informateur);
				if (estCalomniateur)
				{
					return StatusCode(400, "Vous �tes banni de ce site et n'avez plus le droit de cr�er des d�nonciations.");
				}

				string informateurId = await _personneService.GetOrCreatePersonId(informateur);
				bool estVIP = await _personneService.EstVIP(suspect);
				if (estVIP)
				{
					Personne calomniateurInformateur = await _personneService.ChangeStatus(informateurId, TypePersonne.CALOMNIATEUR);
					if (calomniateurInformateur != null)
					{
						return StatusCode(400, "Vous �tes banni de ce site et n'avez plus le droit de cr�er des d�nonciations.");
					}
					return StatusCode(500, "Une erreur s'est produite lors du traitement de la requ�te. Veuillez r�essayer ult�rieurement.");
				}
				string suspectId = await _personneService.GetOrCreatePersonId(suspect);
				Denonciation denonciation = new(DateTime.Now, informateurId, suspectId, denonciationApi.Delit, denonciationApi.PaysEvasion, null);

				string id = await _denonciationService.GetOrCreateDenonciation(denonciation);
				if (string.IsNullOrEmpty(id))
				{
					return StatusCode(500, "Une erreur s'est produite lors du traitement de la requ�te. Veuillez r�essayer ult�rieurement.");
				}
				return Ok(id);
			}
			catch(Exception ex) {
                string errorMessage = ex.Message;
                return BadRequest(errorMessage);
            }
        } 



		[HttpGet("{id}")]
        public async Task<ActionResult> FindDenonciation(string id)
        {
            DenonciationAPI? denonciation = await _denonciationService.GetDenonciation(id);
			if (denonciation == null)
			{
				return StatusCode(404, $"Aucune D�nonciation correspondante n'a �t� trouv�e. Veuillez v�rifier l'Id de la d�nonciation ou r�essayer ult�rieurement");
			}
			return Ok(denonciation);
        }
	}
}
