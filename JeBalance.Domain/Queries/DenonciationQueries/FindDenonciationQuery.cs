using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Queries.AdresseQueries;
using JeBalance.Domain.ValueObjects;
using MediatR;

namespace JeBalance.Domain.Queries.DenonciationQueries
{
	public class FindDenonciationQuery : IRequest<IEnumerable<Denonciation>>
	{
		public (int Limit, int Offset) Pagination { get; }

		public FindDenonciationsSpecification Specification { get; }

		public FindDenonciationQuery(int limit, int offset, DateTime Horodatage, Personne Informateur, Personne Suspect, Delit delit, PaysEvasion PaysEvasion, TypeReponse ReponseType)
		{
			Pagination = (limit, offset);
			Specification = new FindDenonciationsSpecification(Horodatage, Informateur, Suspect, delit, PaysEvasion, ReponseType);
		}
	}
}
