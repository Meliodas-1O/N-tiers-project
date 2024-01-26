using JeBalance.API.Admin.Parameters;
using JeBalance.API.Admin.Ressources;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.DomainCommands.PersonneCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JeBalance.API.Admin.Controllers
{
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

			var query = new FindPersonneQuery(
				parameters.Limit, 
				parameters.Offset,
				parameters.Prenom,
				parameters.Nom,
				parameters.TypePersonne,
				parameters.NombreAvertissement
				);
			var response = await _mediator.Send(query);
			Response.Headers.Add("X-Pagination-Limit", parameters.Limit.ToString());
			Response.Headers.Add("X-Pagination-Offset", parameters.Offset.ToString());
			Response.Headers.Add("X-Pagination-Count", response.Count().ToString());
			return Ok(response);
		}
		// GET api/<VIPController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult> Get(int id)
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
		public async Task<ActionResult> Put(int id, [FromBody] PersonneAPI personneAPI)
		{
			Personne personne = personneAPI.ToPersonne();
			var command = new UpdatePersonneCommand(id,personne.Prenom.Value, personne.Nom.Value, personne.TypePersonne, personne.NombreAvertissement, personne.Adresse);
			await _mediator.Send(command);
			return Ok(id);
		}

		// DELETE api/<VIPController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeletePersonneCommand(id);
			await _mediator.Send(command);
			return Ok(id);
		}
	}
}
