using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.DomainCommands.PersonneCommands
{
	public class CreatePersonneCommandHandler : IRequestHandler<CreatePersonneCommand, int>
	{
	
		private readonly IPersonneRepository _repository;

		public CreatePersonneCommandHandler(IPersonneRepository repository) => _repository = repository;

		public Task<int> Handle(CreatePersonneCommand command, CancellationToken cancellationToken)
		{
			return _repository.Create(command.Personne);
		}
	}
}
