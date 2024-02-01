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
		private readonly string _typePersonne;
		private readonly string _adresse;
		public FindPersonnesSpecification(string? Prenom, string? Nom, string? PersonneType, string adresse)
		{
			_prenom = Prenom?.Trim() ?? string.Empty;
			_nom = Nom?.Trim() ?? string.Empty;
			_typePersonne = PersonneType ?? "VIP";
			_adresse = adresse?.Trim() ?? string.Empty;
		}

		public override Expression<Func<Personne, bool>> ToExpression()
		{
            return personne =>
				(personne.Prenom.Equals(_prenom) || _prenom == string.Empty) &&
				(personne.Nom.Equals(_nom) || _nom == string.Empty) &&
				( personne.TypePersonne.Equals(_typePersonne) || TypePersonne.NONE.Equals(_typePersonne))&&
				(personne.Adresse.Equals(_adresse) || _adresse == string.Empty);
				;
		}
	}
}
