using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectStepDefinitions
{
    [Binding]
    public class AdresseStepDefinitions
    {
        private Adresse _adresse;
        private int _numeroVoie;
        private string _nomVoie;
        private int _codePostal;
        private string _nomCommune;
        private Exception _exception;

        [Given(@"un numero de voie correct (.*)")]
        public void GivenUnNumeroDeVoieCorrect(int p0)
        {
            _numeroVoie = p0;
        }

        [Given(@"un nom de voie ""([^""]*)""")]
        public void GivenUnNomDeVoie(string p0)
        {
            _nomVoie = p0;
        }

        [Given(@"un code postal correct (.*)")]
        public void GivenUnCodePostalCorrect(int p0)
        {
            _codePostal = p0;
        }

        [Given(@"un nom de commune ""([^""]*)""")]
        public void GivenUnNomDeCommune(string seize)
        {
            _nomCommune = seize;
        }

        [When(@"l'adresse est creee")]
        public void WhenLadresseEstCreee()
        {
            try
            {
                _adresse = new Adresse(_numeroVoie, _nomVoie, _codePostal, _nomCommune);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"l'adresse est ""([^""]*)""")]
        public void ThenLadresseEst(string p0)
        {
            Assert.Equal(p0, _adresse.Value);
        }

        [Given(@"un numero de voie invalide (.*)")]
        public void GivenUnNumeroDeVoieInvalide(int p0)
        {
            _numeroVoie = p0;
        }

        [Then(@"une exception est levee pour adresse avec le message ""([^""]*)""")]
        public void ThenUneExceptionEstLeveePourAdresseAvecLeMessage(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un nom de voie vide")]
        public void GivenUnNomDeVoieVide()
        {
            _nomVoie = "";
        }

        [Then(@"une exception est levee pour l'([^']*)'une voie ne peut pas etre vide""")]
        public void ThenUneExceptionEstLeveePourLuneVoieNePeutPasEtreVide(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un code postal invalide (.*)")]
        public void GivenUnCodePostalInvalide(int p0)
        {
            _codePostal = p0;
        }


        [Given(@"un nom de commune null")]
        public void GivenUnNomDeCommuneNull()
        {
            _nomCommune = "";
        }
    }
}
