using JeBalance.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Models.Reponse
{
	public class DenonciationReponse : Entity
	{
		public DateTime Timestamp { get; set; }
		public TypeReponse Type { get; set; }
		public int Retribution { get; set; }
		public string DenonciationId { get; set; }
		public DenonciationReponse(DateTime timestamp, TypeReponse type, int retribution, string denonciationId) : base("-1") {
			Timestamp = timestamp;
			Type = type;
			Retribution = retribution;
			DenonciationId = denonciationId;
		}
		public DenonciationReponse(string id,DateTime timestamp, TypeReponse type, int retribution, string denonciationId) : base(id)
		{
			Timestamp = timestamp;
			Type = type;
			Retribution = retribution;
            DenonciationId = denonciationId;
        }

        public DenonciationReponse() : base("-1")
        {
        }
    }
}
