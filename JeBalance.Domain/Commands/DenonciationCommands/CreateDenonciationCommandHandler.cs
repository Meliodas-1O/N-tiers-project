using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Repository;
using MediatR;


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
