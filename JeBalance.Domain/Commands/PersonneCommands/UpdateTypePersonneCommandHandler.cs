using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Repository;
using JeBalance.DomainCommands.PersonneCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.PersonneCommands
{
	public class UpdateTypePersonneCommandHandler : IRequestHandler<UpdateTypePersonneCommand, Personne>
	{
		private readonly IPersonneRepository _repository;

		public UpdateTypePersonneCommandHandler(IPersonneRepository repository) => _repository = repository;

		public Task<Personne> Handle(UpdateTypePersonneCommand command, CancellationToken cancellationToken)
		{
			return _repository.ChangeStatus(command.Id, command.TypePersonne);
		}
	}
}
