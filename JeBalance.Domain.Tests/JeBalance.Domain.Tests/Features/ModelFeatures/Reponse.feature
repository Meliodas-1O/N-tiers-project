Feature: Reponses

  Background:
    Given une base de donnees vide

  Scenario: Ajouter une reponse a une denonciation avec succes
    Given une denonciation existante dans la base de donnees
    When j'ajoute une reponse a cette denonciation
    Then la reponse est ajoutee a la base de donnees avec succes

  Scenario: Recevoir une erreur lors de l'ajout d'une reponse avec une retribution inferieure a 1€ pour une confirmation
    Given une denonciation existante dans la base de donnees
    When j'essaie d'ajouter une reponse avec une retribution inferieure a 1 e pour une confirmation
    Then je recois une erreur

  Scenario: Recevoir une erreur lors de la mise a jour d'une reponse avec une retribution inferieure a 1€ pour une confirmation
    Given une reponse existante dans la base de donnees
    When j'essaie de mettre a jour cette reponse avec une retribution inferieure a 1 e pour une confirmation
    Then je recois une erreur

  Scenario: Mettre a jour la retribution d'une reponse avec succes
    Given une reponse existante dans la base de donnees
    When je mets a jour la retribution de cette reponse
    Then la retribution de la reponse est mise a jour avec succes dans la base de donnees

  Scenario: Supprimer une reponse de la base de donnees avec succes
    Given une reponse existante dans la base de donnees
    When je supprime cette reponse de la base de donnees
    Then la reponse est supprimee avec succes de la base de donnees