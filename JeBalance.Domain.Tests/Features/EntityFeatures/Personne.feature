Feature: Personne Validation
   Scenario: Creating a new Person
       Given I have a new person with first name "John", last name "Doe", type "INFORMATEUR", warning count 0, and an address with street number 123, street name "Example Street", postal code 12345, and commune "Sample Commune"
       Then the person should be created successfully

   Scenario: Updating an existing Person
       Given I have an existing person with first name "Jane", last name "Doe", type "SUSPECT", warning count 2, and an address with street number 456, street name "Test Street", postal code 67890, and commune "Test Commune"
       When I update the person with new first name "UpdatedFirstName", last name "UpdatedLastName", type "VIP", warning count 3, and an updated address with street number 789, street name "Updated Street", postal code 54321, and commune "Updated Commune"
       Then the person should be updated successfully