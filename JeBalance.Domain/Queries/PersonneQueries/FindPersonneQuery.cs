using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.AdresseQueries;
using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.PersonneQueries
{
	public class FindPersonneQuery : IRequest<IEnumerable<Personne>>
	{
		public (int Limit, int Offset) Pagination { get; }
		public FindPersonnesSpecification Specification { get; }

		public FindPersonneQuery(int limit, int offset, string Prenom, string Nom, TypePersonne PersonneType, int NombreAvertissement, Adresse Adresse)
		{
			Pagination = (limit, offset);
			Specification = new FindPersonnesSpecification(Prenom, Nom, PersonneType, NombreAvertissement, Adresse);
		}
	}
}
