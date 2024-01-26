using JeBalance.Domain.Models.Denonciation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeBalance.Infrastructure.Models;
public class DenonciationSQLite : Denonciation
{
    [Key]
    public new int Id { get; set; }
    public DateTime Horodatage { get; set; }
    public PersonneSQLite Informateur { get; set; } = null!;
    public PersonneSQLite Suspect { get; set; } = null!;
    public string Delit { get; set; } = null!;
    public string PaysEvasion { get; set; } = null!;
    [ForeignKey("Reponse")]
    public int? ReponseId { get; set; }
    public virtual ReponseSQLite? Reponse { get; set; }
}
