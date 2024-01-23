using System.ComponentModel.DataAnnotations;

namespace JeBalance.API.Admin.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Prenom is required")]
        public string? Prenom { get; set; }

        [Required(ErrorMessage = "Nom is required")]
        public string? Nom { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string? NomUtilisateur { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? MotDePasse { get; set; }
    }
}
