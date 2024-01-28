using JeBalance.Domain.Models.Reponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.Models;
public class ReponseSQLite : DenonciationReponse
{
    [Key]
    public new string Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string Type { get; set; } = null!;
    public int Retribution { get; set; }
    [ForeignKey("Denonciation")]
    public string DenonciationId { get; set; }
    public virtual DenonciationSQLite? DenonciationSQLite { get; set; }
}
