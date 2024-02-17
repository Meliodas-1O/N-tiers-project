using JeBalance.Domain.Models.Reponse;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace JeBalance.Presentation.Data
{
    public class ReponseItem
    {
        public int retribution;
        public TypeReponse type;
        public DateTime date;

        public ReponseItem(int retribution, TypeReponse type, DateTime date)
        {
            this.retribution = retribution;
            this.type = type;
            this.date = date;
        }

        public ReponseItem() { }
    }
}
