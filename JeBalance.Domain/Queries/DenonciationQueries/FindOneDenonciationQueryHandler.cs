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
	public class FindOneDenonciationQueryHandler : IRequestHandler<FindOneDenonciationQuery, Denonciation>
	{
		private readonly IDenonciationRepository _repository;

		public FindOneDenonciationQueryHandler(IDenonciationRepository repository) => _repository = repository;

		public Task<Denonciation> Handle(FindOneDenonciationQuery query, CancellationToken cancellationToken) =>
		 _repository.GetOne(query.Id);
	}
}
