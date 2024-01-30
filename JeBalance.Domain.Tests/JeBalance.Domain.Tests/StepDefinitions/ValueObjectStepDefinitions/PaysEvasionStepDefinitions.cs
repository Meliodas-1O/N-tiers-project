using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectStepDefinitions
{
    [Binding]
    public class PaysEvasionStepDefinitions
    {
        private PaysEvasion _paysEvasion;
        private string _paysEvasionString;
        private Exception _exception;

        [Given(@"un pays d'evasion valide ""([^""]*)""")]
        public void GivenUnPaysDevasionValide(string suisse)
        {
            _paysEvasionString = suisse;
            _paysEvasion = new PaysEvasion(_paysEvasionString);
        }

        [When(@"le pays d'evasion est cree")]
        public void WhenLePaysDevasionEstCree()
        {
            try
            {
                _paysEvasion = new PaysEvasion(_paysEvasionString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"le pays d'evasion est ""([^""]*)""")]
        public void ThenLePaysDevasionEst(string suisse)
        {
            Assert.Equal(suisse, _paysEvasion.Value);

        }

        [Given(@"un pays d'evasion vide")]
        public void GivenUnPaysDevasionVide()
        {
            _exception = null;
            try
            {
                _paysEvasionString = "";
                _paysEvasion = new PaysEvasion(_paysEvasionString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"une exception est levee pour le pays avec le message ""(.*)""")]
        public void ThenUneExceptionEstLeveePourLePaysAvecLeMessage(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un pays d'evasion avec moins de (.*) caracteres ""([^""]*)""")]
        public void GivenUnPaysDevasionAvecMoinsDeCaracteres(int p0, string a)
        {
            _exception = null;
            _paysEvasionString = a;
            try
            {
                _paysEvasion = new PaysEvasion(_paysEvasionString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Given(@"un pays d'evasion avec plus de (.*) caracteres ""([^""]*)""")]
        public void GivenUnPaysDevasionAvecPlusDeCaracteres(int p0, string p1)
        {
            _exception = null;
            _paysEvasionString = p1;
            try
            {
                _paysEvasion = new PaysEvasion(_paysEvasionString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }
    }
}
