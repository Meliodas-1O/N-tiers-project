Feature: Nom

Scenario: Creer un nom valide
    Given un nom valide "John"
    When le nom est cree
    Then le nom est "John"

Scenario: Creer un nom vide
    Given un nom vide
    When le nom est cree
    Then une exception est levee avec le message "Le nom d'une personne ne peut pas etre vide"

Scenario: Creer un nom avec plus de 50 caracteres
    Given un nom avec plus de 50 caracteres "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sed odio a odio tempus condimentum."
    When le nom est cree
    Then une exception est levee avec le message "Le nom d'une personne ne peut pas avoir plus de 50 caracteres"
