using JeBalance.API.InspectionFiscale.Parameters;
using JeBalance.API.InspectionFiscale.Ressources;
using JeBalance.Domain.Commands.DenonciationCommands;
using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Commands.ReponseCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Queries.DenonciationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JeBalance.API.InspectionFiscale.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReponseController : ControllerBase
	{

		public readonly IMediator _mediator;

		public ReponseController(IMediator mediator)
		{
			_mediator = mediator;
		}

		// GET: api/<ValuesController>
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] FindDenonciationParameters parameter)
		{
			var denonciationQuery = new FindDenonciationQuery(
				parameter.Limit > 0 ? parameter.Limit : int.MaxValue,
				parameter.Offset,
				parameter.PaysEvasion,
				false
				);
			var denonciation = await _mediator.Send(denonciationQuery);
			return Ok(denonciation);
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ValuesController>
		[HttpPost("{denonciationId}/reponse")]
		public async Task<IActionResult> Post(string denonciationId, [FromBody] ReponseAPI reponseAPI)
		{
			var query = new FindOneDenonciationQuery(denonciationId);
			var denonciation = await _mediator.Send(query);
			if(denonciation == null)
			{
				return StatusCode(404, $"Aucune Dénonciation correspondante n'a été trouvée. Veuillez vérifier l'Id de la dénonciation ou réessayer ultérieurement");
			}
			if(denonciation.ReponseId != null)
			{
				return StatusCode(403, $"Desolé, cette dénonciation a obtenue une réponse. ");

			}
			var reponseQuery = new CreateReponseCommand(DateTime.Now, reponseAPI.Type, reponseAPI.Retribution, denonciationId);
			var reponseId = await _mediator.Send(reponseQuery);
			if(reponseId == null)
			{
				return StatusCode(500, $"Une erreur est survenue. Veuillez vérifier l'Id de la dénonciation ou réessayer ultérieurement");

			}
			var denonciationUpdateQuery = new SetReponseCommand(denonciationId, reponseId);
			Denonciation denonciationUpdate = await _mediator.Send(denonciationUpdateQuery);
			return Ok($"Réponse ajoutée à la dénonciation avec success.");
		}

	}
}
