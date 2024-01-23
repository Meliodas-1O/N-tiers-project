using JeBalance.Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectsValidationStepDefinitions
{
    [Binding]
    public class CodePostalValidationStepDefinitions
    {
        private CodePostal postalCode;
        private int postalCodeValue;
        private Exception validationException;

        [Given(@"I have a postal code with value (.*)")]
        public void GivenIHaveAPostalCodeWithValue(int p0)
        {
            postalCodeValue = p0;
            postalCode = new CodePostal(postalCodeValue);
        }

        [Then(@"the postal code should be valid")]
        public void ThenThePostalCodeShouldBeValid()
        {
            Assert.NotNull(postalCode);
            Assert.Equal(postalCodeValue, postalCode.Value);
        }

        [Given(@"I have a postal code with a value less than (.*)")]
        public void GivenIHaveAPostalCodeWithAValueLessThan(int p0)
        {
            try
            {
                postalCodeValue = p0 - 1;
                postalCode = new CodePostal(postalCodeValue);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Then(@"the CodePostal validation should fail with an ApplicationException and the message ""([^""]*)""")]
        public void ThenTheCodePostalValidationShouldFailWithAnApplicationExceptionAndTheMessage(string expectedMessage)
        {
            validationException = Assert.Throws<ApplicationException>(() => postalCode.Validate(postalCodeValue));
            Assert.Equal(expectedMessage, validationException.Message);
        }

        [Given(@"I have a postal code with a value greater than (.*)")]
        public void GivenIHaveAPostalCodeWithAValueGreaterThan(int p0)
        {
            try
            {
                postalCodeValue = p0 + 1;
                postalCode = new CodePostal(postalCodeValue);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Given(@"I have a postal code with a value equal to (.*)")]
        public void GivenIHaveAPostalCodeWithAValueEqualTo(int p0)
        {
            postalCodeValue = p0;
            postalCode = new CodePostal(postalCodeValue);
        }
    }
}
