using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
	public class DeleteDenonciationCommand : IRequest<bool>
	{
		public string Id { get; }
		public DeleteDenonciationCommand(string id) => Id = id;
	}
}
