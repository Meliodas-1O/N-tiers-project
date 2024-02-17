Feature: Adresse

Scenario: Créer une adresse correct
    Given un numero de voie correct 12
    And un nom de voie "Rue de Treize"
    And un code postal correct 14015
    And un nom de commune "Seize"
    When l'adresse est creee
    Then l'adresse est "12 Rue de Treize, 14015 Seize"

Scenario: Créer une adresse avec un numéro de voie invalide
    Given un numero de voie invalide -1
    And un nom de voie "Rue de Treize"
    And un code postal correct 14015
    And un nom de commune "Seize"
    When l'adresse est creee
    Then une exception est levee pour adresse avec le message "le Numero de Voie ne peut pas etre inferieur a 1"

Scenario: Créer une adresse avec un nom de voie vide
    Given un numero de voie correct 12
    And un nom de voie vide
    And un code postal correct 14015
    And un nom de commune "Seize"
    When l'adresse est creee
    Then une exception est levee pour adresse avec le message "Le nom d'une voie ne peut pas etre vide"

Scenario: Créer une adresse avec un code postal invalide
    Given un numero de voie correct 12
    And un nom de voie "Rue de Treize"
    And un code postal invalide 999999
    And un nom de commune "Seize"
    When l'adresse est creee
    Then une exception est levee pour adresse avec le message "le Code Postal doit avoir exactement 5 chiffres"

Scenario: Créer une adresse avec un nom de commune vide
    Given un numero de voie correct 12
    And un nom de voie "Rue de Treize"
    And un code postal correct 14015
    And un nom de commune null
    When l'adresse est creee
    Then une exception est levee pour adresse avec le message "Le nom de commune ne peut pas etre vide"
