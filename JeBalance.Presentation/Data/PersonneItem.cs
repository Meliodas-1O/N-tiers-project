using System.ComponentModel.DataAnnotations;

namespace JeBalance.Presentation.Data
{
    public class PersonneItem
    {
        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(2, ErrorMessage = "Le prénom doit contenir au moins deux lettres.", MinimumLength = 2)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(2, ErrorMessage = "Le nom doit contenir au moins deux lettres.", MinimumLength = 2)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "L'adresse est requise.")]
        public AdresseItem Adresse { get; set; }

        public PersonneItem(string prenom, string nom, AdresseItem adresse)
        {
            Prenom = prenom;
            Nom = nom;
            Adresse = adresse;
        }
        public PersonneItem() { }
    }

}
