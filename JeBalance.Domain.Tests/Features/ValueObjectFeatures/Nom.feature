Feature: Nom Validation
   Scenario: Validation of Person's Name
       Given I have a person's name with value "John Doe"
       Then the person's name should be valid

       Given I have a person's name with an empty value
       Then the Nom validation should fail with an ApplicationException and the message "Le nom d'une personne ne peut pas etre vide"

       Given I have a person's name with more than 50 characters
       Then the Nom validation should fail with an ApplicationException and the message "Le nom d'une personne ne peut pas avoir plus de 50 caracteres"

       Given I have a person's name with leading and trailing spaces
       Then the person's name should be valid and trimmed

       Given I have a person's name with special characters
       Then the person's name should be valid
