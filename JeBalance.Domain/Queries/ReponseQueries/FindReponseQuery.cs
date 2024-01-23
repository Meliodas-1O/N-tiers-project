using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Queries.AdresseQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.ReponseQueries
{
    public class FindReponseQuery : IRequest<IEnumerable<DenonciationReponse>>
	{
		public (int Limit, int Offset) Pagination { get; }
		public FindReponsesSpecification Specification { get; }

		public FindReponseQuery(int limit, int offset, DateTime Timestamp, TypeReponse Type, int Retribution)
		{
			Pagination = (limit, offset);
			Specification = new FindReponsesSpecification(Timestamp, Type, Retribution);
		}
	}
}
