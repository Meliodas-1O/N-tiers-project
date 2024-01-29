using JeBalance.Domain.Models.Denonciation;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.Presentation.Data
{
    public class DenonciationItem
    {
        [Required(ErrorMessage = "L'Informateur est requis.")]
        public PersonneItem Informateur { get; set; } = null!;
        [Required(ErrorMessage = "Le suspect est requis.")]
        public PersonneItem Suspect { get; set; } = null!;
        public string PaysEvasion { get; set; } = null!;
        public Delit delit { get; set; }

        public DenonciationItem(PersonneItem informateur, PersonneItem suspect, string paysEvasion, Delit delit)
        {
            Informateur = informateur;
            Suspect = suspect;
            PaysEvasion = paysEvasion;
            this.delit = delit;
        }
        public DenonciationItem() { }  
    }
}
