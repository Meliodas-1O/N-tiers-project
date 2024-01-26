using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects
{

	public class Adresse : SimpleValueObject<string>
	{
		public NumeroVoie NumeroVoie { get; private set; }
		public NomVoie NomVoie { get; private set; }
		public CodePostal CodePostal { get; private set; }
		public NomCommune NomCommune { get; private set; }
		public Adresse(int numeroVoie, string nomVoie, int codePostal, string nomCommune)
			: base(BuildStringValue(numeroVoie, nomVoie, codePostal, nomCommune))
		{
			NumeroVoie =  new NumeroVoie(numeroVoie);
			NomVoie = new NomVoie(nomVoie);
			CodePostal =new CodePostal(codePostal);
			NomCommune = new NomCommune(nomCommune);
		}

		public override string Validate(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("L'adresse ne peut pas être null ou vide.");
			}
			return value;
		}

		private static string BuildStringValue(int numeroVoie, string nomVoie, int codePostal, string nomCommune)
		{
			return $"{numeroVoie} {nomVoie}, {codePostal} {nomCommune}";
		}

		public Adresse():base("12 Rue de Treize, 14015 Seize") 
		{ 
		}
	}
}
