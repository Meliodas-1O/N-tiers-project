using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectStepDefinitions
{
    [Binding]
    public class NomStepDefinitions
    {
        private Nom _nom;
        private string _nomString;
        private Exception _exception;

        [Given(@"un nom valide ""([^""]*)""")]
        public void GivenUnNomValide(string john)
        {
            _nomString = john;
            _nom = new Nom(john);
        }

        [When(@"le nom est cree")]
        public void WhenLeNomEstCree()
        {
            try
            {
                _nom = new Nom(_nomString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"le nom est ""([^""]*)""")]
        public void ThenLeNomEst(string john)
        {
            Assert.Equal(john, _nom.Value);
        }

        [Given(@"un nom vide")]
        public void GivenUnNomVide()
        {
            _exception = null;
            try
            {
                _nomString = "";
                _nom = new Nom(_nomString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"une exception est levee avec le message ""([^""]*)""")]
        public void ThenUneExceptionEstLeveeAvecLeMessage(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un nom avec plus de (.*) caracteres ""(.*)""")]
        public void GivenUnNomAvecPlusDeCaractRes(int p0, string p1)
        {
            _exception = null;
            _nomString = p1;
            try
            {
                _nom = new Nom(_nomString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }
    }
}
