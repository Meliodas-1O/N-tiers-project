using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.ReponseCommands
{
	public class DeleteReponseCommand : IRequest<bool>
	{
		public int Id { get; }
		public DeleteReponseCommand(int id) => Id = id;
	}
}
