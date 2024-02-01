using JeBalance.Domain.ValueObjects;

namespace JeBalance.API.InspectionFiscale.Ressources
{
    public class AdresseAPI
    {
        public int NumeroVoie { get; set; }
        public string NomVoie { get; set; }
        public int CodePostal { get; set; }
        public string Commune { get; set; }

        public AdresseAPI(int numeroVoie, string nomVoie, int codePostal, string commune)
        {
            NumeroVoie = numeroVoie;
            NomVoie = nomVoie;
            CodePostal = codePostal;
            Commune = commune;
        }
    }
}
