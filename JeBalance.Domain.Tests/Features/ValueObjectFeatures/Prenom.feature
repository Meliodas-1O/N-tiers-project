Feature: Prenom Validation
   Scenario: Validation of Person's First Name
       Given I have a person's first name with value "John"
       Then the person's first name should be valid

       Given I have a person's first name with an empty value
       Then the Prenom validation should fail with an ApplicationException and the message "Le Prenom d'une personne ne peut pas etre vide"

       Given I have a person's first name with more than 50 characters
       Then the Prenom validation should fail with an ApplicationException and the message "Le Prenom d'une personne ne peut pas avoir plus de 50 caracteres"

       Given I have a person's first name with leading and trailing spaces
       Then the person's first name should be valid and trimmed

       Given I have a person's first name with special characters
       Then the person's first name should be valid
