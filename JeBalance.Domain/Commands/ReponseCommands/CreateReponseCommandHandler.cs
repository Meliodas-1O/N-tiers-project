using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.ReponseCommands
{
	public class CreateReponseCommandHandler : IRequestHandler<CreateReponseCommand, int>
	{
		private readonly IReponseRepository _repository;

		public CreateReponseCommandHandler(IReponseRepository repository) => _repository = repository;

		public Task<int> Handle(CreateReponseCommand command, CancellationToken cancellationToken)
		{
			return _repository.Create(command.Reponse);
		}
	}
}
