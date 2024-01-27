using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
	public class UpdateDenonciationCommand : IRequest<string>
	{
		public string Id { get; }
		public Denonciation Denonciation { get; }
		public UpdateDenonciationCommand(string id,
			DateTime horodatage,
			string informateur,
			string suspect,
			Delit delit,
			string paysEvasion,
			DenonciationReponse? reponse)
		{
			Id = id;
			Denonciation = new Denonciation(horodatage, informateur, suspect, delit, paysEvasion, reponse?.DenonciationId);
		}
	}
}
