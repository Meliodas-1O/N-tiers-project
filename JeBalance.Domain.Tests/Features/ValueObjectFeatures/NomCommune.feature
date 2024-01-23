Feature: NomCommune Validation
   Scenario: Validation of Commune Name
       Given I have a commune name with value "Paris"
       Then the commune name should be valid

       Given I have a commune name with an empty value
       Then the NomCommune validation should fail with an ApplicationException and the message "Le nom de commune ne peut pas etre vide"

       Given I have a commune name with more than 50 characters
       Then the NomCommune validation should fail with an ApplicationException and the message "Le nom de commune ne peut pas avoir plus de 50 caracteres"

       Given I have a commune name with leading and trailing spaces
       Then the commune name should be valid and trimmed

       Given I have a commune name with special characters
       Then the commune name should be valid
