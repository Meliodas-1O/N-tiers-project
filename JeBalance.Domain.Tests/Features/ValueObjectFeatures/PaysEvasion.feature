Feature: PaysEvasion Validation
   Scenario: Validation of Evasion Country
       Given I have an evasion country with value "Tax Haven"
       Then the evasion country should be valid

       Given I have an evasion country with an empty value
       Then the PaysEvasion validation should fail with an ApplicationException and the message "Le PaysEvasion ne peut pas etre vide"

       Given I have an evasion country with less than 2 characters
       Then the PaysEvasion validation should fail with an ApplicationException and the message "Le PaysEvasion ne peut pas avoir moins de 2 caracteres"

       Given I have an evasion country with more than 20 characters
       Then the PaysEvasion validation should fail with an ApplicationException and the message "Le PaysEvasion ne peut pas avoir plus de 20 caracteres"

       Given I have an evasion country with leading and trailing spaces
       Then the evasion country should be valid and trimmed

       Given I have an evasion country with special characters
       Then the evasion country should be valid

