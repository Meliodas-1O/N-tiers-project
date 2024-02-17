using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
	public class SetReponseCommand : IRequest<Denonciation>
	{
		public string Id { get; }
		public string ReponseId { get; }

		public SetReponseCommand(string id,string reponseId)
		{
			Id = id;
			ReponseId = reponseId;
		}
	}
}
