using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Parameters;
using System.Text.Json.Serialization;

namespace JeBalance.API.Admin.Parameters;
public class FindVIParameters : IParameters
{
	public int Limit { get; set; }

	public int Offset { get; set; }
	public string? Prenom { get; set; }
	public string? Nom { get; set; }
	public string? Adresse { get; set; }
	public FindVIParameters()
	{
	}
}
