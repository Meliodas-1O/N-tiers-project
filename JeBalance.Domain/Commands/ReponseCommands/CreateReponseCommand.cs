using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.ReponseCommands
{
	public class CreateReponseCommand : IRequest<string>
	{
		public DenonciationReponse Reponse { get; set; }
		public CreateReponseCommand(DateTime timestamp, TypeReponse type, int retribution, string denonciationId)
			=> Reponse = new DenonciationReponse(timestamp, type, retribution, denonciationId);
	}
}
