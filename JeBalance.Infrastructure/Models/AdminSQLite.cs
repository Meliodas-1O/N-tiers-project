using JeBalance.Domain.Models.Denonciation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.Models;
	public class AdminSQLite
	{
		[Key]
		public string Id { get; set; } = null!;
		public string NomUtilisateur { get; set; } = null!;
		public string MotDePasse { get; set; } = null!;
		public  string Prenom { get; set; } = null!;
		public  string Nom { get; set; } = null!;
		public string Adresse { get; set; } = null!;
	}
