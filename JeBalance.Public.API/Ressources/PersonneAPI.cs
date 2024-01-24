using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace JeBalance.Public.API.Ressources
{
    public class PersonneAPI
    {
        [Key]
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public PersonneAPI() { }

        public Personne ToPersonne()
        {
            var parametres = ExtraireParametresAdresse(Adresse);
            Adresse adresse = new(parametres.numeroVoie, parametres.nomVoie, parametres.codePostal, parametres.nomCommune);
            Personne personne = new(-1234, Prenom, Nom, TypePersonne.VIP, 0, adresse);

            return personne;
        }

        public static PersonneAPI FromPersonne(Personne personne)
        {
            PersonneAPI personneApi = new()
            {
                Prenom = personne.Prenom.Value,
                Nom = personne.Nom.Value,
                Adresse = BuildStringValue(personne.Adresse.NumeroVoie.Value, personne.Adresse.NomVoie.Value, personne.Adresse.CodePostal.Value, personne.Adresse.NomCommune.Value)
            };
            return personneApi;
        }
        private static string BuildStringValue(int numeroVoie, string nomVoie, int codePostal, string nomCommune)
        {
            return $"{numeroVoie} {nomVoie}, {codePostal} {nomCommune}";
        }

        private static (int numeroVoie, string nomVoie, int codePostal, string nomCommune) ExtraireParametresAdresse(string adresseComplete)
        {
            string[] parties = adresseComplete.Split(new char[] { ',' }, StringSplitOptions.TrimEntries);

            if (parties.Length >= 2)
            {
                string[] numeroNomRue = parties[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int numeroVoie = int.Parse(numeroNomRue[0]); 
                string nomRue = string.Join(" ", numeroNomRue, 1, numeroNomRue.Length - 1); 

                string[] cpVille = parties[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int codePostal = int.Parse(cpVille[0]); 
                string ville = string.Join(" ", cpVille, 1, cpVille.Length - 1);
                return (numeroVoie, nomRue, codePostal, ville);
            }
            else
            {
                return (-1000, string.Empty, -10000, string.Empty);
            }
        }
    }
}
