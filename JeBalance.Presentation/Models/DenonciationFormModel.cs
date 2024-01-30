using JeBalance.Domain.Models.Denonciation;

namespace JeBalance.Presentation.Models
{
    using System.ComponentModel.DataAnnotations;

    public class DenonciationFormModel
    {
        // Propriétés pour les champs de saisie Informateur
        [Required(ErrorMessage = "Le prénom de l'informateur est requis.")]
        [StringLength(50, ErrorMessage = "Le prénom de l'informateur ne peut pas dépasser 50 caractères.")]
        public string InformateurPrenom { get; set; }

        [Required(ErrorMessage = "Le nom de l'informateur est requis.")]
        [StringLength(50, ErrorMessage = "Le nom de l'informateur ne peut pas dépasser 50 caractères.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Le nom de l'informateur ne peut pas contenir de chiffres.")]
        public string InformateurNom { get; set; }

        [Required(ErrorMessage = "Le numéro de voie de l'informateur est requis.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Le numéro de voie de l'informateur doit être un nombre entier compris entre 1 et 999.")]
        [Range(1, 999, ErrorMessage = "Le numéro de voie de l'informateur doit être compris entre 1 et 999.")]
        public int InformateurNumeroVoie { get; set; }

        [Required(ErrorMessage = "Le nom de voie de l'informateur est requis.")]
        [StringLength(50, ErrorMessage = "Le nom de voie de l'informateur ne peut pas dépasser 50 caractères.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Le nom de voie de l'informateur ne peut pas contenir de chiffres.")]
        public string InformateurNomVoie { get; set; }

        [Required(ErrorMessage = "Le code postal de l'informateur est requis.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal de l'informateur doit contenir exactement 5 chiffres.")]
        public int InformateurCodePostal { get; set; }

        [Required(ErrorMessage = "La commune de l'informateur est requise.")]
        [StringLength(50, ErrorMessage = "La commune de l'informateur ne peut pas dépasser 50 caractères.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "La commune de l'informateur ne peut pas contenir de chiffres.")]
        public string InformateurNomCommune { get; set; }

        [Required(ErrorMessage = "Le prénom du suspect est requis.")]
        [StringLength(50, ErrorMessage = "Le prénom du suspect ne peut pas dépasser 50 caractères.")]
        public string SuspectPrenom { get; set; }

        [Required(ErrorMessage = "Le nom du suspect est requis.")]
        [StringLength(50, ErrorMessage = "Le nom du suspect ne peut pas dépasser 50 caractères.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Le nom du suspect ne peut pas contenir de chiffres.")]
        public string SuspectNom { get; set; }

        [Required(ErrorMessage = "Le numéro de voie du suspect est requis.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Le numéro de voie du suspect doit être un nombre entier compris entre 1 et 999.")]
        [Range(1, 999, ErrorMessage = "Le numéro de voie du suspect doit être compris entre 1 et 999.")]
        public int SuspectNumeroVoie { get; set; }

        [Required(ErrorMessage = "Le nom de voie du suspect est requis.")]
        [StringLength(50, ErrorMessage = "Le nom de voie du suspect ne peut pas dépasser 50 caractères.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Le nom de voie du suspect ne peut pas contenir de chiffres.")]
        public string SuspectNomVoie { get; set; }

        [Required(ErrorMessage = "Le code postal du suspect est requis.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal du suspect doit contenir exactement 5 chiffres.")]
        public int SuspectCodePostal { get; set; }

        [Required(ErrorMessage = "La commune du suspect est requise.")]
        [StringLength(50, ErrorMessage = "La commune du suspect ne peut pas dépasser 50 caractères.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "La commune du suspect ne peut pas contenir de chiffres.")]
        public string SuspectNomCommune { get; set; }

        // Propriétés pour les autres champs du formulaire
        [Required(ErrorMessage = "Le délit est requis")]
        public Delit Delit { get; set; }

        // PaysEvasion n'est pas requis
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s]{2,50}$", ErrorMessage = "Le pays d'évasion doit contenir uniquement des lettres et être compris entre 2 et 50 caractères.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le pays d'évasion doit être compris entre 2 et 50 caractères.")]
        public string PaysEvasion { get; set; }
        public string Id { get; set; }
        public string ErreurMessage { get; set; }

    }

}
