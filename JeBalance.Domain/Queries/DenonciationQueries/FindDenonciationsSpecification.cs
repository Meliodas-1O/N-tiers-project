﻿using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
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
	public class FindDenonciationsSpecification : Specification<Denonciation>
	{
		private readonly DateTime? _horodatage;
		private readonly Personne _informateur;
		private readonly Personne _suspect;
		private readonly Delit _delit;
		private readonly string _paysEvasion;
		private readonly TypeReponse _reponseType;

		public FindDenonciationsSpecification(DateTime? Horodatage, Personne? Informateur, Personne? Suspect, Delit? delit, PaysEvasion? PaysEvasion, TypeReponse? ReponseType)
		{
			_horodatage = Horodatage;
			_informateur = Informateur;
			_suspect = Suspect;
			_delit = delit ?? Delit.NONE;
			_paysEvasion = PaysEvasion?.Value?.Trim()?.ToLower();
			_reponseType = ReponseType ?? TypeReponse.NONE;
		}

		public override Expression<Func<Denonciation, bool>> ToExpression()
		{
			return denonciation =>
				(!_horodatage.HasValue || denonciation.Horodatage == _horodatage) &&
				(_informateur == null || denonciation.InformateurId == _informateur.Id) &&
				(_suspect == null || denonciation.SuspectId == _suspect.Id) &&
				(_delit.Equals(Delit.NONE) || _delit.Equals(denonciation.Delit)) &&
				(string.IsNullOrEmpty(_paysEvasion) || denonciation.PaysEvasion.Value.ToLower().Contains(_paysEvasion));
		}
	}

}
