using JeBalance.Domain.ValueObjects;


namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectsValidationStepDefinitions
{
    [Binding]
    public class NomVoieValidationStepDefinitions
    {
        private NomVoie nomVoie;
        private string nomVoieString;
        private Exception validationException;

        [Given(@"I have a street name with value ""([^""]*)""")]
        public void GivenIHaveAStreetNameWithValue(string streetNameValue)
        {
            nomVoieString = streetNameValue;
            nomVoie = new NomVoie(nomVoieString);
        }

        [Then(@"the street name should be valid")]
        public void ThenTheStreetNameShouldBeValid()
        {
            Assert.NotNull(nomVoie);
            Assert.Equal(nomVoieString, nomVoie.Value);
        }

        [Given(@"I have a street name with an empty value")]
        public void GivenIHaveAStreetNameWithAnEmptyValue()
        {
            try
            {
                nomVoieString = "";
                nomVoie = new NomVoie(nomVoieString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Then(@"the validation should fail with an ApplicationException and the message ""(.*)""")]
        public void ThenTheValidationShouldFailWithAnApplicationExceptionAndTheMessageForNom(string expectedMessage)
        {
            validationException = Assert.Throws<ApplicationException>(() => nomVoie.Validate(nomVoieString));
            Assert.Equal(expectedMessage, validationException.Message);
        }


        [Given(@"I have a street name with more than (.*) characters")]
        public void GivenIHaveAStreetNameWithMoreThanCharacters(int maxLength)
        {
            try
            {
                nomVoieString = new('A', maxLength + 1);
                nomVoie = new NomVoie(nomVoieString);
            }
            catch (ApplicationException ex)
            {
                validationException = ex;
            }
        }

        [Given(@"I have a street name with leading and trailing spaces")]
        public void GivenIHaveAStreetNameWithLeadingAndTrailingSpaces()
        {
            nomVoieString = "   Example Street   ";
            nomVoie = new NomVoie(nomVoieString);
        }

        [Then(@"the street name should be valid and trimmed")]
        public void ThenTheStreetNameShouldBeValidAndTrimmed()
        {
            Assert.NotNull(nomVoie);
            Assert.Equal("Example Street", nomVoie.Value);
        }

        [Given(@"I have a street name with special characters")]
        public void GivenIHaveAStreetNameWithSpecialCharacters()
        {
            nomVoieString = "Special #Street!";
            nomVoie = new NomVoie(nomVoieString);
        }
    }

}

