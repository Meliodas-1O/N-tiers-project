using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectStepDefinitions
{
    [Binding]
    public class NumeroVoieStepDefinitions
    {
        private NumeroVoie _numeroVoie;
        private int _numeroVoieValue;
        private Exception _exception;

        [Given(@"un numero  voie valide (.*)")]
        public void GivenUnNumeroVoieValide(int p0)
        {
            _numeroVoieValue = p0;
            _numeroVoie = new NumeroVoie(_numeroVoieValue);
        }

        [When(@"le numero voie est cree")]
        public void WhenLeNumeroVoieEstCree()
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

        [Then(@"le numero  voie est (.*)")]
        public void ThenLeNumeroVoieEst(int p0)
        {
            Assert.Equal(p0, _numeroVoie.Value);
        }

        [Given(@"un numero  voie inferieur a (.*)")]
        public void GivenUnNumeroVoieInferieurA(int p0)
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

        [Then(@"une exception est levee pour numeroVoie avec message ""([^""]*)""")]
        public void ThenUneExceptionEstLeveePourNumeroVoieAvecMessage(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un numero  voie superieur a (.*)")]
        public void GivenUnNumeroVoieSuperieurA(int p0)
        {
            _exception = null;
            _numeroVoieValue = p0 + 1;
            try
            {
                _numeroVoie = new NumeroVoie(_numeroVoieValue);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }
    }
}
