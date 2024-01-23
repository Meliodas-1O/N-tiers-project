﻿using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommandsCommands
{
	public class CreateDenonciationCommand : IRequest<int>
	{
		public Denonciation Denonciation { get; set; }
		public CreateDenonciationCommand(
			int id,
			DateTime horodatage,
			Personne informateur,
			Personne suspect,
			Delit delit,
			string paysEvasion,
			DenonciationReponse? reponse)
		=> Denonciation = new Denonciation(id,horodatage,informateur,suspect,delit,paysEvasion,reponse);
	}
}
