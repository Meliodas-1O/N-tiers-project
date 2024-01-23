using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectsValidationStepDefinitions
{
    [Binding]
    public class NomCommuneValidationStepDefinitions
    {
        private NomCommune communeName;
        private string communeNameString;
        private Exception validationException;

        [Given(@"I have a commune name with value ""([^""]*)""")]
        public void GivenIHaveACommuneNameWithValue(string paris)
        {
            communeNameString = paris;
            communeName = new NomCommune(communeNameString);
        }

        [Then(@"the commune name should be valid")]
        public void ThenTheCommuneNameShouldBeValid()
        {
            Assert.NotNull(communeName);
            Assert.Equal(communeNameString, communeName.Value);
        }

        [Given(@"I have a commune name with an empty value")]
        public void GivenIHaveACommuneNameWithAnEmptyValue()
        {
            try
            {
                communeNameString = "";
                communeName = new NomCommune(communeNameString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Then(@"the NomCommune validation should fail with an ApplicationException and the message ""([^""]*)""")]
        public void ThenTheNomCommuneValidationShouldFailWithAnApplicationExceptionAndTheMessage(string p0)
        {
            validationException = Assert.Throws<ApplicationException>(() => communeName.Validate(communeNameString));
            Assert.Equal(p0, validationException.Message);
        }

        [Given(@"I have a commune name with more than (.*) characters")]
        public void GivenIHaveACommuneNameWithMoreThanCharacters(int p0)
        {
            try
            {
                string longCommuneName = new string('A', p0 + 1);
                communeNameString = longCommuneName;
                communeName = new NomCommune(communeNameString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Given(@"I have a commune name with leading and trailing spaces")]
        public void GivenIHaveACommuneNameWithLeadingAndTrailingSpaces()
        {
            communeNameString = "   Paris   ";
            communeName = new NomCommune(communeNameString);
        }

        [Then(@"the commune name should be valid and trimmed")]
        public void ThenTheCommuneNameShouldBeValidAndTrimmed()
        {
            Assert.NotNull(communeName);
            Assert.Equal("Paris", communeName.Value);
        }

        [Given(@"I have a commune name with special characters")]
        public void GivenIHaveACommuneNameWithSpecialCharacters()
        {
            communeNameString = "Special #Commune!";
            communeName = new NomCommune(communeNameString);
        }
    }
}
