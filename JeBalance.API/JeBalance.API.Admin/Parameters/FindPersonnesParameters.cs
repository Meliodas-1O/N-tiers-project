using JeBalance.Domain.Models.Person;
using System.Text.Json.Serialization;

namespace JeBalance.API.Admin.Parameters;
	public class FindPersonnesParameters
	{
	public int Limit { get; set; }

	public int Offset { get; set; }
	public int NombreAvertissement { get; set; }
	public string? Prenom { get; set; }
	public string? Nom { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public TypePersonne TypePersonne { get; set; }
	public FindPersonnesParameters()
	{
	}
}
