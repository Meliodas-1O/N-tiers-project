using JeBalance.Domain.Commands.ReponseCommands;
using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.Queries.PersonneQueries;
using JeBalance.Domain.Queries.ReponseQueries;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.DomainCommands.PersonneCommands;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions
{
    [Binding]
    public class ReponsesStepDefinitions
    {
        private readonly ReponseRepositoryDriver _repository;
        private DenonciationReponse _reponse;
        private Denonciation _denonciation;
        private string _reponseId;
        private string _denonciationId;
        private bool _result;
        private Exception _exception;


        public ReponsesStepDefinitions(ReponseRepositoryDriver repository)
        {
            _repository = repository;
        }

        [Given(@"une denonciation existante dans la base de donnees")]
        public void GivenUneDenonciationExistanteDansLaBaseDeDonnees()
        {
            _denonciation = new Denonciation(DateTime.Now, "INFORMATEUR", "SUSPECT", Delit.EVASIONFISCALE, "CANADA", null);
            _denonciationId = _denonciation.Id;
        }

        [When(@"j'ajoute une reponse a cette denonciation")]
        public async void WhenJajouteUneReponseACetteDenonciation()
        {
            CreateReponseCommand command = new(DateTime.Now, TypeReponse.CONFIRMATION, 1000, _denonciationId);
            CreateReponseCommandHandler handler = new(_repository);
            _reponseId = await handler.Handle(command, CancellationToken.None);
        }

        [Then(@"la reponse est ajoutee a la base de donnees avec succes")]
        public async void ThenLaReponseEstAjouteeALaBaseDeDonneesAvecSucces()
        {
            FindOneReponseQuery findReponseQuery = new(_reponseId);
            FindOneReponseQueryHandler handler = new(_repository);
            _reponse = await handler.Handle(findReponseQuery, CancellationToken.None);
            Assert.NotNull(_reponse);
        }

        [When(@"j'(.*)'ajouter une reponse avec une retribution inferieure a (.*) e pour une confirmation")]
        public async void WhenJajouterUneReponseAvecUneRetributionInferieureAEPourUneConfirmation(string p0, int p1)
        {
            try
            {
                CreateReponseCommand command = new(DateTime.Now, TypeReponse.CONFIRMATION, p1, _denonciationId);
                CreateReponseCommandHandler handler = new(_repository);
                _reponseId = await handler.Handle(command, CancellationToken.None);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [When(@"j'essaie de mettre a jour cette reponse avec une retribution inferieure a (.*) e pour une confirmation")]
        public async void WhenJessaieDeMettreAJourCetteReponseAvecUneRetributionInferieureAEPourUneConfirmation(int p0)
        {
            try
            {
                UpdateReponseCommand command = new(_reponseId, DateTime.Now, TypeReponse.CONFIRMATION, p0, _denonciationId);
                UpdateReponseCommandHandler handler = new(_repository);
                _reponse = await handler.Handle(command, CancellationToken.None);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"je recois une erreur")]
        public void ThenJeRecoisUneErreur()
        {
            Assert.NotNull(_exception);
            _exception = null;
        }

        [Given(@"une reponse existante dans la base de donnees")]
        public void GivenUneReponseExistanteDansLaBaseDeDonnees()
        {
            _repository._denonciationReponses = new List<DenonciationReponse> {
               new (DateTime.Now, TypeReponse.CONFIRMATION, 10, _reponseId)
            };
            _reponseId = _repository._denonciationReponses.First().Id;
        }

        [When(@"je mets a jour la retribution de cette reponse")]
        public async void WhenJeMetsAJourLaRetributionDeCetteReponse()
        {
            try
            {
                UpdateReponseCommand command = new(_reponseId, DateTime.Now, TypeReponse.REJET, 0, _denonciationId);
                UpdateReponseCommandHandler handler = new(_repository);
                _reponse = await handler.Handle(command, CancellationToken.None);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"la retribution de la reponse est mise a jour avec succes dans la base de donnees")]
        public void ThenLaRetributionDeLaReponseEstMiseAJourAvecSuccesDansLaBaseDeDonnees()
        {
            Assert.Null(_exception);
            Assert.True(_reponse.Type==TypeReponse.REJET);
        }

        [When(@"je supprime cette reponse de la base de donnees")]
        public async void WhenJeSupprimeCetteReponseDeLaBaseDeDonnees()
        {
            DeleteReponseCommand command = new(_reponseId);
            DeleteReponseCommandHandler handler = new(_repository);
            _result = await handler.Handle(command, CancellationToken.None);
        }

        [Then(@"la reponse est supprimee avec succes de la base de donnees")]
        public void ThenLaReponseEstSupprimeeAvecSuccesDeLaBaseDeDonnees()
        {
            Assert.True(_result);
        }
    }
}
