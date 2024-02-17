Feature: CodePostal

Scenario: Cr�er un code postal valide
    Given un code postal valide 12345
    When le code postal est cree
    Then le code postal est 12345

Scenario: Cr�er un code postal avec moins de 5 chiffres
    Given un code postal avec moins de 5 chiffres 1234
    When le code postal est cree
    Then une exception est levee pour le code postal avec le message "le Code Postal doit avoir exactement 5 chiffres"

Scenario: Cr�er un code postal avec plus de 5 chiffres
    Given un code postal avec plus de 5 chiffres 123456
    When le code postal est cree
    Then une exception est levee pour le code postal avec le message "le Code Postal doit avoir exactement 5 chiffres"
