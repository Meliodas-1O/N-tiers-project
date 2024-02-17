using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
	public class UpdateDenonciationCommandHandler : IRequestHandler<UpdateDenonciationCommand, Denonciation>
	{
		private readonly IDenonciationRepository _repository;

		public UpdateDenonciationCommandHandler(IDenonciationRepository repository) => _repository = repository;

		public Task<Denonciation> Handle(UpdateDenonciationCommand command, CancellationToken cancellationToken)
		{
			return _repository.Update(command.Id, command.Denonciation);
		}
	}
}
