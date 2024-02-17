using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectStepDefinitions
{
    [Binding]
    public class NomCommuneStepDefinitions
    {
        private NomCommune _nomCommune;
        private string _nomCommuneString;
        private Exception _exception;

        [Given(@"un nom de commune valide ""([^""]*)""")]
        public void GivenUnNomDeCommuneValide(string paris)
        {
            _nomCommuneString = paris;
            _nomCommune = new NomCommune(_nomCommuneString);
        }

        [When(@"le nom de commune est cree")]
        public void WhenLeNomDeCommuneEstCree()
        {
            try
            {
                _nomCommune = new NomCommune(_nomCommuneString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"le nom de commune est ""([^""]*)""")]
        public void ThenLeNomDeCommuneEst(string paris)
        {
            Assert.Equal(paris, _nomCommune.Value);
        }

        [Given(@"un nom de commune vide")]
        public void GivenUnNomDeCommuneVide()
        {
            _exception = null;
            try
            {
                _nomCommuneString = "";
                _nomCommune = new NomCommune(_nomCommuneString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"une exception est levee pour la commune avec le message ""([^""]*)""")]
        public void ThenUneExceptionEstLeveePourLaCommuneAvecLeMessage(string p0)
        {
            Assert.NotNull(_exception);
            Assert.Equal(p0, _exception.Message);
        }

        [Given(@"un nom de commune avec plus de (.*) caracteres ""([^""]*)""")]
        public void GivenUnNomDeCommuneAvecPlusDeCaracteres(int p0, string p1)
        {
            _exception = null;
            _nomCommuneString = p1;
            try
            {
                _nomCommune = new NomCommune(_nomCommuneString);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }
    }
}
