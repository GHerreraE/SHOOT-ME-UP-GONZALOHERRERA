/******************************************************************************
** PROGRAMME  Jeu.cs                                                         **
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : Gonzalo Javier Herrera Egoavil                                **
** Date      : 02.11.2024                                                    **
**                                                                           **
** Modifications                                                             **
**   Auteur  :                                                               **
**   Version :                                                               **
**   Date    :                                                               **
**   Raisons :                                                               **
**                                                                           **
******************************************************************************/

/******************************************************************************
** DESCRIPTION                                                               **
** Dans cette classe, on gère le déroulement principal du jeu, incluant la   **
** création du vaisseau, des ennemis, des obstacles et la logique de mise à  **
** jour en temps réel, ainsi que la gestion des entrées de l'utilisateur.    **
******************************************************************************/


using ShootMeUp_GHE;
using System.Collections.Generic;
using System.Threading;
using System;

public class Jeu
{
    private Vaisseau vaisseau;                      // Instance du vaisseau du joueur
    private List<Ennemi> ennemis = new List<Ennemi>(); // Liste des ennemis présents dans le jeu
    private List<Obstacle> obstacles = new List<Obstacle>(); // Liste des obstacles dans le jeu

    /// <summary>
    /// Méthode qui initialise et démarre le jeu, créant le vaisseau,
    /// les obstacles et les ennemis, et boucle pour gérer les entrées
    /// de l'utilisateur et les mises à jour.
    /// </summary>
    public void DemarrerJeu()
    {
        // Crée le vaisseau du joueur avec un nombre de vies initial (3),
        // centré horizontalement dans la console et positionné en bas.
        vaisseau = new Vaisseau(3, (Console.WindowWidth - 1) / 2, 27);

        // TODO: Initialiser les obstacles et les ennemis ici (à implémenter)

        // Boucle principale du jeu qui continue indéfiniment
        while (true)
        {
            // Vérifie si une touche a été pressée
            if (Console.KeyAvailable)
            {
                // Lecture de la touche sans l'afficher dans la console
                var touche = Console.ReadKey(true);

                // Déplace le vaisseau en fonction de la touche pressée
                vaisseau.Deplacer(touche);

                // Si la barre d'espace est pressée, le vaisseau tire un missile
                if (touche.Key == ConsoleKey.Spacebar)
                {
                    vaisseau.TirerMissile(); // Tir d'un missile depuis le vaisseau
                }
            }

            // Met à jour le missile du vaisseau, si un missile est actif
            vaisseau.MettreAJourMissile();

            // Pour chaque ennemi dans la liste des ennemis
            foreach (var ennemi in ennemis)
            {
                // Met à jour le missile de l'ennemi, en vérifiant les collisions
                // avec le vaisseau et les obstacles
                ennemi.MettreAJourMissile(vaisseau, obstacles);
            }

            // Délai court pour rendre les mouvements plus fluides
            Thread.Sleep(50);
        }
    }
}
