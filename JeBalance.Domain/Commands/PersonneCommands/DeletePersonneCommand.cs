using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.DomainCommands.PersonneCommands
{
	public class DeletePersonneCommand : IRequest<bool>
	{
		public string Id { get; }
		public DeletePersonneCommand(string id) => Id = id;
	}
}
