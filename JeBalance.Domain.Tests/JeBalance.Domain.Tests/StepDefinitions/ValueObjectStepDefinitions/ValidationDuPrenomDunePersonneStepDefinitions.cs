using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectStepDefinitions
{
    [Binding]
    public class ValidationDuPrenomDunePersonneStepDefinitions
    {

        private Prenom _prenom;
        private string _prenomString;
        private Exception _exception;

        [Given(@"un prenom valide ""(.*)""")]
        public void GivenUnPrenomValide(string jean)
        {
            _prenomString = jean;
            _prenom = new Prenom(_prenomString);
        }

        [When(@"le prenom est cree")]
        public void WhenLePrenomEstCree()
        {
            try
            {
                _prenom = new Prenom(_prenomString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"le prenom est ""([^""]*)""")]
        public void ThenLePrenomEst(string jean)
        {
            Assert.Equal(jean, _prenom.Value);
        }

        [Given(@"un prenom vide")]
        public void GivenUnPrenomVide()
        {
            _exception = null;
            try
            {
                _prenomString = "";
                _prenom = new Prenom(_prenomString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"une exception est levee pour le prenom avec le message ""([^""]*)""")]
        public void ThenUneExceptionEstLeveePourLePrenomAvecLeMessage(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un prenom avec plus de (.*) caracteres ""([^""]*)""")]
        public void GivenUnPrenomAvecPlusDeCaracteres(int p0, string p1)
        {
            _exception = null;
            _prenomString = p1;
            try
            {
                _prenom = new Prenom(_prenomString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }
    }
}
