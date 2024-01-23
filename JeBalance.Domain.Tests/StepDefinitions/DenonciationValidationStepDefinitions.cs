using JeBalance.Domain.Models.Denonciation;
using JeBalance.Domain.Models.Person;
using JeBalance.Domain.Models.Reponse;
using JeBalance.Domain.ValueObjects;
using System;
using TechTalk.SpecFlow;

namespace JeBalance.Domain.Tests.StepDefinitions
{
    [Binding]
    public class DenonciationValidationStepDefinitions
    {
        private DateTime Horodatage;
        private Personne Informateur;
        private Adresse AdresseInformateur;
        private Adresse AdresseSuspect;
		private Personne Suspect;
        private Delit Delit;
		private string PaysEvasion;
		private Denonciation Denonciation;


		[Given(@"I have a new denonciation with horodatage ""([^""]*)"",")]

        public void GivenIHaveANewDenonciationWithHorodatage(string p0)
        {
            Horodatage = DateTime.ParseExact(p0, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
		}

		[Given(@"an informateur address with street number (.*), street name ""([^""]*)"", postal code (.*), and commune ""([^""]*)"",")]
		public void GivenAnInformateurAddressWithStreetNumberStreetNamePostalCodeAndCommune(int p0, string p1, int p2, string p3)
		{
			AdresseInformateur = new Adresse (p0, p1, p2, p3 );
		}

		[Given(@"a suspect address with street number (.*), street name ""([^""]*)"", postal code (.*), and commune ""([^""]*)"",")]
		public void GivenASuspectAddressWithStreetNumberStreetNamePostalCodeAndCommune(int p0, string p1, int p2, string p3)
		{
			AdresseSuspect = new Adresse(p0, p1, p2, p3);
		}

		[Given(@"informateur with first name ""([^""]*)"", last name ""([^""]*)"", type ""([^""]*)"", warning count (.*),")]
        public void GivenInformateurWithFirstNameLastNameTypeWarningCount(string john, string doe, string INFORMATEUR, int p3)
        {
            Informateur = new Personne(john,doe,ParseTypePersonne(INFORMATEUR),p3, AdresseInformateur);
        }


        [Given(@"the suspect with first name ""([^""]*)"", last name ""([^""]*)"", type ""([^""]*)"", warning count (.*),")]
        public void GivenTheSuspectWithFirstNameLastNameTypeWarningCount(string jane, string doe, string SUSPECT, int p3)
        {
			Suspect = new Personne(jane, doe, ParseTypePersonne(SUSPECT), p3, AdresseSuspect);
		}

		[Given(@"the delit ""([^""]*)"",")]
        public void GivenTheDelit(string EVASIONFISCALE)
        {
            Delit = ParseTypeDelit(EVASIONFISCALE);
        }

        [Given(@"the paysEvasion ""([^""]*)""")]
        public void GivenThePaysEvasion(string countryXYZ)
        {
            PaysEvasion = countryXYZ;
        }

        [When(@"I create the denonciation")]
        public void WhenICreateTheDenonciation()
        {
            Denonciation = new Denonciation(Horodatage, Informateur, Suspect, Delit, PaysEvasion, null);
            Assert.NotNull(Denonciation);
        }

		[Then(@"the denonciation should be created successfully")]
		public void ThenTheDenonciationShouldBeCreatedSuccessfully()
		{
			Assert.NotNull(Denonciation);
		}

		[Then(@"the horodatage is ""([^""]*)""")]
        public void ThenTheHorodatageIs(string p0)
        {
            Assert.Equal(Denonciation.Horodatage, DateTime.ParseExact(p0, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
        }

        [Then(@"the informateur has first name ""([^""]*)"", last name ""([^""]*)"", type ""([^""]*)"", and warning count (.*)")]
        public void ThenTheInformateurHasFirstNameLastNameTypeAndWarningCount(string john, string doe, string INFORMATEUR, int p3)
        {
            Assert.NotNull(Denonciation.Informateur);
            Assert.Equal(Denonciation.Informateur.Prenom.Value,john);
            Assert.Equal(Denonciation.Informateur.Nom.Value,doe);
            Assert.Equal(Denonciation.Informateur.TypePersonne.ToString(), INFORMATEUR);
            Assert.Equal(Denonciation.Informateur.NombreAvertissement,p3);
        }

        [Then(@"the informateur's address has street number (.*), street name ""([^""]*)"", postal code (.*), and commune ""([^""]*)""")]
        public void ThenTheInformateursAddressHasStreetNumberStreetNamePostalCodeAndCommune(int p0, string p1, int p2, string p3)
        {
			Assert.NotEmpty(Denonciation.Informateur.Adresse.Value);
			Assert.Contains(p0.ToString(), Denonciation.Informateur.Adresse.Value);
			Assert.Contains(p1.ToString(), Denonciation.Informateur.Adresse.Value);
			Assert.Contains(p2.ToString(), Denonciation.Informateur.Adresse.Value);
			Assert.Contains(p3.ToString(), Denonciation.Informateur.Adresse.Value);
		}

		[Then(@"the suspect has first name ""([^""]*)"", last name ""([^""]*)"", type ""([^""]*)"", and warning count (.*)")]
        public void ThenTheSuspectHasFirstNameLastNameTypeAndWarningCount(string jane, string doe, string SUSPECT, int p3)
        {
			Assert.NotNull(Denonciation.Suspect);
			Assert.Equal(Denonciation.Suspect.Prenom.Value, jane);
			Assert.Equal(Denonciation.Suspect.Nom.Value, doe);
			Assert.Equal(Denonciation.Suspect.TypePersonne.ToString(), SUSPECT);
			Assert.Equal(Denonciation.Suspect.NombreAvertissement, p3);
		}

		[Then(@"the suspect's address has street number (.*), street name ""([^""]*)"", postal code (.*), and commune ""([^""]*)""")]
        public void ThenTheSuspectsAddressHasStreetNumberStreetNamePostalCodeAndCommune(int p0, string p1, int p2, string p3)
        {
			Assert.NotNull(Denonciation.Suspect.Adresse);
			Assert.Contains(p0.ToString(), Denonciation.Suspect.Adresse.Value);
			Assert.Contains(p1.ToString(), Denonciation.Suspect.Adresse.Value);
			Assert.Contains(p2.ToString(), Denonciation.Suspect.Adresse.Value);
			Assert.Contains(p3.ToString(), Denonciation.Suspect.Adresse.Value);
		}

		[Then(@"the delit is ""([^""]*)""")]
        public void ThenTheDelitIs(string eVASIONFISCALE)
        {
			Assert.Equal(Denonciation.Delit.ToString(), eVASIONFISCALE);
		}

		[Then(@"the paysEvasion is ""([^""]*)""\.")]
        public void ThenThePaysEvasionIs_(string countryXYZ)
        {
			Assert.Equal(Denonciation.PaysEvasion.Value, countryXYZ);
		}

		private TypePersonne ParseTypePersonne(string type)
		{
			Enum.TryParse(type, out TypePersonne parsedType);
			return parsedType;
		}

		private Delit ParseTypeDelit(string type)
		{
			Enum.TryParse(type, out Delit parsedType);
			return parsedType;
		}
	}
}
