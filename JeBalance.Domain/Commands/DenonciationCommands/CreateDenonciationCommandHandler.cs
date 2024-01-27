using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
	public class CreateDenonciationCommandHandler : IRequestHandler<CreateDenonciationCommand, string>
	{
		private readonly IDenonciationRepository _repository;

		public CreateDenonciationCommandHandler(IDenonciationRepository repository) => _repository = repository;

		public Task<string> Handle(CreateDenonciationCommand command, CancellationToken cancellationToken)
		{
			return _repository.Create(command.Denonciation);
		}
	}
}
