using JeBalance.Domain.Models.Denonciation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JeBalance.Presentation.Data
{
    public class DenonciationItem
    {
        public DateTime horodatage {  get; set; }
        public ReponseItem reponse { get; set; } = null!;
        [Required(ErrorMessage = "L'Informateur est requis.")]
        public PersonneItem informateur { get; set; } = null!;
        [Required(ErrorMessage = "Le suspect est requis.")]
        public PersonneItem suspect { get; set; } = null!;
        public string paysEvasion { get; set; } = null!;
        public string Id { get; set; } = null!;
        public Delit delit { get; set; }

        public DenonciationItem(PersonneItem _informateur, PersonneItem _suspect, string _paysEvasion, Delit _delit)
        {
            informateur = _informateur;
            suspect = _suspect;
            paysEvasion = _paysEvasion;
            delit = _delit;
        }
        public DenonciationItem(PersonneItem _informateur, PersonneItem _suspect, string _paysEvasion, Delit _delit, ReponseItem reponse)
        {
            informateur = _informateur;
            suspect = _suspect;
            paysEvasion = _paysEvasion;
            delit = _delit;
            this.reponse = reponse;
        }

        public DenonciationItem() { }  


    }
}
