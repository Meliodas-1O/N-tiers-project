using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Reponse;


namespace JeBalance.Domain.Repository
{
	public interface IReponseRepository : Repository<DenonciationReponse>
	{
		Task SetTypeResponse(DenonciationReponse reponse);
	}
}
