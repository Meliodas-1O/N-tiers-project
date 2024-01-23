using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Models.Person
{
    public class Personne : Entity
    {
        public Prenom Prenom { get; set;} = null!;
		public Nom Nom { get; set; } = null!;
		public TypePersonne TypePersonne { get; set; }
		public int NombreAvertissement { get; set; }
		public Adresse Adresse { get; set; } = null!;
		public Personne(
			string prenom,
			string nom,
			TypePersonne typePersonne,
			int nombreAvertissement,
			Adresse adresse) : base(0)
		{
			Prenom = new Prenom (prenom);
			Nom = new Nom(nom);
			TypePersonne = typePersonne;
			NombreAvertissement = nombreAvertissement;
			Adresse = adresse;
		}

		public Personne(
			int id,
			string prenom,
			string nom,
			TypePersonne typePersonne,
			int nombreAvertissement,
			Adresse adresse) : base(id)
		{
			Prenom = new Prenom(prenom);
			Nom = new Nom(nom);
			TypePersonne = typePersonne;
			NombreAvertissement = nombreAvertissement;
			Adresse = adresse;
		}

		public Personne(): base(0)
		{
		}
	}
}
