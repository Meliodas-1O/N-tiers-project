using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.AdresseQueries
{
	public class FindAdressesSpecification : Specification<Adresse>
	{

		private readonly int _numeroVoie;
		private readonly string _nomVoie;
		private readonly int _codePostal;
		private readonly string _nomCommune;

		public FindAdressesSpecification(int? NumeroVoie, string? NomVoie, int? CodePostal, string? NomCommune)
		{
			_numeroVoie = NumeroVoie ?? 0;
			_nomVoie = NomVoie?.Trim()?.ToLower();
			_codePostal = CodePostal ?? 0;
			_nomCommune = NomCommune?.Trim()?.ToLower();
		}

		public override Expression<Func<Adresse, bool>> ToExpression()
		{
			return adresse =>
				(_numeroVoie == 0 || adresse.NumeroVoie == _numeroVoie) &&
				(string.IsNullOrEmpty(_nomVoie) || adresse.NomVoie.Value.ToLower().Contains(_nomVoie)) &&
				(_codePostal == 0 || adresse.CodePostal == _codePostal) &&
				(string.IsNullOrEmpty(_nomCommune) || adresse.NomCommune.Value.ToLower().Contains(_nomCommune));
		}
	}
}
