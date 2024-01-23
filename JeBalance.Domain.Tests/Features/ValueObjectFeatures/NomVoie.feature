Feature: NomVoie Validation
   Scenario: Validation of Street Name
       Given I have a street name with value "Example Street"
       Then the street name should be valid

       Given I have a street name with an empty value
       Then the validation should fail with an ApplicationException and the message "Le nom d'une voie ne peut pas etre vide"

       Given I have a street name with more than 50 characters
       Then the validation should fail with an ApplicationException and the message "Le nom d'une voie ne peut pas avoir plus de 50 caracteres"

       Given I have a street name with leading and trailing spaces
       Then the street name should be valid and trimmed

       Given I have a street name with special characters
       Then the street name should be valid
