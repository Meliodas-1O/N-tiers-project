Feature: Denonciatoin

Scenario: Creer une denonciation avec des informations completes
    Given une base de donnees vide
    And un horodatage de "2024-01-30T08:00:00"
    And une denonciation avec les informations suivantes:
        | Informateur   | Suspect    | Delit         | PaysEvasion | ReponseId |
        | "Jean"        | "Alice"    | "DISSIMULATIONREVENU"| "France"    |           |
    When j'ajoute une denonciation avec ces informations
    Then la denonciation est ajoutee e la base de donnees avec succes

Scenario: Creer une denonciation sans reponse
    Given une base de donnees contenant plusieurs denonciations
    And un horodatage de "2024-01-30T08:00:00"
    And une denonciation avec les informations suivantes:
        | Informateur   | Suspect    | Delit         | PaysEvasion | ReponseId |
        | "Jean"        | "Alice"    | "DISSIMULATIONREVENU"| "France"    |           |
    When j'ajoute une denonciation avec ces informations
    Then la denonciation est ajoutee e la base de donnees avec succes

Scenario: Creer une denonciation avec reponse
    Given une base de donnees contenant plusieurs denonciations
    And un horodatage de "2024-01-30T08:00:00"
    And une denonciation avec les informations suivantes:
        | Informateur   | Suspect    | Delit         | PaysEvasion | ReponseId |
        | "Jean"        | "Alice"    | "EVASIONFISCALE"| "France"    | "123"     |
    When j'ajoute une denonciation avec ces informations
    Then la denonciation est ajoutee e la base de donnees avec succes

Scenario: Lire une denonciation existante
    Given une base de donnees contenant plusieurs denonciations
    When je recherche une denonciation par son identifiant
    Then je recois la denonciation correspondante

Scenario: Mettre e jour la reponse d'une denonciation
    Given une base de donnees contenant plusieurs denonciations
    And une denonciation existante avec une reponse
    When je mets e jour la reponse de la denonciation
    Then la reponse de la denonciation est mise e jour avec succes

Scenario: Supprimer une denonciation
    Given une base de donnees contenant plusieurs denonciations
    When je supprime une denonciation par son identifiant
    Then la denonciation est supprimee avec succes de la base de donnees
