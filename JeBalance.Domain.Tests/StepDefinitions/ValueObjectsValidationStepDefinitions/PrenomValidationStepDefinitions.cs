using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions.ValueObjectsValidationStepDefinitions
{
    [Binding]
    public class PrenomValidationStepDefinitions
    {
        private Prenom firstName;
        private string firstNameString;
        private Exception validationException;

        [Given(@"I have a person's first name with value ""([^""]*)""")]
        public void GivenIHaveAPersonsFirstNameWithValue(string john)
        {
            firstNameString = john;
            firstName = new Prenom(firstNameString);
        }

        [Then(@"the person's first name should be valid")]
        public void ThenThePersonsFirstNameShouldBeValid()
        {
            Assert.NotNull(firstName);
            Assert.Equal(firstNameString, firstName.Value);
        }

        [Given(@"I have a person's first name with an empty value")]
        public void GivenIHaveAPersonsFirstNameWithAnEmptyValue()
        {
            try
            {
                firstNameString = "";
                firstName = new Prenom(firstNameString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Then(@"the Prenom validation should fail with an ApplicationException and the message ""([^""]*)""")]
        public void ThenThePrenomValidationShouldFailWithAnApplicationExceptionAndTheMessage(string p0)
        {
            validationException = Assert.Throws<ApplicationException>(() => firstName.Validate(firstNameString));
            Assert.Equal(p0, validationException.Message);
        }

        [Given(@"I have a person's first name with more than (.*) characters")]
        public void GivenIHaveAPersonsFirstNameWithMoreThanCharacters(int p0)
        {
            try
            {
                string longFirstName = new string('A', p0 + 1);
                firstNameString = longFirstName;
                firstName = new Prenom(firstNameString);
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
        }

        [Given(@"I have a person's first name with leading and trailing spaces")]
        public void GivenIHaveAPersonsFirstNameWithLeadingAndTrailingSpaces()
        {
            firstNameString = "   John   ";
            firstName = new Prenom(firstNameString);
        }

        [Then(@"the person's first name should be valid and trimmed")]
        public void ThenThePersonsFirstNameShouldBeValidAndTrimmed()
        {
            Assert.NotNull(firstName);
            Assert.Equal("John", firstName.Value);
        }

        [Given(@"I have a person's first name with special characters")]
        public void GivenIHaveAPersonsFirstNameWithSpecialCharacters()
        {
            firstNameString = "Special #Name!";
            firstName = new Prenom(firstNameString);
        }
    }
}
