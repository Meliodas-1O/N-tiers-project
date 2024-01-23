using JeBalance.Domain.Models.Reponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.ReponseCommands
{
	public class UpdateReponseCommand : IRequest<int>
	{
		public int Id { get; }
		public DenonciationReponse Response { get; }

		public UpdateReponseCommand(int id, DateTime timestamp, TypeReponse type, int retribution)
		{
			Id = id;
			Response = new DenonciationReponse (timestamp, type,retribution);
		}
	}
}
