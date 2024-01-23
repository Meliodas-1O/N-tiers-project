using JeBalance.Domain.Models.Reponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.ReponseQueries
{
    public class FindOneReponseQuery : IRequest<DenonciationReponse>
	{
		public int Id { get; }

		public FindOneReponseQuery(int id) => Id = id;
	}
}
