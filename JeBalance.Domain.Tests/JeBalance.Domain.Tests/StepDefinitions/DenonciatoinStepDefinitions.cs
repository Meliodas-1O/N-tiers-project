using JeBalance.Domain.Commands.DenonciationCommands;
using JeBalance.Domain.Commands.DenonciationCommandsCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Queries.DenonciationQueries;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions
{
    [Binding]
    public class DenonciatoinStepDefinitions
    {

        private readonly DenonciationRepositoryDriver _repository;
        private Denonciation _denonciation;
        private Denonciation _denonciationBis;
        private string _denonciationId;
        private string _result;
        private bool _deleted;

        public DenonciatoinStepDefinitions(DenonciationRepositoryDriver repository)
        {
            _repository = repository;
        }

        [Given(@"un horodatage de ""([^""]*)""")]
        public void GivenUnHorodatageDe(string horodatage)
        {
            _denonciation = new Denonciation(DateTime.Parse(horodatage), "InformateurId", "SuspectId", Delit.DISSIMULATIONREVENU, "PaysEvasion", null);
        }

        [Given(@"une denonciation avec les informations suivantes:")]
        public async void GivenUneDenonciationAvecLesInformationsSuivantes(Table table)
        {
            var informateurId = table.Rows[0]["Informateur"];
            var suspectId = table.Rows[0]["Suspect"];
            var delitType = (Delit)Enum.Parse(typeof(Delit), "EVASIONFISCALE");
            var paysEvasion = table.Rows[0]["PaysEvasion"];
            string reponse = null;
            _denonciationBis = new(DateTime.Now, informateurId, suspectId, delitType, paysEvasion, reponse);
        }

        [When(@"j'ajoute une denonciation avec ces informations")]
        public async Task WhenJajouteUneDenonciationAvecCesInformations()
        {
            CreateDenonciationCommand nouvelleDenonciationCommand = new(_denonciationBis.Horodatage, _denonciationBis.InformateurId, _denonciationBis.SuspectId, _denonciationBis.Delit, _denonciationBis.PaysEvasion.Value, null);
            CreateDenonciationCommandHandler handler = new(_repository);
            _denonciationId = await handler.Handle(nouvelleDenonciationCommand, CancellationToken.None);
            _denonciation = _repository.Denonciations.First();
        }

        [Then(@"la denonciation est ajoutee e la base de donnees avec succes")]
        public async Task ThenLaDenonciationEstAjouteeELaBaseDeDonneesAvecSucces()
        {
            FindOneDenonciationQuery findDenonciationCommand = new(_denonciation.Id);
            FindOneDenonciationQueryHandler handler = new(_repository);
            _denonciation = await handler.Handle(findDenonciationCommand, CancellationToken.None);
            Assert.NotNull(_denonciation);
        }

        [Given(@"une base de donnees contenant plusieurs denonciations")]
        public void GivenUneBaseDeDonneesContenantPlusieursDenonciations()
        {
            _repository.Denonciations = new List<Denonciation>
        {
            new (DateTime.Now, "InformateurId1", "SuspectId1", Delit.EVASIONFISCALE, "PaysEvasion1", null),
            new (DateTime.Now, "InformateurId2", "SuspectId2", Delit.EVASIONFISCALE, "PaysEvasion2", "ReponseId2"),
            new (DateTime.Now, "InformateurId3", "SuspectId3", Delit.DISSIMULATIONREVENU, "PaysEvasion3", null)
        };
            _denonciation = _repository.Denonciations.First();
        }

        [When(@"je recherche une denonciation par son identifiant")]
        public async Task WhenJeRechercheUneDenonciationParSonIdentifiant()
        {
            FindOneDenonciationQuery findDenonciationCommand = new(_denonciation.Id);
            FindOneDenonciationQueryHandler handler = new(_repository);
            _denonciation = await handler.Handle(findDenonciationCommand, CancellationToken.None);
        }

        [Then(@"je recois la denonciation correspondante")]
        public void ThenJeRecoisLaDenonciationCorrespondante()
        {
            Assert.NotNull(_denonciation);
        }

        [Given(@"une denonciation existante avec une reponse")]
        public void GivenUneDenonciationExistanteAvecUneReponse()
        {
            _repository.Denonciations = new List<Denonciation>
            {
                new (DateTime.Now, "InformateurId1", "SuspectId1", Delit.EVASIONFISCALE, "PaysEvasion1", "ReponseId1"),
                new (DateTime.Now, "InformateurId2", "SuspectId2", Delit.EVASIONFISCALE, "PaysEvasion2", null),
            };
            _denonciation = _repository.Denonciations.First();
        }

        [When(@"je mets e jour la reponse de la denonciation")]
        public async Task WhenJeMetsEJourLaReponseDeLaDenonciation()
        {
            var reponseId = "NouvelleReponseId";
            SetReponseCommand setReponseCommand = new(_denonciation.Id,reponseId);
            SetReponseCommandHandler handler = new(_repository);
            _denonciation = await handler.Handle(setReponseCommand, CancellationToken.None);
        }

        [Then(@"la reponse de la denonciation est mise e jour avec succes")]
        public void ThenLaReponseDeLaDenonciationEstMiseEJourAvecSucces()
        {
            Assert.NotNull(_denonciation);
            Assert.NotNull(_denonciation.ReponseId);
        }

        [When(@"je supprime une denonciation par son identifiant")]
        public async Task WhenJeSupprimeUneDenonciationParSonIdentifiant()
        {
            _deleted = false;
            DeleteDenonciationCommand deleteDenonciationCommand = new(_denonciation.Id);
            DeleteDenonciationCommandHandler handler = new(_repository);
            _deleted = await handler.Handle(deleteDenonciationCommand, CancellationToken.None);
        }

        [Then(@"la denonciation est supprimee avec succes de la base de donnees")]
        public async Task ThenLaDenonciationEstSupprimeeAvecSuccesDeLaBaseDeDonnees()
        {
            Assert.True(_deleted);
        }
    }
}
