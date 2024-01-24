using JeBalance.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.ValueObjects
{
    public class MotDePasse : SimpleValueObject<string>
    {
        private const int MIN_LENGTH = 8; 

        public MotDePasse(string value) : base(value)
        {
        }
        public MotDePasse() : base("ABCDEFGHIJK")
        {
        }

        public override string Validate(string value)
        {
            var trimmedValue = value.Trim();

            if (string.IsNullOrEmpty(trimmedValue))
            {
                throw new ApplicationException("Le mot de passe ne peut pas être vide.");
            }

            if (trimmedValue.Length < MIN_LENGTH )
            {
                throw new ApplicationException($"Le mot de passe doit etre inferieur a {MIN_LENGTH}. ");
            }

            return trimmedValue;
        }

        public override bool Equals(object obj)
        {
            return Value == (obj as MotDePasse)?.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
