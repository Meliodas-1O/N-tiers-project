using JeBalance.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.ValueObjects
{
	public class PaysEvasion : SimpleValueObject<string>
	{
		private const int MIN_LENGTH = 2;
		private const int MAX_LENGTH = 20;

		public PaysEvasion(string value) : base(value)
		{
		}

		public override string Validate(string value)
		{
			var trimmedValue = value.Trim();

			if (string.IsNullOrEmpty(trimmedValue)) throw new ApplicationException("Le PaysEvasion ne peut pas etre vide");

			if (trimmedValue.Length < MIN_LENGTH) throw new ApplicationException($"Le PaysEvasion ne peut pas avoir moins de {MIN_LENGTH} caracteres");

			if (trimmedValue.Length > MAX_LENGTH) throw new ApplicationException($"Le PaysEvasion ne peut pas avoir plus de {MAX_LENGTH} caracteres");

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
