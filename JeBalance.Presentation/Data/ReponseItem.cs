using JeBalance.Domain.Models.Reponse;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace JeBalance.Presentation.Data
{
    public class ReponseItem
    {
        [JsonPropertyName("retribution")]
        public int Retribution;
        [JsonPropertyName("type")]
        public TypeReponse Type;
        [JsonPropertyName("date")]
        public DateTime Date;

        public ReponseItem(int retribution, TypeReponse type, DateTime date)
        {
            Retribution = retribution;
            Type = type;
            Date = date;
        }

        public ReponseItem() { }
    }
}
