using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Parameters;
using JeBalance.Domain.Queries.PersonneQueries;

namespace JeBalance.API.Admin.Services.Models
{
	public interface IVIPService
	{
		Task<string> GetOrCreateVIPId(Personne personne);
		Task<Personne> GetOneVIP(string id);
		Task<Personne> UpdateVIP(string id, Personne personne);
		Task<Personne> SetType(string id, TypePersonne type);
		Task<string> DeleteVIP(string id);
		Task<IEnumerable<Personne>> GetAll(IParameters parameter);
	}
}
