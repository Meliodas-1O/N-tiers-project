using JeBalance.Domain.Models.Reponse;
using System.Text.Json.Serialization;

namespace JeBalance.API.InspectionFiscale.Ressources
{
	public class ReponseAPI
	{
        [JsonIgnore]
        public DateTime? Date {  get; set; }
		public TypeReponse Type { get; set; }
		public int Retribution { get; set; }

		[JsonIgnore]
		public string? DenonciationId { get; set; }
		public ReponseAPI() { }

        public DenonciationReponse ToReponse()
        {
            return new(DateTime.Now, Type, Retribution, DenonciationId);
        }

        public static ReponseAPI FromReponse(DenonciationReponse reponse)
        {
            return new ReponseAPI()
            {
                Date = reponse.Timestamp,
                Retribution = reponse.Retribution,
                Type = reponse.Type,
            };
        }
    }


}
