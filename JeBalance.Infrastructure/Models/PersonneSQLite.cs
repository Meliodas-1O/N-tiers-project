using JeBalance.Domain.Models.Person;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.Infrastructure.Models;

public class PersonneSQLite : Personne
{
    [Key]
    public new int Id { get; set; }
    public string Prenom { get; set; } = null!;
    public string Nom { get; set; } = null!;
    public string TypePersonne { get; set; } = null!;
    public int NombreAvertissement { get; set; }
    public string Adresse { get; set; } = null!;
}