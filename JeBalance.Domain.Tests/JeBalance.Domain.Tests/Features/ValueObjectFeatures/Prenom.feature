Feature: Validation du prenom d'une personne

Scenario: Creer un prenom valide
    Given un prenom valide "Jean"
    When le prenom est cree
    Then le prenom est "Jean"

Scenario: Creer un prenom vide
    Given un prenom vide
    When le prenom est cree
    Then une exception est levee pour le prenom avec le message "Le Prenom d'une personne ne peut pas etre vide"

Scenario: Creer un prenom avec plus de 50 caracteres
    Given un prenom avec plus de 50 caracteres "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sed odio a odio tempus condimentum."
    When le prenom est cree
    Then une exception est levee pour le prenom avec le message "Le Prenom d'une personne ne peut pas avoir plus de 50 caracteres"