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
	public class FindVIPQueryHandler : IRequestHandler<FindVIPQuery, IEnumerable<Personne>>
	{
		private readonly IPersonneRepository _repository;

		public FindVIPQueryHandler(IPersonneRepository repository) => _repository = repository;

		public Task<IEnumerable<Personne>> Handle(FindVIPQuery query, CancellationToken cancellationToken)
		{
			return _repository.FindAllVIP();
		}
	}
}
