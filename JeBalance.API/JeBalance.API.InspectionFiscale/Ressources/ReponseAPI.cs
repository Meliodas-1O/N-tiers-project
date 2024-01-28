using JeBalance.Domain.Models.Reponse;
using System.Text.Json.Serialization;

namespace JeBalance.API.InspectionFiscale.Ressources
{
	public class ReponseAPI
	{
		public TypeReponse Type { get; set; }
		public int Retribution { get; set; }

		[JsonIgnore]
		public string? DenonciationId { get; set; }
		public ReponseAPI() { }

		public DenonciationReponse ToReponse()
		{
			return new (DateTime.Now, Type, Retribution,DenonciationId);
		}
	}


}
