using JeBalance.Domain.Models.Reponse;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions
{
    [Binding]
    public class DenonciationReponseValidationStepDefinitions
    {
		private DenonciationReponse denonciationReponse;
		private DateTime newTimestamp;
		private TypeReponse newType;
		private int newRetribution;

		[Given(@"I have a new DenonciationReponse with timestamp ""([^""]*)"", type ""([^""]*)"", and retribution (.*)")]
        public void GivenIHaveANewDenonciationReponseWithTimestampTypeAndRetribution(string p0, string positive, int p2)
        {
			denonciationReponse = new DenonciationReponse(DateTime.Parse(p0), Enum.Parse<TypeReponse>(positive), p2);
            newType = denonciationReponse.Type;
            newTimestamp = denonciationReponse.Timestamp;
		}

		[Then(@"the DenonciationReponse should be created successfully")]
        public void ThenTheDenonciationReponseShouldBeCreatedSuccessfully()
        {
			Assert.NotNull(denonciationReponse);
            Assert.Equal(denonciationReponse.Type, newType);
			Assert.Equal(denonciationReponse.Timestamp, newTimestamp);
		}

		[Given(@"I have an existing DenonciationReponse with timestamp ""([^""]*)"", type ""([^""]*)"", and retribution (.*)")]
        public void GivenIHaveAnExistingDenonciationReponseWithTimestampTypeAndRetribution(string p0, string negative, int p2)
        {
			denonciationReponse = new DenonciationReponse(1, DateTime.Parse(p0), Enum.Parse<TypeReponse>(negative), p2);
		}

		[When(@"I update the DenonciationReponse with new timestamp ""([^""]*)"", new type ""([^""]*)"", and new retribution (.*)")]
        public void WhenIUpdateTheDenonciationReponseWithNewTimestampNewTypeAndNewRetribution(string p0, string neutral, int p2)
        {
			this.newTimestamp = DateTime.Parse(p0);
			this.newType = Enum.Parse<TypeReponse>(neutral);
			this.newRetribution = p2;

			denonciationReponse.Timestamp = this.newTimestamp;
			denonciationReponse.Type = this.newType;
			denonciationReponse.Retribution = this.newRetribution;
		}

        [Then(@"the DenonciationReponse should be updated successfully")]
        public void ThenTheDenonciationReponseShouldBeUpdatedSuccessfully()
		{
			Assert.NotNull(denonciationReponse);
			Assert.Equal(newTimestamp, denonciationReponse.Timestamp);
			Assert.Equal(newType, denonciationReponse.Type);
			Assert.Equal(newRetribution, denonciationReponse.Retribution);
		}
	}
}
