using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.Models
{
    public static class Extension
    {
        public static ReponseSQLite ToSQLite(this DenonciationReponse reponse)
        {
            return new ReponseSQLite
            {
                Id = reponse.Id,
                Retribution = reponse.Retribution,
                Timestamp = DateTime.Now,
                Type = reponse.Type.ToString(),
                DenonciationId = reponse.DenonciationId,
            };
        }

        public static DenonciationReponse ToDomain(this ReponseSQLite reponse)
        {
            TypeReponse type = (TypeReponse)Enum.Parse(typeof(TypeReponse), reponse.Type);

            return new DenonciationReponse(
                reponse.Id,
                reponse.Timestamp,
                type,
                reponse.Retribution,
                reponse.DenonciationId
            );
        }

        public static PersonneSQLite ToSQLite(this Personne personne)
        {
            return new PersonneSQLite
            {
                Id = personne.Id,
                Prenom = personne.Prenom.Value,
                Nom = personne.Nom.Value,
                Adresse = personne.Adresse.Value,
                NombreAvertissement = personne.NombreAvertissement,
                TypePersonne = personne.TypePersonne.ToString(),
            };
        }

        public static Personne ToDomain(this PersonneSQLite personne)
        {
            var (numeroVoie, nomVoie, codePostal, nomCommune) = ExtraireParametresAdresse(personne.Adresse);
            Adresse adresse = new(numeroVoie, nomVoie, codePostal, nomCommune);

            return new Personne
            {
                Id = personne.Id,
                Prenom = new Prenom(personne.Prenom),
                Nom = new Nom(personne.Nom),
                Adresse = adresse,
                NombreAvertissement = personne.NombreAvertissement,
                TypePersonne = (TypePersonne)Enum.Parse(typeof(TypePersonne),personne.TypePersonne),
            };
        }

        public static DenonciationSQLite ToSQLite(this Denonciation denonciation)
        {
            return new DenonciationSQLite
            {
                Id = denonciation.Id,
                Horodatage = denonciation.Horodatage,
                Informateur = denonciation.Informateur.ToSQLite(),
                Suspect = denonciation.Suspect.ToSQLite(),
                Delit = denonciation.Delit.ToString(),
                PaysEvasion = denonciation.PaysEvasion.Value,
                ReponseId = denonciation.ReponseId
            };
        }

        public static Denonciation ToDomain(this DenonciationSQLite denonciation)
        {
            return new(
                denonciation.Id,
                denonciation.Horodatage,
                denonciation.Informateur,
                denonciation.Suspect,
                (Delit)Enum.Parse(typeof(Delit),denonciation.Delit),
                denonciation.PaysEvasion,
                denonciation.ReponseId
              ); 
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
