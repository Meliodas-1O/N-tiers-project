using JeBalance.Domain.ValueObjects;
using MediatR;

namespace JeBalance.Domain.Commands.AdresseCommands
{
	public class CreateAdresseCommand : IRequest<int>
	{
		public Adresse Adresse { get; }

		public CreateAdresseCommand(int NumeroVoie,string NomVoie,int CodePostal, string NomCommune) 
			=> Adresse = new Adresse(NumeroVoie, NomVoie, CodePostal, NomCommune);
	}

}
