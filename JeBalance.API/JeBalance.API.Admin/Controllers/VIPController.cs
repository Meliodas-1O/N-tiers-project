using JeBalance.API.Admin.Models;
using JeBalance.API.Admin.Ressources;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

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
        public static List<Personne> GenererListePersonnes()
		{
			List<Personne> personnes = new List<Personne>();
			Adresse adresse = new(42, "Rue de l'Exemple", 12345, "Ville Exemple");

			for (int i = 1; i <= 5; i++)
			{
				personnes.Add(new Personne(i, $"PrénomVIP{i}", $"NomVIP{i}", TypePersonne.VIP, 0, adresse));
			}

			for (int i = 6; i <= 15; i++)
			{
				personnes.Add(new Personne(i,$"PrénomInformateur{i}", $"NomInformateur{i}", TypePersonne.INFORMATEUR, 0, adresse));
			}

			for (int i = 16; i <= 18; i++)
			{
				personnes.Add(new Personne(i, $"PrénomSuspect{i}", $"NomSuspect{i}", TypePersonne.SUSPECT, 0, adresse));
			}

			for (int i = 19; i <= 20; i++)
			{
				personnes.Add(new Personne(i,$"PrénomCalomniateur{i}", $"NomCalomniateur{i}", TypePersonne.CALOMNIATEUR, 0, adresse));
			}

			return personnes;
		}

		List < Personne > personnes = GenererListePersonnes();

		// GET: api/<VIPController>
		[HttpGet]
        public ActionResult<IEnumerable<Personne>> Get()
        {
            return Ok(personnes);

        }
        // GET api/<VIPController>/5
        [HttpGet("{id}")]
        public ActionResult<Personne> Get(int id)
        {
            var personne = personnes.FirstOrDefault(b => b.Id == id);

            if (personne == null)
                return NotFound();

            return Ok(personne);
        }

        // POST api/<VIPController>
        [HttpPost]
		public ActionResult<Personne> Post([FromBody] PersonneAPI personneAPI)
		{

			Personne personne = personneAPI.ToPersonne();
			personnes.Add(personne);
			return CreatedAtAction(nameof(Get), new { id = personne.Id }, personne);
		}

		// PUT api/<VIPController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Personne value)
		{
			var existingPersonne = personnes.FirstOrDefault(b => b.Id == id);

			if (existingPersonne == null)
				return NotFound();

			existingPersonne.Prenom = value.Prenom;
			existingPersonne.Nom = value.Nom;
			existingPersonne.Adresse = value.Adresse;

			return NoContent();
		}

		// DELETE api/<VIPController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var book = personnes.FirstOrDefault(b => b.Id == id);

			if (book == null)
				return NotFound();

			personnes.Remove(book);

			return NoContent();
		}
	}
}
