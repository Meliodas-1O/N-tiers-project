using JeBalance.Domain.ValueObjects;

namespace JeBalance.Public.API.Ressources
{
    public class AdresseAPI
    {
        public int NumeroVoie { get; set; }
        public string NomVoie { get; set; }
        public int CodePostal { get; set; }
        public string Commune { get; set; }

        public AdresseAPI() { }

        public Adresse ToAdresse()
        {
            Adresse adresse = new Adresse(NumeroVoie, NomVoie, CodePostal,Commune);
            return adresse;
        }

        public static AdresseAPI FromAdresse(Adresse adresse)
        {
            AdresseAPI adresseApi = new AdresseAPI
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
