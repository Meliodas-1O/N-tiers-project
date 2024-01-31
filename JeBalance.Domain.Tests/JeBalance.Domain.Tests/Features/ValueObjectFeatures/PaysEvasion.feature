Feature: Pays Evasion

Scenario: Creer un pays d'evasion valide
    Given un pays d'evasion valide "Suisse"
    When le pays d'evasion est cree
    Then le pays d'evasion est "Suisse"

Scenario: Creer un pays d'evasion vide
    Given un pays d'evasion vide
    When le pays d'evasion est cree
    Then une exception est levee pour le pays avec le message "Le PaysEvasion ne peut pas etre vide"

Scenario: Creer un pays d'evasion avec moins de 2 caracteres
    Given un pays d'evasion avec moins de 2 caracteres "A"
    When le pays d'evasion est cree
    Then une exception est levee pour le pays avec le message "Le PaysEvasion ne peut pas avoir moins de 2 caracteres"

Scenario: Creer un pays d'evasion avec plus de 20 caracteres
    Given un pays d'evasion avec plus de 20 caracteres "Lorem ipsum dolor sit amet"
    When le pays d'evasion est cree
    Then une exception est levee pour le pays avec le message "Le PaysEvasion ne peut pas avoir plus de 20 caracteres"
