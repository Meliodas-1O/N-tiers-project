using JeBalance.Domain.Contracts;
using System.Collections.Specialized;

namespace JeBalance.Domain.Models.Reponse
{
	public class DenonciationReponse : Entity
	{
		public DateTime Timestamp { get; set; }
		public TypeReponse Type { get; set; }
		public int Retribution { get; set; }
		public new string Id { get; set; }
		public string DenonciationId { get; set; }
		public DenonciationReponse(DateTime timestamp, TypeReponse type, int retribution, string denonciationId) : base("-1") 
		{
			if (type == TypeReponse.CONFIRMATION && retribution <= 1)
			{
				throw new ArgumentException("La rétribution doit supérieur à 1€ pour une CONFIRMATION.");
			}
			Timestamp = timestamp;
			Type = type;
			Retribution = retribution;
			DenonciationId = denonciationId;
			Id = Guid.NewGuid().ToString();
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
