using JeBalance.Domain.Models.Person;
using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions
{
	[Binding]
	public class PersonneValidationStepDefinitions
	{
		private Personne personne;
		private Exception validationException;

		[Given(@"I have a new person with first name ""([^""]*)"", last name ""([^""]*)"", type ""([^""]*)"", warning count (.*), and an address with street number (.*), street name ""([^""]*)"", postal code (.*), and commune ""([^""]*)""")]
		public void GivenIHaveANewPersonWithFirstNameLastNameTypeWarningCountAndAnAddressWithStreetNumberStreetNamePostalCodeAndCommune(string john, string doe, string INFORMATEUR, int p3, int p4, string p5, int p6, string p7)
		{
			personne = new Personne(john, doe, ParseTypePersonne(INFORMATEUR), p3, new Adresse(p4, p5, p6, p7));
		}

		[Then(@"the person should be created successfully")]
		public void ThenThePersonShouldBeCreatedSuccessfully()
		{
			Assert.NotNull(personne);
		}

		[Given(@"I have an existing person with first name ""([^""]*)"", last name ""([^""]*)"", type ""([^""]*)"", warning count (.*), and an address with street number (.*), street name ""([^""]*)"", postal code (.*), and commune ""([^""]*)""")]
		public void GivenIHaveAnExistingPersonWithFirstNameLastNameTypeWarningCountAndAnAddressWithStreetNumberStreetNamePostalCodeAndCommune(string jane, string doe, string SUSPECT, int p3, int p4, string p5, int p6, string p7)
		{
			personne = new Personne(1, jane, doe, ParseTypePersonne(SUSPECT), p3, new Adresse(p4, p5, p6, p7));
		}

		[When(@"I update the person with new first name ""([^""]*)"", last name ""([^""]*)"", type ""([^""]*)"", warning count (.*), and an updated address with street number (.*), street name ""([^""]*)"", postal code (.*), and commune ""([^""]*)""")]
		public void WhenIUpdateThePersonWithNewFirstNameLastNameTypeWarningCountAndAnUpdatedAddressWithStreetNumberStreetNamePostalCodeAndCommune(string updatedFirstName, string updatedLastName, string VIP, int p3, int p4, string p5, int p6, string p7)
		{
			personne = new Personne(personne.Id, updatedFirstName, updatedLastName, ParseTypePersonne(VIP), p3, new Adresse(p4, p5, p6, p7));
		}

		[Then(@"the person should be updated successfully")]
		public void ThenThePersonShouldBeUpdatedSuccessfully()
		{
			Assert.NotNull(personne);
		}

		private TypePersonne ParseTypePersonne(string type)
		{
			Enum.TryParse(type, out TypePersonne parsedType);
			return parsedType;
		}
	}
}
