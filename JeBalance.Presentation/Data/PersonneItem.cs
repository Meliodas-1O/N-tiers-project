using System.ComponentModel.DataAnnotations;

namespace JeBalance.Presentation.Data
{
    public class PersonneItem
    {
        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(2, ErrorMessage = "Le prénom doit contenir au moins deux lettres.", MinimumLength = 2)]
        public string prenom { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(2, ErrorMessage = "Le nom doit contenir au moins deux lettres.", MinimumLength = 2)]
        public string nom { get; set; }

        [Required(ErrorMessage = "L'adresse est requise.")]
        public AdresseItem adresse { get; set; }

        public PersonneItem(string _prenom, string _nom, AdresseItem _adresse)
        {
            prenom = _prenom;
            nom = _nom;
            adresse = _adresse;
        }
        public PersonneItem() { }
    }

}
