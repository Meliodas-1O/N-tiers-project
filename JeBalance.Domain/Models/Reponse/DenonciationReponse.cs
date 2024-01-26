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
		public int DenonciationId { get; set; }
		public DenonciationReponse(DateTime timestamp, TypeReponse type, int retribution, int denonciationId) : base(0) {
			Timestamp = timestamp;
			Type = type;
			Retribution = retribution;
			DenonciationId = denonciationId;
		}
		public DenonciationReponse(int id,DateTime timestamp, TypeReponse type, int retribution, int denonciationId) : base(id)
		{
			Timestamp = timestamp;
			Type = type;
			Retribution = retribution;
            DenonciationId = denonciationId;
        }

        public DenonciationReponse() : base(-1)
        {
        }
    }
}
