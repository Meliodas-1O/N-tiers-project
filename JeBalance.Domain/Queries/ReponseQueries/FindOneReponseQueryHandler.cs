using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.ReponseQueries
{
	public class FindOneReponseQueryHandler : IRequestHandler<FindOneReponseQuery, DenonciationReponse>
	{
		private readonly IReponseRepository _repository;

		public FindOneReponseQueryHandler(IReponseRepository repository) => _repository = repository;

		public Task<DenonciationReponse> Handle(FindOneReponseQuery query, CancellationToken cancellationToken) =>
		 _repository.GetOne(query.Id);
	}
}
