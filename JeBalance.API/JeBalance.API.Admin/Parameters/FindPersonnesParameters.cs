using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Parameters;

namespace JeBalance.API.Admin.Parameters;
public class FindPersonnesParameters : IPersonneParameters
{
	public int Limit { get; set; }
	public int Offset { get; set; }
	public string? Prenom { get; set; }
	public string? Nom { get; set; }
	public TypePersonne TypePersonne { get; set; }

	public string? Adresse { get; set; }
	public FindPersonnesParameters() { }
}
