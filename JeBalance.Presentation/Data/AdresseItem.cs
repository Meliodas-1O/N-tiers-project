namespace JeBalance.Presentation.Data
{
    using System.ComponentModel.DataAnnotations;

    public class AdresseItem
    {
        [Required(ErrorMessage = "Le numéro de voie est requis.")]
        public int numeroVoie { get; set; }

        [Required(ErrorMessage = "Le nom de voie est requis.")]
        [StringLength(2, ErrorMessage = "Le nom de voie doit contenir au moins deux lettres.", MinimumLength = 2)]
        public string nomVoie { get; set; }

        [Required(ErrorMessage = "Le code postal est requis.")]
        public int codePostal { get; set; }

        [Required(ErrorMessage = "La commune est requise.")]
        [StringLength(2, ErrorMessage = "La commune doit contenir au moins deux lettres.", MinimumLength = 2)]
        public string commune { get; set; }

        public AdresseItem(int _numeroVoie, string _nomVoie, int _codePostal, string _commune)
        {
            numeroVoie = _numeroVoie;
            nomVoie = _nomVoie;
            codePostal = _codePostal;
            commune = _commune;
        }

        public AdresseItem() { }
    }

}