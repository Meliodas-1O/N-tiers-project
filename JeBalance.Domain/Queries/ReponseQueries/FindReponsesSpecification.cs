using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.AdresseQueries
{
	public class FindReponsesSpecification : Specification<DenonciationReponse>
	{

		private readonly DateTime _timestamp;
		private readonly TypeReponse _type;
		private readonly int _retribution;

		public FindReponsesSpecification(DateTime? Timestamp, TypeReponse? Type, int? Retribution)
		{
			_timestamp = Timestamp ?? DateTime.MinValue;
			_type = Type ?? TypeReponse.NONE;
			_retribution = Retribution ?? 0;
		}

		public override Expression<Func<DenonciationReponse, bool>> ToExpression()
		{
			return reponse =>
				(_timestamp == DateTime.MinValue
					? reponse.Timestamp > DateTime.MinValue
					: reponse.Timestamp == _timestamp) &&
				reponse.Type == _type &&
				(_retribution == 0 ? reponse.Retribution >= 0 : reponse.Retribution == _retribution);
		}
	}
}
