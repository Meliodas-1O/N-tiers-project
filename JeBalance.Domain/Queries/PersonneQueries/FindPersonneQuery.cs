using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.AdresseQueries;
using MediatR;

namespace JeBalance.Domain.Queries.PersonneQueries
{
	public class FindPersonneQuery : IRequest<IEnumerable<Personne>>
	{
		public (int Limit, int Offset) Pagination { get; }
		public FindPersonnesSpecification Specification { get; }

		public FindPersonneQuery(int limit, int offset, string Prenom, string Nom, TypePersonne PersonneType, string adresse)
		{
			Pagination = (limit, offset);
			Specification = new FindPersonnesSpecification(Prenom, Nom, (Enum.GetName(typeof(TypePersonne),PersonneType)), adresse);
		}
	}
}
