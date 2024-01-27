using JeBalance.Domain.Models.Reponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.ReponseCommands
{
	public class UpdateReponseCommand : IRequest<string>
	{
		public string Id { get; }
		public DenonciationReponse Response { get; }

		public UpdateReponseCommand(string id, DateTime timestamp, TypeReponse type, int retribution, string denonciationId)
		{
			Id = id;
			Response = new DenonciationReponse (timestamp, type,retribution, denonciationId);
		}
	}
}
