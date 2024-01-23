using JeBalance.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.ValueObjects
{

	public class NumeroVoie : SimpleValueObject<int>
	{
		private const int MIN = 1;
		private const int MAX = 999;

		public NumeroVoie(int value) : base(value)
		{
		}

		public override int Validate(int value)
		{
			if (value < MIN) throw new ApplicationException($"le Numero de Voie ne peut pas etre inferieur a {MIN}");

			if (value > MAX) throw new ApplicationException($"Le Numero de Voie ne peut pas etre superieur a {MAX}");

			return value;
		}

		public static bool operator <(NumeroVoie a, int b) => a.Value < b;
		public static bool operator >(NumeroVoie a, int b) => a.Value > b;
		public static bool operator <=(NumeroVoie a, int b) => a.Value <= b;
		public static bool operator >=(NumeroVoie a, int b) => a.Value >= b;
		public static bool operator ==(NumeroVoie a, int b) => a.Value == b;
		public static bool operator !=(NumeroVoie a, int b) => a.Value != b;

		public override bool Equals(object? obj) => Value.Equals(obj);
		public override int GetHashCode() => Value.GetHashCode();
	}
}
