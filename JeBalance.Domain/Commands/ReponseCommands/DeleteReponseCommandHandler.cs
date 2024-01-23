using JeBalance.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.ReponseCommands
{
	public class DeleteReponseCommandHandler : IRequestHandler<DeleteReponseCommand, bool>
	{
		private readonly IReponseRepository _repository;

		public DeleteReponseCommandHandler(IReponseRepository repository) => _repository = repository;

		public Task<bool> Handle(DeleteReponseCommand command, CancellationToken cancellationToken)
		{
			return _repository.Delete(command.Id);
		}
	}
}
