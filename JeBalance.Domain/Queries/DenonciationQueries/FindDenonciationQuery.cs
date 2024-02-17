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

		public FindDenonciationQuery(int limit, int offset, string? PaysEvasion, bool? estRepondu)
		{
			Pagination = (limit, offset);
			Specification = new FindDenonciationsSpecification(PaysEvasion, estRepondu);
		}
	}
}
