using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectStepDefinitions
{
    [Binding]
    public class CodePostalStepDefinitions
    {
        private CodePostal _codePostal;
        private int _codePostalValue;
        private Exception _exception;

        [Given(@"un code postal valide (.*)")]
        public void GivenUnCodePostalValide(int p0)
        {
            _codePostalValue = p0;
            _codePostal = new CodePostal(_codePostalValue);
        }

        [When(@"le code postal est cree")]
        public void WhenLeCodePostalEstCree()
        {
            try
            {
                _codePostal = new CodePostal(_codePostalValue);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"le code postal est (.*)")]
        public void ThenLeCodePostalEst(int p0)
        {
            Assert.Equal(p0, _codePostal.Value);
        }

        [Given(@"un code postal avec moins de (.*) chiffres (.*)")]
        public void GivenUnCodePostalAvecMoinsDeChiffres(int p0, int p1)
        {
            _exception = null;
            try
            {
                _codePostalValue = p1;
                _codePostal = new CodePostal(_codePostalValue);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"une exception est levee pour le code postal avec le message ""([^""]*)""")]
        public void ThenUneExceptionEstLeveePourLeCodePostalAvecLeMessage(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un code postal avec plus de (.*) chiffres (.*)")]
        public void GivenUnCodePostalAvecPlusDeChiffres(int p0, int p1)
        {
            _exception = null;
            try
            {
                _codePostalValue = p1;
                _codePostal = new CodePostal(_codePostalValue);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

    }
}
