using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Parameters;

namespace JeBalance.API.InspectionFiscale.Parameters;
public class FindDenonciationParameters : IDenonciationParameters
{
	public int Limit { get; set; }
	public int Offset { get; set; }
	public string? PaysEvasion { get; set; }
	public FindDenonciationParameters() { }

}
