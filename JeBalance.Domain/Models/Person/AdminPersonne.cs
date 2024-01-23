using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Models.Person
{
    public class AdminPersonne : Entity
    {
        public Prenom Prenom { get; set; } = null!;
        public Nom Nom { get; set; } = null!;
        public NomUtilisateur NomUtilisateur { get; set; }
        public MotDePasse MotDePasse { get; set; }
        public Adresse Adresse { get; set; } = null!;

        public AdminPersonne():base(0) { }
        public AdminPersonne(String prenom, String nom, String nomUtilisateur, String motDePasse, Adresse adresse) : base(0) 
        {
            Prenom = new Prenom(prenom);
            Nom = new Nom(nom);
            NomUtilisateur = new NomUtilisateur(nomUtilisateur);
            MotDePasse = new MotDePasse(motDePasse);
            Adresse = adresse;
        }
    }
}
