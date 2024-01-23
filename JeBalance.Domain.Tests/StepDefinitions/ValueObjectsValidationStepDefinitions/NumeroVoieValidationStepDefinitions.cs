using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectsValidationStepDefinitions
{
    [Binding]
    public class NumeroVoieValidationStepDefinitions
    {
        private NumeroVoie streetNumber;
        private int streetNumberValue;
        private Exception validationException;

        [Given(@"I have a street number with value (.*)")]
        public void GivenIHaveAStreetNumberWithValue(int p0)
        {
            streetNumberValue = p0;
            streetNumber = new NumeroVoie(streetNumberValue);
        }

        [Then(@"the street number should be valid")]
        public void ThenTheStreetNumberShouldBeValid()
        {
            Assert.NotNull(streetNumber);
            Assert.Equal(streetNumberValue, streetNumber.Value);
        }

        [Given(@"I have a street number with a value less than (.*)")]
        public void GivenIHaveAStreetNumberWithAValueLessThan(int p0)
        {
            try
            {
                streetNumberValue = p0 - 1;
                streetNumber = new NumeroVoie(streetNumberValue);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Then(@"the NumeroVoie validation should fail with an ApplicationException and the message ""([^""]*)""")]
        public void ThenTheNumeroVoieValidationShouldFailWithAnApplicationExceptionAndTheMessage(string expectedMessage)
        {
            validationException = Assert.Throws<ApplicationException>(() => streetNumber.Validate(streetNumberValue));
            Assert.Equal(expectedMessage, validationException.Message);
        }

        [Given(@"I have a street number with a value greater than (.*)")]
        public void GivenIHaveAStreetNumberWithAValueGreaterThan(int p0)
        {
            try
            {
                streetNumberValue = p0 + 1;
                streetNumber = new NumeroVoie(streetNumberValue);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Given(@"I have a street number with a value equal to (.*)")]
        public void GivenIHaveAStreetNumberWithAValueEqualTo(int p0)
        {
            streetNumberValue = p0;
            streetNumber = new NumeroVoie(streetNumberValue);
        }
    }
}
