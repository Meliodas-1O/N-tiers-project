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
	public class FindVIPQuery : IRequest<IEnumerable<Personne>>
	{
		public FindVIPQuery()
		{
		}
	}
}
