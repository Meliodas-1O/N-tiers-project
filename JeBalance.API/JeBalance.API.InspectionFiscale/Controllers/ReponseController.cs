﻿using JeBalance.API.InspectionFiscale.Authentication;
using JeBalance.API.InspectionFiscale.Parameters;
using JeBalance.API.InspectionFiscale.Ressources;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JeBalance.API.InspectionFiscale.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = UserRole.Inspecteur)]
    [Route("api/denonciations")]
    [ApiController]
	public class ReponseController : ControllerBase
	{

		public readonly IDenonciationReponseService _denonciationReponseService;

		public ReponseController(IDenonciationReponseService denonciationReponseService)
		{
            _denonciationReponseService = denonciationReponseService;
		}

		// GET: api/<ValuesController>
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] FindDenonciationParameters parameter)
		{
			var denonciation = await _denonciationReponseService.GetUnansweredDenonciation(parameter);
			return Ok(DenonciationAPI.PaginationFromDenonciations(denonciation));
		}

        // POST api/<ValuesController>
        [HttpPost("{denonciationId}/reponse")]
		public async Task<IActionResult> Post(string denonciationId, [FromBody] ReponseAPI reponseAPI)
		{
            try
            {
                if (reponseAPI.Type != TypeReponse.REJET && reponseAPI.Type != TypeReponse.CONFIRMATION)
                {
                    return StatusCode(400, "Desolé, vos paramètres pour délit sont invalides.");

                }
                Denonciation denonciation = await _denonciationReponseService.FindDenonciation(denonciationId);
                if (denonciation == null)
                {
                    return StatusCode(404, "Aucune Dénonciation correspondante n'a été trouvée. Veuillez vérifier l'Id de la dénonciation ou réessayer ultérieurement");
                }
                if (denonciation.ReponseId != null || denonciation.Reponse != null)
                {
                    return StatusCode(400, "Desolé, cette dénonciation a obtenue une réponse. ");

                }
                if (reponseAPI.Type == TypeReponse.REJET)
                {
                    string informateurId = denonciation.InformateurId;
                    if (denonciation.Informateur!.NombreAvertissement == 2)
                    {
                        await _denonciationReponseService.SetCalomniateurType(informateurId);
                    }
                    else
                    {
                        await _denonciationReponseService.IncreaseWarningNumber(informateurId, denonciation.Informateur!);
                    }
                }
                string reponseId = await _denonciationReponseService.CreateReponse(denonciationId, reponseAPI.Type, reponseAPI.Retribution);
                if (reponseId == null)
                {
                    return StatusCode(500, "Une erreur est survenue. Veuillez vérifier l'Id de la dénonciation ou réessayer ultérieurement");
                }

                Denonciation denonciationUpdate = await _denonciationReponseService.SetReponseInDenonciation(denonciationId, reponseId);
                if (denonciationUpdate == null)
                {
                    return StatusCode(500, "Une erreur est survenue. Veuillez vérifier l'Id de la dénonciation ou réessayer ultérieurement");
                }
                return Ok("Réponse ajoutée à la dénonciation avec success.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); 
            }

        }

	}
}
