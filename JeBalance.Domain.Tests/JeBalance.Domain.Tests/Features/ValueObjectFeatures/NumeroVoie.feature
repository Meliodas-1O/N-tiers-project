Feature: NumeroVoie

Scenario: Creer un numero de voie valide
    Given un numero  voie valide 123
    When le numero voie est cree
    Then le numero  voie est 123

Scenario: Creer un numero de voie inferieur a 1
    Given un numero  voie inferieur a 1
    When le numero voie est cree
    Then une exception est levee pour numeroVoie avec message "le Numero de Voie ne peut pas etre inferieur a 1"

Scenario: Creer un numero voie superieur a 999
    Given un numero  voie superieur a 999
    When le numero voie est cree
    Then une exception est levee pour numeroVoie avec message "le Numero de Voie ne peut pas etre superieur a 999"
