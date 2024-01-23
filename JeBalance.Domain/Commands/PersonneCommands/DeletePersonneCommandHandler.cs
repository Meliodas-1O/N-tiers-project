using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.DomainCommands.PersonneCommands
{
	public class DeletePersonneCommandHandler : IRequestHandler<DeletePersonneCommand, bool>
	{
		private readonly IPersonneRepository _repository;

		public DeletePersonneCommandHandler(IPersonneRepository repository) => _repository = repository;

		public Task<bool> Handle(DeletePersonneCommand command, CancellationToken cancellationToken)
		{
			return _repository.Delete(command.Id);
		}
	}
}
