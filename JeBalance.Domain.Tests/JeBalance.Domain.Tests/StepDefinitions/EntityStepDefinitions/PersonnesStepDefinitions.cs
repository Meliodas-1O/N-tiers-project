using JeBalance.Domain.Commands.PersonneCommands;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.Domain.ValueObjects;
using JeBalance.DomainCommands.PersonneCommands;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.EntityStepDefinitions
{
    [Binding]
    public class PersonnesStepDefinitions
    {
        private readonly PersonneRepositoryDriver _repository;

        public PersonnesStepDefinitions(PersonneRepositoryDriver repository)
        {
            _repository = repository;
        }


        private string _result;
        private Personne _personne;
        private Personne _personneBis;
        private IEnumerable<Personne> _people;



        [Given(@"une base de donnees vide")]
        public void GivenUneBaseDeDonneesVide()
        {
            _repository.Personnes = new List<Personne>();
        }

        [Given(@"j'ajoute une personne avec:")]
        public async void GivenJajouteUnePersonneAvec(Table table)
        {
            TableRow personneData = table.Rows.First();
            string prenom = personneData["Prenom"];
            string nom = personneData["Nom"];
            string type = "CALOMNIATEUR";
            TypePersonne typePersonne = (TypePersonne)Enum.Parse(typeof(TypePersonne), type);
            int nombreAvertissement = int.Parse(personneData["Avertissements"]);
            CreatePersonneCommand nouvellePersonneCommand = new(prenom, nom, typePersonne, nombreAvertissement, new Adresse(12, "Rue de Paris", 75001, "Paris"));
            CreatePersonneCommandHandler handler = new(_repository);
            _result = await handler.Handle(nouvellePersonneCommand, CancellationToken.None);
            _personne = _repository.Personnes.First();
        }

        [Then(@"la personne est ajoutee")]
        public void ThenLaPersonneEstAjoutee()
        {
            Assert.NotNull(_personne);
        }

        [Given(@"une personne existante dans la base de donnees:")]
        public void GivenUnePersonneExistanteDansLaBaseDeDonnees(Table table)
        {
            TableRow personneData = table.Rows.First();
            TypePersonne typePersonne = (TypePersonne)Enum.Parse(typeof(TypePersonne), "CALOMNIATEUR");

            _repository.Personnes = new List<Personne>()
            {
              new ("1","Jean", "Dupont", typePersonne, 0, new Adresse(12, "Rue de Paris", 75001, "Paris"))
            };
            _personne = _repository.Personnes.First();
        }

        [When(@"je mets a jour le type de cette personne a ""([^""]*)""")]
        public async void WhenJeMetsAJourLeTypeDeCettePersonneA(string vIP)
        {
            TypePersonne typePersonne = (TypePersonne)Enum.Parse(typeof(TypePersonne), vIP);
            UpdateTypePersonneCommand updateTypePersonneCommand = new(_personne.Id, typePersonne);
            UpdateTypePersonneCommandHandler handler = new(_repository);
            _personneBis = await handler.Handle(updateTypePersonneCommand, CancellationToken.None);
        }

        [When(@"je recherche cette personne dans la base de donnees")]
        public async void WhenJeRechercheCettePersonneDansLaBaseDeDonnees()
        {
            FindOnePersonneQuery findPersonneCommand = new(_personne.Id);
            FindOnePersonneQueryHandler handler = new(_repository);
            _personneBis = await handler.Handle(findPersonneCommand, CancellationToken.None);
        }

        [Then(@"le type de la personne est changee")]
        public void ThenLeTypeDeLaPersonneEstChangee()
        {
            Assert.True(_personneBis.TypePersonne != _personne.TypePersonne);
        }

        [Given(@"une personne existante dans la base de donnees avec:")]
        public void GivenUnePersonneExistanteDansLaBaseDeDonneesAvec(Table table)
        {
            TypePersonne typePersonne = (TypePersonne)Enum.Parse(typeof(TypePersonne), "CALOMNIATEUR");

            _repository.Personnes = new List<Personne>()
            {
              new ("1","Jean", "Dupont", typePersonne, 0, new Adresse(12, "Rue de Paris", 75001, "Paris"))
            };
            _personne = _repository.Personnes.First();
        }

        [When(@"je supprime cette personne de la base de donnees")]
        public async void WhenJeSupprimeCettePersonneDeLaBaseDeDonnees()
        {
            _personne = _repository.Personnes.First();
            DeletePersonneCommand deletePersonneCommand = new(_personne.Id);
            DeletePersonneCommandHandler handler = new(_repository);
            await handler.Handle(deletePersonneCommand, CancellationToken.None);
        }

        [Then(@"la personne est supprimee")]
        public async void ThenLaPersonneEstSupprimee()
        {
            _repository.Personnes.Count.Should().Be(0);
        }

        [Given(@"une personne de type ""([^""]*)"" existante dans la base de donnees avec:")]
        public void GivenUnePersonneDeTypeExistanteDansLaBaseDeDonneesAvec(string vIP, Table table)
        {
            TableRow personneData = table.Rows.First();
            TypePersonne typePersonne = (TypePersonne)Enum.Parse(typeof(TypePersonne), "VIP");

            _repository.Personnes = new List<Personne>()
            {
              new ("1","Jean", "Dupont", typePersonne, 0, new Adresse(12, "Rue de Paris", 75001, "Paris"))
            };
            _personne = _repository.Personnes.First();

        }

        [When(@"je recupere cette personne de la base de donnees")]
        public async void WhenJeRecupereCettePersonneDeLaBaseDeDonnees()
        {
            FindOnePersonneQuery findPersonneCommand = new(_personne.Id);
            FindOnePersonneQueryHandler handler = new(_repository);
            _personne = await handler.Handle(findPersonneCommand, CancellationToken.None);
        }

        [Then(@"je recois la personne de type ""([^""]*)""")]
        public void ThenJeRecoisLaPersonneDeType(string vIP)
        {
            TypePersonne typePersonne = (TypePersonne)Enum.Parse(typeof(TypePersonne), "VIP");
            Assert.True(typePersonne == _personne.TypePersonne);

        }

        [Given(@"une base de donnees contenant plusieurs personnes")]
        public void GivenUneBaseDeDonneesContenantPlusieursPersonnes(Table table)
        {
            _repository.Personnes = new List<Personne>(){
                new ("Jean", "Dupont", TypePersonne.CALOMNIATEUR, 2, new Adresse(12,"Rue de Paris", 75001,"Paris")),
                new ("Alice", "Dupont", TypePersonne.VIP, 1, new Adresse(15 ,"Rue de Lyon", 69001, "Lyon")),
                new ("Marc", "Lefevre", TypePersonne.CALOMNIATEUR, 0, new Adresse(8,"Rue de Marseille", 13001 ,"Marseille")),
                new ("Sophie", "Martin", TypePersonne.VIP, 3, new Adresse(20,"Rue de Lille", 59000, "Lille"))
            };
        }

        [When(@"je recherche des personnes avec des criteres specifiques")]
        public async void WhenJeRechercheDesPersonnesAvecDesCriteresSpecifiques()
        {
            FindPersonneQuery findPersonneCommand = new(10, 0, null, "Dupond", TypePersonne.VIP, null);
            FindPersonneQueryHandler handler = new(_repository);
            _people = await handler.Handle(findPersonneCommand, CancellationToken.None);
        }

        [Then(@"je recois les personnes correspondantes selon les criteres specifies")]
        public void ThenJeRecoisLesPersonnesCorrespondantesSelonLesCriteresSpecifies()
        {
            Assert.NotNull(_people);
            _people.Count().Should().Be(0);
        }

    }
}
