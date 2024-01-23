Feature: NumeroVoie Validation
   Scenario: Validation of Street Number
       Given I have a street number with value 123
       Then the street number should be valid

       Given I have a street number with a value less than 1
       Then the NumeroVoie validation should fail with an ApplicationException and the message "le Numero de Voie ne peut pas etre inferieur a 1"

       Given I have a street number with a value greater than 999
       Then the NumeroVoie validation should fail with an ApplicationException and the message "Le Numero de Voie ne peut pas etre superieur a 999"

       Given I have a street number with a value equal to 1
       Then the street number should be valid

       Given I have a street number with a value equal to 999
       Then the street number should be valid
