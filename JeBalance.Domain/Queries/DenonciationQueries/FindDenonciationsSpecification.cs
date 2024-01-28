using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Denonciation;
using System.Linq.Expressions;

namespace JeBalance.Domain.Queries.AdresseQueries
{
	public class FindDenonciationsSpecification : Specification<Denonciation>
	{
		private readonly string _paysEvasion;
		private readonly bool _repondu;

		public FindDenonciationsSpecification(string? PaysEvasion, bool? repondu)
		{
			_paysEvasion = PaysEvasion?.Trim() ?? string.Empty;
			_repondu = repondu ?? false;
		}

		public override Expression<Func<Denonciation, bool>> ToExpression()
		{
			return _repondu
				? denonciation => denonciation.ReponseId != null &&
								(denonciation.PaysEvasion.Equals(_paysEvasion) || _paysEvasion == string.Empty)
				: denonciation => string.IsNullOrEmpty(denonciation.ReponseId) &&
								(denonciation.PaysEvasion.Equals(_paysEvasion) || _paysEvasion == string.Empty);
		}
	}

}
