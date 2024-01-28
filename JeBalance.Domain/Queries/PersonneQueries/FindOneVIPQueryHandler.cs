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
	public class FindOneVIPQueryHandler : IRequestHandler<FindOneVIPQuery, Personne>
	{
		private readonly IPersonneRepository _repository;

		public FindOneVIPQueryHandler(IPersonneRepository repository) => _repository = repository;

		public Task<Personne> Handle(FindOneVIPQuery query, CancellationToken cancellationToken) =>
			_repository.FindOneVIP(query.Id);
	}
}
