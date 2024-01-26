using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Reponse;


namespace JeBalance.Domain.Repository
{
	public interface IDenonciationRepository : Repository<Denonciation>
	{
		Task SetReponse(DenonciationReponse newReponse);
	}
}
