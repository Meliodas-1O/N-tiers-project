using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.ReponseQueries
{
	public class FindReponseQueryHandler : IRequestHandler<FindReponseQuery, IEnumerable<DenonciationReponse>>
	{
		private readonly IReponseRepository _repository;

		public FindReponseQueryHandler(IReponseRepository repository) => _repository = repository;
		public Task<IEnumerable<DenonciationReponse>> Handle(FindReponseQuery query, CancellationToken cancellationToken)
		{
			return _repository.Find(
				query.Pagination.Limit,
				query.Pagination.Offset,
				query.Specification);
		}
	}
}
