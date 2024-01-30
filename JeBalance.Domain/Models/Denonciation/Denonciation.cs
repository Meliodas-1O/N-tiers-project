using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.ValueObjects;
using System.Security.Cryptography;
using System.Text;


namespace JeBalance.Domain.Models.Denonciation
{
    public class Denonciation : Entity
    {
        public DateTime Horodatage { get; set; }
		public virtual Personne? Informateur { get; set; }
		public virtual Personne? Suspect { get; set; }
        public string InformateurId { get; set; }
        public string SuspectId { get; set; } 
		public Delit Delit { get; set; }
        public PaysEvasion PaysEvasion { get; set; } = null!;
		public string? ReponseId { get; set; }
		public virtual DenonciationReponse? Reponse { get; set; }
		public Denonciation(string id, DateTime horodatage, string informateur, string suspect, Delit delit, string paysEvasion, string? reponseId)
			: base(id)
		{
			Id = id.ToString();
			Horodatage = horodatage;
			InformateurId = informateur;
			SuspectId = suspect;
			Delit = delit;
			PaysEvasion = new PaysEvasion(paysEvasion);
            ReponseId = reponseId;
        }

        public Denonciation(DateTime horodatage, string informateur, string suspect, Delit delit, string paysEvasion, string? reponseId)
			: base("0")
		{
			Horodatage = horodatage;
			InformateurId = informateur;
			SuspectId = suspect;
			Delit = delit;
			PaysEvasion = new PaysEvasion(paysEvasion);
            ReponseId = reponseId;
			Id = GenerateId();

		}

        public Denonciation(string id, DateTime horodatage, Personne informateur, Personne suspect, Delit delit, string paysEvasion, DenonciationReponse? reponseId)
			: base("0")
        {
            Horodatage = horodatage;
            InformateurId = informateur.Id;
            SuspectId = suspect.Id;
            Informateur = informateur;
            Suspect = suspect;
            Delit = delit;
            PaysEvasion = new PaysEvasion(paysEvasion);
            Reponse = reponseId;
            Id = id.ToString();

        }

        public Denonciation() : base("-1")
        {
        }
		private string GenerateId()
		{
			const string SEL = "MON_BEAU_SEL";
			const string POIVRE = "MON_BEAU_POIVRE";
			string dataToHash = $"{InformateurId}-{SuspectId}-{Delit}-{PaysEvasion.Value}-{POIVRE}-{SEL}";

			byte[] dataBytes = Encoding.UTF8.GetBytes(dataToHash);
			using (MD5 md5 = MD5.Create())
			{
				byte[] hashBytes = md5.ComputeHash(dataBytes);
				StringBuilder stringBuilder = new StringBuilder();
				foreach (byte b in hashBytes)
				{
					stringBuilder.Append(b.ToString("x2"));
				}
				return stringBuilder.ToString();
			}
		}

	}

}
