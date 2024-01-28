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
	public class SetReponseCommandHandler : IRequestHandler<SetReponseCommand, Denonciation>
	{
		private readonly IDenonciationRepository _repository;

		public SetReponseCommandHandler(IDenonciationRepository repository) => _repository = repository;

		public Task<Denonciation> Handle(SetReponseCommand command, CancellationToken cancellationToken)
		{
			return _repository.SetReponse(command.Id, command.ReponseId);
		}
	}
}
