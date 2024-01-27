using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.DomainCommands.PersonneCommands
{
	public class UpdatePersonneCommandHandler : IRequestHandler<UpdatePersonneCommand, string>
	{
		private readonly IPersonneRepository _repository;

		public UpdatePersonneCommandHandler(IPersonneRepository repository) => _repository = repository;

		public Task<string> Handle(UpdatePersonneCommand command, CancellationToken cancellationToken)
		{
			return _repository.Update(command.Id, command.Personne);
		}
	}
}
