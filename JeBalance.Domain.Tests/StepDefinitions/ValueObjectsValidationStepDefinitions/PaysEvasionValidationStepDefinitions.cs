using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectsValidationStepDefinitions
{
    [Binding]
    public class PaysEvasionValidationStepDefinitions
    {
        private PaysEvasion evasionCountry;
        private string evasionCountryString;
        private Exception validationException;

        [Given(@"I have an evasion country with value ""([^""]*)""")]
        public void GivenIHaveAnEvasionCountryWithValue(string p0)
        {
            evasionCountryString = p0;
            evasionCountry = new PaysEvasion(evasionCountryString);
        }

        [Then(@"the evasion country should be valid")]
        public void ThenTheEvasionCountryShouldBeValid()
        {
            Assert.NotNull(evasionCountry);
            Assert.Equal(evasionCountryString, evasionCountry.Value);
        }

        [Given(@"I have an evasion country with an empty value")]
        public void GivenIHaveAnEvasionCountryWithAnEmptyValue()
        {
            try
            {
                evasionCountryString = "";
                evasionCountry = new PaysEvasion(evasionCountryString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Then(@"the PaysEvasion validation should fail with an ApplicationException and the message ""([^""]*)""")]
        public void ThenThePaysEvasionValidationShouldFailWithAnApplicationExceptionAndTheMessage(string expectedMessage)
        {
            validationException = Assert.Throws<ApplicationException>(() => evasionCountry.Validate(evasionCountryString));
            Assert.Equal(expectedMessage, validationException.Message);
        }

        [Given(@"I have an evasion country with less than (.*) characters")]
        public void GivenIHaveAnEvasionCountryWithLessThanCharacters(int p0)
        {
            try
            {
                string shortEvasionCountry = new string('A', p0 - 1);
                evasionCountryString = shortEvasionCountry;
                evasionCountry = new PaysEvasion(evasionCountryString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Given(@"I have an evasion country with more than (.*) characters")]
        public void GivenIHaveAnEvasionCountryWithMoreThanCharacters(int p0)
        {
            try
            {
                string longEvasionCountry = new string('A', p0 + 1);
                evasionCountryString = longEvasionCountry;
                evasionCountry = new PaysEvasion(evasionCountryString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Given(@"I have an evasion country with leading and trailing spaces")]
        public void GivenIHaveAnEvasionCountryWithLeadingAndTrailingSpaces()
        {
            evasionCountryString = "   Tax Haven   ";
            evasionCountry = new PaysEvasion(evasionCountryString);
        }

        [Then(@"the evasion country should be valid and trimmed")]
        public void ThenTheEvasionCountryShouldBeValidAndTrimmed()
        {
            Assert.NotNull(evasionCountry);
            Assert.Equal("Tax Haven", evasionCountry.Value);
        }

        [Given(@"I have an evasion country with special characters")]
        public void GivenIHaveAnEvasionCountryWithSpecialCharacters()
        {
            evasionCountryString = "Special #Country!";
            evasionCountry = new PaysEvasion(evasionCountryString);
        }
    }
}
