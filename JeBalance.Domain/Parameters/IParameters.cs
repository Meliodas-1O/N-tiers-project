using JeBalance.Domain.Models.Person;

namespace JeBalance.Domain.Parameters
{
	public interface IParameters
	{
		int Limit { get; set; }
		int Offset { get; set; }
		string? Prenom { get; set; }
		string? Nom { get; set; }
		string? Adresse { get; set; }
	}
}
