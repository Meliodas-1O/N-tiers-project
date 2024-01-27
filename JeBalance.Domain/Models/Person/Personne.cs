using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
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
			Adresse adresse) : base("0")
		{
			Prenom = new Prenom (prenom);
			Nom = new Nom(nom);
			TypePersonne = typePersonne;
			NombreAvertissement = nombreAvertissement;
			Adresse = adresse;
			Id = CalculateHash(Prenom.Value, Nom.Value, Adresse.Value);

		}

		public Personne(
			string prenom,
			string nom,
			int nombreAvertissement,
			Adresse adresse) : base("0")
		{
			Prenom = new Prenom(prenom);
			Nom = new Nom(nom);
			NombreAvertissement = nombreAvertissement;
			Adresse = adresse;
			Id = CalculateHash(Prenom.Value, Nom.Value, Adresse.Value);

		}

		public Personne(
			string id,
			string prenom,
			string nom,
			TypePersonne typePersonne,
			int nombreAvertissement,
			Adresse adresse) : base(id)
		{
			Id = id;
			Prenom = new Prenom(prenom);
			Nom = new Nom(nom);
			TypePersonne = typePersonne;
			NombreAvertissement = nombreAvertissement;
			Adresse = adresse;
			Id = CalculateHash(Prenom.Value, Nom.Value, Adresse.Value);

		}

		public Personne(): base("0")
		{
		}

		private string CalculateHash(params string[] values)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				string combinedValues = string.Join("", values);
				byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedValues));
				StringBuilder stringBuilder = new StringBuilder();
				foreach (byte b in hashedBytes)
				{
					stringBuilder.Append(b.ToString("x2"));
				}

				return stringBuilder.ToString();
			}
		}
	}
}
