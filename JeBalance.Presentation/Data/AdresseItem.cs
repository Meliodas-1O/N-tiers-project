namespace JeBalance.Presentation.Data
{
    using System.ComponentModel.DataAnnotations;

    public class AdresseItem
    {
        [Required(ErrorMessage = "Le numéro de voie est requis.")]
        public string NumeroVoie { get; set; }

        [Required(ErrorMessage = "Le nom de voie est requis.")]
        [StringLength(2, ErrorMessage = "Le nom de voie doit contenir au moins deux lettres.", MinimumLength = 2)]
        public string NomVoie { get; set; }

        [Required(ErrorMessage = "Le code postal est requis.")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "La commune est requise.")]
        [StringLength(2, ErrorMessage = "La commune doit contenir au moins deux lettres.", MinimumLength = 2)]
        public string Commune { get; set; }

        public AdresseItem(string numeroVoie, string nomVoie, string codePostal, string commune)
        {
            NumeroVoie = numeroVoie;
            NomVoie = nomVoie;
            CodePostal = codePostal;
            Commune = commune;
        }

        public AdresseItem() { }
    }

}