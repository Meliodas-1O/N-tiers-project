Feature: CodePostal Validation
   Scenario: Validation of Postal Code
       Given I have a postal code with value 12345
       Then the postal code should be valid

       Given I have a postal code with a value less than 10000
       Then the CodePostal validation should fail with an ApplicationException and the message "le Code Postal doit avoir exactement 5 chiffres"

       Given I have a postal code with a value greater than 99999
       Then the CodePostal validation should fail with an ApplicationException and the message "le Code Postal doit avoir exactement 5 chiffres"

       Given I have a postal code with a value equal to 10000
       Then the postal code should be valid

       Given I have a postal code with a value equal to 99999
       Then the postal code should be valid
