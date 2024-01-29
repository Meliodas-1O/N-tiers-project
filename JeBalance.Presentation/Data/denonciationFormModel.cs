using JeBalance.Domain.Models.Denonciation;

namespace JeBalance.Presentation.Data
{
    using System.ComponentModel.DataAnnotations;

    public class DenonciationFormModel
    {
        // Propriétés pour les champs de saisie Informateur
        [Required(ErrorMessage = "Le prénom de l'informateur est requis")]
        public string InformateurPrenom { get; set; }

        [Required(ErrorMessage = "Le nom de l'informateur est requis")]
        public string InformateurNom { get; set; }

        [Required(ErrorMessage = "Le numéro de voie de l'informateur est requis")]
        public string InformateurNumeroVoie { get; set; }

        [Required(ErrorMessage = "Le nom de voie de l'informateur est requis")]
        public string InformateurNomVoie { get; set; }

        [Required(ErrorMessage = "Le code postal de l'informateur est requis")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres")]
        public string InformateurCodePostal { get; set; }

        [Required(ErrorMessage = "La commune de l'informateur est requise")]
        public string InformateurNomCommune { get; set; }

        // Propriétés pour les champs de saisie Suspect
        [Required(ErrorMessage = "Le prénom du suspect est requis")]
        public string SuspectPrenom { get; set; }

        [Required(ErrorMessage = "Le nom du suspect est requis")]
        public string SuspectNom { get; set; }

        [Required(ErrorMessage = "Le numéro de voie du suspect est requis")]
        public string SuspectNumeroVoie { get; set; }

        [Required(ErrorMessage = "Le nom de voie du suspect est requis")]
        public string SuspectNomVoie { get; set; }

        [Required(ErrorMessage = "Le code postal du suspect est requis")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir exactement 5 chiffres")]
        public string SuspectCodePostal { get; set; }

        [Required(ErrorMessage = "La commune du suspect est requise")]
        public string SuspectNomCommune { get; set; }

        // Propriétés pour les autres champs du formulaire
        [Required(ErrorMessage = "Le délit est requis")]
        public Delit Delit { get; set; }

        // PaysEvasion n'est pas requis
        public string PaysEvasion { get; set; }
        public string Id { get; set; }
    }

}
