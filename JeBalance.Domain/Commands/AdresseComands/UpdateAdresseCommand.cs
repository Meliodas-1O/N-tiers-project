using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Command.AdresseCommands{
	public class UpdateAdresseCommand : IRequest<int>
	{
		public int Id { get; }
		public Adresse Adresse { get; }

		public UpdateAdresseCommand(int id, int NumeroVoie, string NomVoie, int CodePostal, string NomCommune)
		{
			Id = id;
			Adresse = new Adresse(NumeroVoie, NomVoie, CodePostal, NomCommune);
		}
	}
}
