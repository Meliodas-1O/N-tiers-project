using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects
{

	public class CodePostal : SimpleValueObject<int>
	{
		private const int LENGTH = 5;

		public CodePostal(int value) : base(value)
		{
		}
        public CodePostal() : base(0)
        {
        }

        public override int Validate(int value)
		{
			if (value.ToString().Length != LENGTH) throw new ApplicationException($"le Code Postal doit avoir exactement {LENGTH} chiffres");

			return value;
		}

		public static bool operator <(CodePostal a, int b) => a.Value < b;
		public static bool operator >(CodePostal a, int b) => a.Value > b;
		public static bool operator <=(CodePostal a, int b) => a.Value <= b;
		public static bool operator >=(CodePostal a, int b) => a.Value >= b;
		public static bool operator ==(CodePostal a, int b) => a.Value == b;
		public static bool operator !=(CodePostal a, int b) => a.Value != b;

		public override bool Equals(object? obj) => Value.Equals(obj);
		public override int GetHashCode() => Value.GetHashCode();
	}
}
