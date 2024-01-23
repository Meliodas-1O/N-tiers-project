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
		public int Id { get; }
		public DeleteDenonciationCommand(int id) => Id = id;
	}
}
