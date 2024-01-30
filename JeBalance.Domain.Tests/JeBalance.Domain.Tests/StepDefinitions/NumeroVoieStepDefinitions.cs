using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions
{
    [Binding]
    public class NumeroVoieStepDefinitions
    {
        private NumeroVoie _numeroVoie;
        private int _numeroVoieValue;
        private Exception _exception;

        [Given(@"un numero de voie valide (.*)")]
        public void GivenUnNumeroDeVoieValide(int p0)
        {
            _numeroVoieValue = p0;
            _numeroVoie = new NumeroVoie(_numeroVoieValue);
        }

        [When(@"le numero de voie est cree")]
        public void WhenLeNumeroDeVoieEstCree()
        {
            try
            {
                _numeroVoie = new NumeroVoie(_numeroVoieValue);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"le numero de voie est (.*)")]
        public void ThenLeNumeroDeVoieEst(int p0)
        {
            Assert.Equal(p0, _numeroVoie.Value);
        }

        [Given(@"un numero de voie inferieur a (.*)")]
        public void GivenUnNumeroDeVoieInferieurA(int p0)
        {
            _exception = null;
            try
            {
                _numeroVoie = new NumeroVoie(p0 - 1);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"une exception est levee pour numeroVoie avec le message ""([^""]*)""")]
        public void ThenUneExceptionEstLeveePourNumeroVoieAvecLeMessage(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un numero de voie superieur a (.*)")]
        public void GivenUnNumeroDeVoieSuperieurA(int p0)
        {
            _exception = null;
            try
            {
                _numeroVoie = new NumeroVoie(p0 + 1000);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }
    }
}
