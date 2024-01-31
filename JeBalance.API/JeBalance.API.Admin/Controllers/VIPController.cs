using JeBalance.API.Admin.Authentication;
using JeBalance.API.Admin.Parameters;
using JeBalance.API.Admin.Ressources;
using JeBalance.API.Admin.Services.Models;
using JeBalance.Domain.Models.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace JeBalance.API.Admin.Controllers
{
	[Authorize(Roles = UserRole.Admin)]
	[Route("api/vip/")]
	[ApiController]
	public class VIPController : ControllerBase
	{
		private readonly IVIPService _VIPService;
        public VIPController(IVIPService vipService)
        {
			_VIPService = vipService;
		}

		[HttpGet("vip")]
		public async Task<IActionResult> Get([FromQuery] FindVIParameters parameter)
		{
			IEnumerable<Personne> vips = await _VIPService.GetAll(parameter);
			Response.Headers.Add("X-Pagination-Limit", parameter.Limit.ToString());
			Response.Headers.Add("X-Pagination-Offset", parameter.Offset.ToString());
			Response.Headers.Add("X-Pagination-Count", vips.Count().ToString());
			return Ok(vips);
		}

		// GET api/<VIPController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult> Get(string id)
		{
			Personne personne = await _VIPService.GetOneVIP(id);
			return Ok(PersonneAPI.FromPersonne(personne));
		}

		// POST api/<VIPController>
        [HttpPost]
		public async Task<ActionResult> Post([FromBody] PersonneAPICreation personneAPI)
		{
			try
			{
				Personne personne = personneAPI.ToPersonne();
				string id = await _VIPService.GetOrCreateVIPId(personne);
				return Ok(id);
			}
			catch (Exception ex)
			{
                string errorMessage = ex.Message;
                return BadRequest(errorMessage);
            }

		}

		// PUT api/<VIPController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(string id, [FromBody] PersonneAPICreation personneAPI)
		{
			try
			{
                Personne personne = personneAPI.ToPersonne();
                Personne updatedPersonne = await _VIPService.UpdateVIP(id, personne);
                return Ok(PersonneAPI.FromPersonne(updatedPersonne));
            }
			catch (Exception ex)
			{
                string errorMessage = ex.Message;
                return BadRequest(errorMessage);
            }
        }

		[HttpPut("{id}/type")]
		public async Task<ActionResult> SetType(string id, [FromBody] UpdateStatusAPI personneAPI)
		{
			Personne updateVipId = await _VIPService.SetType(id, personneAPI.TypePersonne);
			return Ok(PersonneAPI.FromPersonne(updateVipId));
		}

		// DELETE api/<VIPController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			string deletedVIPId = await _VIPService.DeleteVIP(id);
			return Ok(deletedVIPId);
		}
	}
}
