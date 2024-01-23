Feature: DenonciationReponse Validation

  Scenario: Creating a new DenonciationReponse
    Given I have a new DenonciationReponse with timestamp "2024-01-23 10:15:30", type "CONFIRMATION ", and retribution 50
    Then the DenonciationReponse should be created successfully

  Scenario: Updating an existing DenonciationReponse
    Given I have an existing DenonciationReponse with timestamp "2024-01-22 15:45:00", type "CONFIRMATION ", and retribution 30
    When I update the DenonciationReponse with new timestamp "2024-01-23 08:30:00", new type "REJET", and new retribution 25
    Then the DenonciationReponse should be updated successfully
