using JeBalance.Domain.Models.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.PersonneQueries
{
	public class FindOnePersonneQuery : IRequest<Personne>
	{
		public int Id { get; }

		public FindOnePersonneQuery(int id) => Id = id;
	}
}
