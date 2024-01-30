using JeBalance.Domain.ValueObjects;

namespace JeBalance.API.InspectionFiscale.Ressources
{
    public class AdresseAPI
    {
        public int NumeroVoie { get; set; }
        public string NomVoie { get; set; }
        public int CodePostal { get; set; }
        public string Commune { get; set; }

        public AdresseAPI() { }
        public AdresseAPI(int numeroVoie, string nomVoie, int codePostal, string commune)
        {
            NumeroVoie = numeroVoie;
            NomVoie = nomVoie;
            CodePostal = codePostal;
            Commune = commune;
        }
        public Adresse ToAdresse()
        {
            Adresse adresse = new(NumeroVoie, NomVoie, CodePostal, Commune);
            return adresse;
        }

        public static AdresseAPI FromAdresse(Adresse adresse)
        {
            AdresseAPI adresseApi = new()
            {
                NumeroVoie = adresse.NumeroVoie.Value,
                NomVoie = adresse.NomVoie.Value,
                CodePostal = adresse.CodePostal.Value,
                Commune = adresse.NomCommune.Value
            };
            return adresseApi;
        }
    }
}
