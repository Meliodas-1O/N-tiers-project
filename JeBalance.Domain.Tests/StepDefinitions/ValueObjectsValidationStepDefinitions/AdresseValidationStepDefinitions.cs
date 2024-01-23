using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectsValidationStepDefinitions
{
    [Binding]
    public class AdresseValidationStepDefinitions
    {
        private Adresse address;
        private string generatedId;
        private string addressValue;
        private Exception validationException;

        [Given(@"I have an address with street number (.*), street name ""([^""]*)"", postal code (.*), and commune ""([^""]*)""")]
        public void GivenIHaveAnAddressWithStreetNumberStreetNamePostalCodeAndCommune(int p0, string p1, int p2, string p3)
        {
            try
            {
                address = new Adresse(p0, p1, p2, p3);
                addressValue = $"{p0} {p1}, {p2} {p3}";
                generatedId = address.Id;
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
;
        }

        [Then(@"the Id should be generated for the address")]
        public void ThenTheIdShouldBeGeneratedForTheAddress()
        {
            Assert.NotNull(address);
            Assert.NotNull(generatedId);
            Assert.False(string.IsNullOrWhiteSpace(generatedId));
        }

        [Then(@"the address value should not be empty or null")]
        public void ThenTheAddressValueShouldNotBeEmptyOrNull()
        {
            Assert.NotNull(address);
            Assert.NotNull(address.Validate(addressValue));
        }
    }
}
