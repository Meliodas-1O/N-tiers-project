using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.AdresseQueries
{
	public class FindPersonnesSpecification : Specification<Personne>
	{
		private readonly string _prenom ;
		private readonly string _nom ;
		private readonly TypePersonne _typePersonne;
		private readonly int _nombreAvertissement;
		private readonly Adresse _adresse ;
		public FindPersonnesSpecification(string? Prenom, string? Nom, TypePersonne? PersonneType, int? NombreAvertissement, Adresse? Adresse)
		{
			_prenom = Prenom?.Trim()?.ToLower() ?? string.Empty;
			_nom = Nom?.Trim()?.ToLower() ?? string.Empty;
			_typePersonne = PersonneType ?? TypePersonne.NONE;
			_nombreAvertissement = NombreAvertissement ?? 0;
			_adresse = Adresse ?? new Adresse(0,"none",0,"none");
		}

		public override Expression<Func<Personne, bool>> ToExpression()
		{
			return personne =>
				(string.IsNullOrEmpty(_prenom) || personne.Prenom.Value.ToLower().Contains(_prenom)) &&
				(string.IsNullOrEmpty(_nom) || personne.Nom.Value.ToLower().Contains(_nom)) &&
				(!_typePersonne.Equals(TypePersonne.NONE) || personne.TypePersonne.Equals(_typePersonne)) &&
				(_nombreAvertissement == 0|| personne.NombreAvertissement == _nombreAvertissement) &&
				(_adresse.NomVoie.Equals("none") || (personne.Adresse != null && personne.Adresse.Id.Equals(_adresse.Id)));
		}
	}
}
