using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Command.AdresseCommands{
	public class DeleteAdresseCommand : IRequest<bool>
	{
		public int Id { get; }
		public DeleteAdresseCommand(int id) => Id = id;

	}
}
