Feature: Adresse Validation
   Scenario: Generation of Address Id
       Given I have an address with street number 123, street name "Example Street", postal code 12345, and commune "Sample Commune"
       Then the Id should be generated for the address

   Scenario: Validation of Address Value
       Given I have an address with street number 123, street name "Example Street", postal code 12345, and commune "Sample Commune"
       Then the address value should not be empty or null
