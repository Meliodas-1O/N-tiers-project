﻿using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Repository;
using JeBalance.DomainCommands.PersonneCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.ReponseCommands
{
	public class UpdateReponseCommandHandler : IRequestHandler<UpdateReponseCommand, DenonciationReponse>
	{
		private readonly IReponseRepository _repository;

		public UpdateReponseCommandHandler(IReponseRepository repository) => _repository = repository;

		public Task<DenonciationReponse> Handle(UpdateReponseCommand command, CancellationToken cancellationToken)
		{
			return _repository.Update(command.Id, command.Response);
		}
	}
}
