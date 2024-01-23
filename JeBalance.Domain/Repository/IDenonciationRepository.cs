using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Denonciation;


namespace JeBalance.Domain.Repository
{
	public interface IDenonciationRepository : Repository<Denonciation>
	{
		Task SetReponse(int DenonciationId);
	}
}
