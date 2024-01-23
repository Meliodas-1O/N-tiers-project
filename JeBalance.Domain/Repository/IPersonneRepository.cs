using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;


namespace JeBalance.Domain.Repository
{
	public interface IPersonneRepository : Repository<Personne>
	{
		Task SetAdresse(Adresse adresse);
	}
}
