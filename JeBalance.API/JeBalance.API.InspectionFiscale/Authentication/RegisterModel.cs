using System.ComponentModel.DataAnnotations;

namespace JeBalance.API.InspectionFiscale.Authentication;
public class RegisterModel
{
    [Required(ErrorMessage = "Le prénom est requis")]
    public string? Prénom { get; set; }

    [Required(ErrorMessage = "Le nom de famille est requis")]
    public string? Nom { get; set; }

    [Required(ErrorMessage = "Le nom d'utilisateur est requis")]
    public string? NomUtilisateur { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "L'adresse e-mail est requise")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Le mot de passe est requis")]
    public string? MotDePasse { get; set; }
    }
