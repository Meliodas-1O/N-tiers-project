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
	public class FindOnePersonneQueryHandler : IRequestHandler<FindOnePersonneQuery, Personne>
	{
		private readonly IPersonneRepository _repository;

		public FindOnePersonneQueryHandler(IPersonneRepository repository) => _repository = repository;

		public Task<Personne> Handle(FindOnePersonneQuery query, CancellationToken cancellationToken) =>
		 _repository.GetOne(query.Id);
	}
}
