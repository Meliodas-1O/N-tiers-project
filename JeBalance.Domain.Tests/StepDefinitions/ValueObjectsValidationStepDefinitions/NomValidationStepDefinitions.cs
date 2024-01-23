using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectsValidationStepDefinitions
{
    [Binding]
    public class NomValidationStepDefinitions
    {
        private Nom personName;
        private string personNameString;
        private Exception validationException;
        [Given(@"I have a person's name with value ""([^""]*)""")]
        public void GivenIHaveAPersonsNameWithValue(string p0)
        {
            personNameString = p0;
            personName = new Nom(personNameString);
        }

        [Then(@"the person's name should be valid")]
        public void ThenThePersonsNameShouldBeValid()
        {
            Assert.NotNull(personName);
            Assert.Equal(personNameString, personName.Value);
        }

        [Given(@"I have a person's name with an empty value")]
        public void GivenIHaveAPersonsNameWithAnEmptyValue()
        {
            try
            {
                personNameString = "";
                personName = new Nom(personNameString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }
        [Then(@"the Nom validation should fail with an ApplicationException and the message ""([^""]*)""")]
        public void ThenTheNomValidationShouldFailWithAnApplicationExceptionAndTheMessage(string p0)
        {
            validationException = Assert.Throws<ApplicationException>(() => personName.Validate(personNameString));
            Assert.Equal(p0, validationException.Message);
        }

        [Given(@"I have a person's name with more than (.*) characters")]
        public void GivenIHaveAPersonsNameWithMoreThanCharacters(int p0)
        {
            try
            {
                string longPersonName = new('A', p0 + 1);
                personNameString = longPersonName;
                personName = new Nom(personNameString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Given(@"I have a person's name with leading and trailing spaces")]
        public void GivenIHaveAPersonsNameWithLeadingAndTrailingSpaces()
        {
            personNameString = "   John Doe   ";
            personName = new Nom(personNameString);
        }

        [Then(@"the person's name should be valid and trimmed")]
        public void ThenThePersonsNameShouldBeValidAndTrimmed()
        {
            Assert.NotNull(personName);
            Assert.Equal("John Doe", personName.Value);
        }

        [Given(@"I have a person's name with special characters")]
        public void GivenIHaveAPersonsNameWithSpecialCharacters()
        {
            personNameString = "Special #Name!";
            personName = new Nom(personNameString);
        }
    }
}
