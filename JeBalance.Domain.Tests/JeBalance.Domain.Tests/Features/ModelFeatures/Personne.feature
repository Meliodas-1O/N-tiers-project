Feature: Personnes

Scenario: Ajouter une nouvelle personne
    Given une base de donnees vide
    And j'ajoute une personne avec:
        | Prenom  | Nom       | Type         | Avertissements | Adresse                        |
        | "Jean"  | "Dupont"  | "CALOMNIATEUR" | 0            | "12 Rue de Paris, 75001 Paris" |
    Then la personne est ajoutee

Scenario: Changer le type d'une personne 
    Given une personne existante dans la base de donnees:
        | Prénom  | Nom       | Type   | Avertissements | Adresse                        |
        | "Jean"  | "Dupont"  | "NONE" | 0            | "12 Rue de Paris, 75001 Paris" |
    When je mets a jour le type de cette personne a "VIP"
    And je recherche cette personne dans la base de donnees
    Then le type de la personne est changee

Scenario: Supprimer une personne 
    Given une personne existante dans la base de donnees avec:
        | Prénom  | Nom       | Type         | Avertissements | Adresse                        |
        | "Jean"  | "Dupont"  | "CALOMNIATEUR" | 0            | "12 Rue de Paris, 75001 Paris" |
    When je supprime cette personne de la base de donnees
    Then la personne est supprimee

Scenario: Recuperer une personne de type "VIP" 
    Given une personne de type "VIP" existante dans la base de donnees avec:
        | Prénom  | Nom       | Type   | Avertissements | Adresse                        |
        | "Jean"  | "Dupont"  | "VIP"  | 0            | "12 Rue de Paris, 75001 Paris" |
    When je recupere cette personne de la base de donnees
    Then je recois la personne de type "VIP"

Scenario: Rechercher des personnes specifiques
    Given une base de donnees contenant plusieurs personnes
    And chaque personne a les caracteristiques suivantes:
        | Prénom  | Nom       | Type         | Avertissements | Adresse                        |
        | "Jean"  | "Dupont"  | "CALOMNIATEUR" | 2            | "12 Rue de Paris, 75001 Paris" |
        | "Alice" | "Durand"  | "VIP"        | 1            | "15 Rue de Lyon, 69001 Lyon"   |
        | "Marc"  | "Lefevre" | "CALOMNIATEUR" | 0            | "8 Rue de Marseille, 13001 Marseille" |
        | "Sophie"| "Martin"  | "VIP"        | 3            | "20 Rue de Lille, 59000 Lille" |
    When je recherche des personnes avec des criteres specifiques
    Then je recois les personnes correspondantes selon les criteres specifies
