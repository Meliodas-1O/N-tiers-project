using JeBalance.Domain.ValueObjects;
using MediatR;
using System.Xml.Linq;

namespace JeBalance.Domain.Queries.AdresseQueries
{
	public class FindAdresseQuery : IRequest<IEnumerable<Adresse>>
	{
		public (int Limit, int Offset) Pagination { get; }

		public FindAdressesSpecification Specification { get; }

		public FindAdresseQuery(int limit, int offset, int NumeroVoie, string NomVoie, int CodePostal, string NomCommune)
		{
			Pagination = (limit, offset);
			Specification = new FindAdressesSpecification(NumeroVoie, NomVoie, CodePostal, NomCommune);
		}
	}
}
