using JeBalance.API.Admin.Parameters;
using JeBalance.API.Admin.Ressources;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.DomainCommands.PersonneCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace JeBalance.API.Admin.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class VIPController : ControllerBase
	{
        private readonly IMediator _mediator;
        public VIPController(IMediator mediator)
        {
            _mediator = mediator;
		}

		// GET: api/<VIPController>
		[HttpGet]
        public async Task<ActionResult> Get([FromQuery] FindPersonnesParameters parameters)
        {

			var query = new FindVIPQuery();
			var response = await _mediator.Send(query);
			return Ok(response);
		}
		// GET api/<VIPController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult> Get(string id)
		{
			var query = new FindOnePersonneQuery(id);
			var place = await _mediator.Send(query);
			return Ok(place);
		}

		// POST api/<VIPController>
        [HttpPost]
		public async Task<ActionResult> Post([FromBody] PersonneAPI personneAPI)
		{
			Personne personne = personneAPI.ToPersonne();
			var command = new CreatePersonneCommand(personne.Prenom.Value, personne.Nom.Value, personne.TypePersonne, personne.NombreAvertissement, personne.Adresse);
			var id = await _mediator.Send(command);
			return Ok(id);
		}

		// PUT api/<VIPController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(string id, [FromBody] PersonneAPI personneAPI)
		{
			Personne personne = personneAPI.ToPersonne();
			var command = new UpdatePersonneCommand(id,personne.Prenom.Value, personne.Nom.Value, personne.TypePersonne, personne.NombreAvertissement, personne.Adresse);
			await _mediator.Send(command);
			return Ok(id);
		}

		// DELETE api/<VIPController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			var command = new DeletePersonneCommand(id);
			await _mediator.Send(command);
			return Ok(id);
		}
	}
}
