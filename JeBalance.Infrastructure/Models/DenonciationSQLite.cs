using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeBalance.Infrastructure.Models;
public class DenonciationSQLite : Denonciation
{
    [Key]
    public new string Id { get; set; }
    public new DateTime Horodatage { get; set; }

	[ForeignKey("Personnes")]
	public new string InformateurId { get; set; } = null!;
	public virtual PersonneSQLite Informateur { get; set; }  

	[ForeignKey("Personnes")]
	public new string SuspectId { get; set; } = null!;
	public virtual PersonneSQLite Suspect { get; set; } 
	public new string Delit { get; set; } = null!;
    public string PaysEvasion { get; set; } = null!;
    [ForeignKey("Reponse")]
    public new string? ReponseId { get; set; }
    public virtual ReponseSQLite? Reponse { get; set; }
}
