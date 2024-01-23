using JeBalance.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.ValueObjects
{

	public class Adresse : SimpleValueObject<String>
	{
		public NumeroVoie NumeroVoie { get; private set; }
		public NomVoie NomVoie { get; private set; }
		public CodePostal CodePostal { get; private set; }
		public NomCommune NomCommune { get; private set; }
		public string Id { get; private set; }

		public Adresse(int numeroVoie, string nomVoie, int codePostal, string nomCommune)
			: base($"{numeroVoie} {nomVoie}, {codePostal} {nomCommune}")
		{
			NumeroVoie =  new NumeroVoie(numeroVoie);
			NomVoie = new NomVoie(nomVoie);
			CodePostal =new CodePostal(codePostal);
			NomCommune = new NomCommune(nomCommune);
			Id = GenerateId();
		}

		private string GenerateId()
		{
			using (MD5 md5 = MD5.Create())
			{
				string dataToHash = $"{NumeroVoie}{NomVoie}{CodePostal}{NomCommune}";

				byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(dataToHash));
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					stringBuilder.Append(hashBytes[i].ToString("x2"));
				}
				return stringBuilder.ToString();
			}
		}
		public override string Validate(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Address value cannot be empty or null.");
			}
			return value;
		}

		private static string BuildStringValue(string numeroVoie, string nomVoie, string codePostal, string nomCommune)
		{
			return $"{numeroVoie} {nomVoie}, {codePostal} {nomCommune}";
		}
	}
}
