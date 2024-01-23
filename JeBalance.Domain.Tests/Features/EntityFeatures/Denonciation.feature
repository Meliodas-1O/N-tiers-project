Feature: Denonciation Validation

Scenario: Creating a new Denonciation
    Given I have a new denonciation with horodatage "2024-02-01 12:00:00",
      And an informateur address with street number 123, street name "Example Street", postal code 12345, and commune "Sample Commune",
      And informateur with first name "John", last name "Doe", type "INFORMATEUR", warning count 0,
      And a suspect address with street number 456, street name "Test Street", postal code 67890, and commune "Test Commune",
      And the suspect with first name "Jane", last name "Doe", type "SUSPECT", warning count 2,
      And the delit "EVASIONFISCALE",
      And the paysEvasion "CountryXYZ"
    When I create the denonciation
    Then the denonciation should be created successfully
      And the horodatage is "2024-02-01 12:00:00"
      And the informateur has first name "John", last name "Doe", type "INFORMATEUR", and warning count 0
      And the informateur's address has street number 123, street name "Example Street", postal code 12345, and commune "Sample Commune"
      And the suspect has first name "Jane", last name "Doe", type "SUSPECT", and warning count 2
      And the suspect's address has street number 456, street name "Test Street", postal code 67890, and commune "Test Commune"
      And the delit is "EVASIONFISCALE"
      And the paysEvasion is "CountryXYZ".