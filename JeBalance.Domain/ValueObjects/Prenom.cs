using JeBalance.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.ValueObjects
{
	public class Prenom : SimpleValueObject<string>
	{
		private const int MIN_LENGTH = 1;
		private const int MAX_LENGTH = 50;

		public Prenom(string value) : base(value)
		{
		}

		public override string Validate(string value)
		{
			var trimmedValue = value.Trim();

			if (string.IsNullOrEmpty(trimmedValue)) throw new ApplicationException("Le Prenom d'une personne ne peut pas etre vide");

			if (trimmedValue.Length > MAX_LENGTH) throw new ApplicationException($"Le Prenom d'une personne ne peut pas avoir plus de {MAX_LENGTH} caracteres");

			return trimmedValue;
		}

		public override bool Equals(object? obj)
		{
			return Value == obj?.ToString();
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Value);
		}
	}
}
