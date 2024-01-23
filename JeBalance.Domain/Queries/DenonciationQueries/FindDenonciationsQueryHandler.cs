using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.DenonciationQueries
{
	public class FindDenonciationsQueryHandler : IRequestHandler<FindDenonciationQuery, IEnumerable<Denonciation>>
	{
		private readonly IDenonciationRepository _repository;

		public FindDenonciationsQueryHandler(IDenonciationRepository repository) => _repository = repository;

		public Task<IEnumerable<Denonciation>> Handle(FindDenonciationQuery query, CancellationToken cancellationToken)
		{
			return _repository.Find(
				query.Pagination.Limit,
				query.Pagination.Offset,
				query.Specification);
		}
	}
}
