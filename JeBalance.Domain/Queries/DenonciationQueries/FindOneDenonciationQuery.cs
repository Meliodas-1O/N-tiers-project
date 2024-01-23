using JeBalance.Domain.Models.Denonciation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.DenonciationQueries
{
	public class FindOneDenonciationQuery : IRequest<Denonciation>
	{
		public int Id { get; }

		public FindOneDenonciationQuery(int id) => Id = id;
	}
}
