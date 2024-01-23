using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.PersonneQueries
{
	public class FindPersonneQueryHandler : IRequestHandler<FindPersonneQuery, IEnumerable<Personne>>
	{
		private readonly IPersonneRepository _repository;

		public FindPersonneQueryHandler(IPersonneRepository repository) => _repository = repository;

		public Task<IEnumerable<Personne>> Handle(FindPersonneQuery query, CancellationToken cancellationToken)
		{
			return _repository.Find(
				query.Pagination.Limit,
				query.Pagination.Offset,
				query.Specification);
		}
	}
}
