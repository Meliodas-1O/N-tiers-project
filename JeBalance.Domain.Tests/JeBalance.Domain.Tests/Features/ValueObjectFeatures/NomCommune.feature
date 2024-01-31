Feature: Nom Commune

Scenario: Creer un nom de commune valide
    Given un nom de commune valide "Paris"
    When le nom de commune est cree
    Then le nom de commune est "Paris"

Scenario: Creer un nom de commune vide
    Given un nom de commune vide
    When le nom de commune est cree
    Then une exception est levee pour la commune avec le message "Le nom de commune ne peut pas etre vide"

Scenario: Creer un nom de commune avec plus de 50 caracteres
    Given un nom de commune avec plus de 50 caracteres "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam sed odio a odio tempus condimentum."
    When le nom de commune est cree
    Then une exception est levee pour la commune avec le message "Le nom de commune ne peut pas avoir plus de 50 caracteres"
