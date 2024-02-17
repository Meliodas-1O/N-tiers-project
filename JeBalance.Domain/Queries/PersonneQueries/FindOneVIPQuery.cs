using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.AdresseQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.PersonneQueries
{
	public class FindOneVIPQuery : IRequest<Personne>
	{
		public string Id { get; }
		public FindOneVIPQuery(string id) => Id = id;
	}
}
