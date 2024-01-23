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

        private static List<Denonciation> _denonciations = new List<Denonciation>();
        private static List<Personne> _personnes = new List<Personne>();


        [HttpPost]
        public ActionResult CreateDenonciation([FromBody] DenonciationAPI denonciation)
        {
            try
            {
                var informateur = _personnes.FirstOrDefault(p => p.Nom.Value.Equals(denonciation.Informateur));

                if (informateur == null)
                {
                    _personnes.Add(denonciation.Informateur.ToPersonne());
                }
                else
                {
                    denonciation.Informateur = PersonneAPI.FromPersonne(informateur);
                }

                var suspect = _personnes.FirstOrDefault(p => p.Nom.Value.Equals(denonciation.Suspect));

                if (suspect == null)
                {
                    _personnes.Add(denonciation.Suspect.ToPersonne());
                }
                else
                {
                    denonciation.Suspect = PersonneAPI.FromPersonne(suspect);
                }
                denonciation.Date = DateTime.Now;
                Denonciation _denonciation = denonciation.ToDenonciation();
                _denonciations.Add(_denonciation);
                return Ok($"Dénonciation créée avec succès. Voici l'id : {_denonciation.Id}");
            }
            catch (Exception ex) {
                return StatusCode(500, "Une erreur s'est produite lors de la création de la dénonciation.");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<DenonciationAPI> FindDenonciationByInformateur(string id)
        {
            var denonciation = _denonciations.FirstOrDefault(d => d.Informateur.Id.ToString() == id);

            if (denonciation == null)
            {
                return NotFound("Dénonciation non trouvée pour l'informateur spécifié.");
            }

            return Ok(denonciation);
        }
    }
}
