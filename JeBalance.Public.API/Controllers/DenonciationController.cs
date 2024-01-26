using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.DenonciationQueries;
using JeBalance.Public.API.Ressources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JeBalance.Public.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DenonciationController : ControllerBase
    {
        private const string INFORMATEUR_TYPE = "INFORMATEUR";
        private const string SUSPECT_TYPE = "SUSPECT";

        private readonly IMediator _mediator;
        public DenonciationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> CreateDenonciation([FromBody] DenonciationAPI denonciation)
        {
            denonciation.Informateur.TypePersonne = INFORMATEUR_TYPE;
            denonciation.Suspect.TypePersonne = SUSPECT_TYPE;
            var command = new CreateDenonciationCommand(DateTime.Now, denonciation.Informateur.ToPersonne(),denonciation.Suspect.ToPersonne(), denonciation.delit,denonciation.PaysEvasion, null);
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindDenonciation(int id)
        {
            var query = new FindOneDenonciationQuery(id);
            await _mediator.Send(query);
            return Ok(id);
        }
    }
}
