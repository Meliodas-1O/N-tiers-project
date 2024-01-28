using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Parameters;

namespace JeBalance.API.InspectionFiscale.Parameters;
public class FindDenonciationParameters 
{
	public int Limit { get; set; }
	public int Offset { get; set; }
	public string? PaysEvasion { get; set; }
	public bool Repondu { get; set; }
	public FindDenonciationParameters() { }

}
