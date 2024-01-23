using JeBalance.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.ValueObjects
{
    public class NomUtilisateur : SimpleValueObject<string>
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 20;

        public NomUtilisateur(string value) : base(value)
        {
        }

        public override string Validate(string value)
        {
            var trimmedValue = value?.Trim();

            if (string.IsNullOrEmpty(trimmedValue))
            {
                throw new ApplicationException("Le nom d'utilisateur ne peut pas etre vide.");
            }

            if (trimmedValue.Length < MIN_LENGTH || trimmedValue.Length > MAX_LENGTH)
            {
                throw new ApplicationException($"Le nom d'utilisateur doit avoir entre {MIN_LENGTH} et {MAX_LENGTH} caracteres.");
            }

            return trimmedValue;
        }

        public override bool Equals(object obj)
        {
            return Value == (obj as NomUtilisateur)?.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
