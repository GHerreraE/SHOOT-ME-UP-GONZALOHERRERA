/******************************************************************************
** PROGRAMME  Program.cs                                                     **
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
** Ce programme est le point d'entrée du jeu "Shoot Me Up". Il contient la   **
** logique principale du jeu, y compris l'affichage du menu, la gestion des  **
** scores, le déplacement et les actions des ennemis, ainsi que le système   **
** de collision entre le joueur, les missiles, les ennemis, et les obstacles.**
******************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ShootMeUp_GHE
{
    public class Program
    {
        static List<Ennemi> ennemis = new List<Ennemi>(); // Liste des ennemis dans le jeu
        static List<Missile> missiles = new List<Missile>(); // Liste des missiles en jeu
        static List<Obstacle> obstacles = new List<Obstacle>(); // Liste des obstacles
        static int largeurConsole = Console.WindowWidth; // Largeur de la console
        static int hauteurConsole = Console.WindowHeight; // Hauteur de la console
        static int intervalDeplacementEnnemi = 300; // Intervalle de déplacement des ennemis
        static int score = 0; // Score actuel du joueur
        static int meilleurScore = 0; // Meilleur score enregistré
        static string cheminFichierMeilleurScore = "meilleur_score.txt"; // Chemin du fichier de meilleur score
        static Vaisseau vaisseau; // Instance du vaisseau du joueur

        static void Main(string[] args)
        {
            Console.CursorVisible = false; // Cache le curseur de la console pour une meilleure expérience visuelle
            ChargerMeilleurScore(); // Charge le meilleur score depuis le fichier, s'il existe

            bool enCours = true; // Variable pour contrôler la boucle du menu principal
            while (enCours)
            {
                // Affiche le menu principal et obtient l'option sélectionnée
                int optionSelectionnee = AfficherMenuPrincipal();

                // Gère les actions en fonction de l'option choisie
                switch (optionSelectionnee)
                {
                    case 0:
                        DemarrerJeu(); // Lance une nouvelle partie
                        break;
                    case 1:
                        AfficherMeilleursScoreMenu(); // Affiche le meilleur score
                        break;
                    case 2:
                        AfficherAPropos(); // Affiche les informations sur le jeu
                        break;
                    case 3:
                        enCours = false; // Quitte le jeu
                        break;
                    default:
                        Console.WriteLine("Sélection invalide. Veuillez réessayer.");
                        break;
                }
            }

            // Message de fin de jeu
            Console.Clear();
            Console.WriteLine("Merci d'avoir joué !");
            Console.ReadKey();
        }

        /// <summary>
        /// Affiche le menu principal du jeu avec les options disponibles.
        /// L'utilisateur peut sélectionner une option avec les flèches et valider avec "Entrée".
        /// </summary>
        /// <returns>L'index de l'option sélectionnée</returns>
        static int AfficherMenuPrincipal()
        {
            // Titre du jeu en ASCII
            string titre = @"
    ███████╗██╗  ██╗ ██████╗  ██████╗ ████████╗     ███╗   ███╗███████╗    ██╗   ██╗██████╗ 
    ██╔════╝██║  ██║██╔═══██╗██╔═══██╗╚══██╔══╝     ████╗ ████║██╔════╝    ██║   ██║██╔══██╗
    ███████╗███████║██║   ██║██║   ██║   ██║        ██╔████╔██║█████╗      ██║   ██║██████╔╝
    ╚════██║██╔══██║██║   ██║██║   ██║   ██║        ██║╚██╔╝██║██╔══╝      ██║   ██║██╔═══╝ 
    ███████║██║  ██║╚██████╔╝╚██████╔╝   ██║        ██║ ╚═╝ ██║███████╗    ╚██████╔╝██║     
    ╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝    ╚═╝        ╚═╝     ╚═╝╚══════╝     ╚═════╝ ╚═╝     
    ";

            string[] options = { "Jouer", "Highscore", "À propos", "Quitter" };
            int indexSelectionne = 0;

            while (true)
            {
                Console.Clear(); // Efface la console pour réafficher le menu

                // Centre le titre en ASCII
                int titrePositionX = (largeurConsole - titre.Split('\n').Max(line => line.Length)) / 2;
                foreach (string ligne in titre.Split('\n'))
                {
                    Console.SetCursorPosition(titrePositionX, Console.CursorTop);
                    Console.WriteLine(ligne);
                }

                // Centre les options de menu et met en évidence l'option sélectionnée
                int optionsPositionY = Console.CursorTop + 2;
                for (int i = 0; i < options.Length; i++)
                {
                    int optionPositionX = (largeurConsole - options[i].Length) / 2;
                    Console.SetCursorPosition(optionPositionX, optionsPositionY + i);

                    if (i == indexSelectionne)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {options[i]}"); // Option sélectionnée en vert
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                // Gère les entrées utilisateur pour le menu
                ConsoleKeyInfo touche = Console.ReadKey(true);
                if (touche.Key == ConsoleKey.UpArrow)
                {
                    indexSelectionne = (indexSelectionne == 0) ? options.Length - 1 : indexSelectionne - 1;
                }
                else if (touche.Key == ConsoleKey.DownArrow)
                {
                    indexSelectionne = (indexSelectionne == options.Length - 1) ? 0 : indexSelectionne + 1;
                }
                else if (touche.Key == ConsoleKey.Enter)
                {
                    return indexSelectionne; // Retourne l'option choisie par l'utilisateur
                }
            }
        }

        /// <summary>
        /// Démarre une nouvelle partie en initialisant les variables et en lançant la boucle du jeu.
        /// La boucle continue jusqu'à ce que le joueur perde toutes ses vies.
        /// </summary>
        static void DemarrerJeu()
        {
            score = 0; // Initialise le score
            ennemis.Clear(); // Réinitialise les ennemis
            missiles.Clear(); // Réinitialise les missiles
            obstacles.Clear(); // Réinitialise les obstacles
            Console.Clear(); // Efface la console

            // Initialise le vaisseau du joueur
            vaisseau = new Vaisseau(56, 28, 3);
            vaisseau.Dessiner();
            vaisseau.MettreAJourAffichageVies();
            MettreAJourAffichageScore(); // Affiche le score actuel
            AfficherMeilleurScore(); // Affiche le meilleur score

            // Génère les obstacles et les ennemis pour la nouvelle partie
            GenererObstacles();
            GenererEnnemis();

            DateTime dernierDeplacementEnnemi = DateTime.Now;
            bool jeuEnCours = true;

            // Boucle principale du jeu
            while (jeuEnCours && vaisseau.Vies > 0)
            {
                // Gère les touches utilisateur pour le déplacement et le tir
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo touche = Console.ReadKey(true);
                    vaisseau.Deplacer(touche);

                    // Gère le tir du vaisseau si l'utilisateur appuie sur Espace
                    if (touche.Key == ConsoleKey.Spacebar && !vaisseau.Tire)
                    {
                        missiles.Add(new Missile(vaisseau.PosX + vaisseau.FormeVaisseau.Length / 2, vaisseau.PosY - 1));
                        vaisseau.Tire = true;
                    }
                    else if (touche.Key != ConsoleKey.Spacebar)
                    {
                        vaisseau.Tire = false; // Réinitialise l'état de tir si une autre touche est pressée
                    }
                }

                MettreAJourMissiles(); // Met à jour les missiles
                VerifierCollisions(); // Vérifie les collisions des missiles avec les ennemis et obstacles
                MettreAJourObstacles(); // Affiche les obstacles restants
                AfficherMeilleurScore(); // Affiche le meilleur score en haut à droite

                // Gère le déplacement des ennemis à intervalles réguliers
                if ((DateTime.Now - dernierDeplacementEnnemi).TotalMilliseconds >= intervalDeplacementEnnemi)
                {
                    foreach (var ennemi in ennemis)
                    {
                        ennemi.DeplacerAvecLimites(largeurConsole, hauteurConsole); // Déplace les ennemis
                        ennemi.TenterTir(); // Fait tirer les ennemis avec une probabilité
                    }
                    dernierDeplacementEnnemi = DateTime.Now;
                }

                // Vérifie si un missile ennemi a touché le vaisseau
                foreach (var ennemi in ennemis)
                {
                    if (ennemi.MettreAJourMissile(vaisseau, obstacles) && vaisseau.Vies <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Game Over! Vous avez été touché trop de fois.");
                        jeuEnCours = false; // Arrête la boucle de jeu
                        break;
                    }
                }

                Thread.Sleep(10); // Pause pour adoucir le gameplay
            }

            // Gère l'affichage du score à la fin de la partie
            if (score > meilleurScore)
            {
                meilleurScore = score;
                SauvegarderMeilleurScore(); // Enregistre le nouveau meilleur score
                Console.Clear();
                Console.WriteLine("Nouveau Highscore ! Votre score : " + score);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Game Over ! Votre score : " + score);
            }

            // Affiche le meilleur score final
            Console.WriteLine("Highscore : " + meilleurScore);
            Console.WriteLine("Appuyez sur une touche pour retourner au menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Affichage du meilleur score dans le menu
        /// </summary>
        static void AfficherMeilleursScoreMenu()
        {
            Console.Clear();
            Console.WriteLine("*********** HIGHSCORES ***********");
            Console.WriteLine($"Highscore : {meilleurScore}");
            Console.WriteLine("****************************************");
            Console.WriteLine("Appuyez sur une touche pour retourner au menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Afficher la page a propos
        /// </summary>
        static void AfficherAPropos()
        {
            Console.Clear();
            Console.WriteLine("*********** À PROPOS ***********");
            Console.WriteLine("Shoot Me Up - Un jeu de tir basé sur la console.");
            Console.WriteLine("Créé par : Gonzalo Javier Herrera Egoavil");
            Console.WriteLine("Date : 2024");
            Console.WriteLine("*********************************");
            Console.WriteLine("Appuyez sur une touche pour retourner au menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Met à jour la position et l'état de tous les missiles en cours.
        /// Si un missile atteint la limite supérieure de l'écran ou entre en collision, il est supprimé.
        /// </summary>
        static void MettreAJourMissiles()
        {
            // Parcourt les missiles de la liste en ordre inverse pour éviter les problèmes liés à la suppression d'éléments
            for (int i = missiles.Count - 1; i >= 0; i--)
            {
                missiles[i].Dessiner(); // Affiche le missile à sa position actuelle

                // Déplace le missile vers le haut et vérifie s'il a atteint la limite
                if (!missiles[i].Deplacer())
                {
                    missiles[i].Effacer(); // Efface visuellement le missile de la console
                    missiles.RemoveAt(i);   // Supprime le missile de la liste des missiles actifs
                    vaisseau.Tire = false;  // Indique que le vaisseau peut tirer un autre missile
                }
            }
        }

        /// <summary>
        /// Vérifie les collisions des missiles avec les obstacles et les ennemis.
        /// Supprime les objets concernés en cas de collision et met à jour le score si un ennemi est touché.
        /// </summary>
        static void VerifierCollisions()
        {
            // Parcourt chaque missile pour vérifier les collisions
            foreach (var missile in missiles.ToList())
            {
                bool missileATouche = false; // Indicateur pour suivre si le missile a touché quelque chose

                // Vérification de collision avec les obstacles
                foreach (var obstacle in obstacles.ToList())
                {
                    // Vérifie si le missile est en collision avec l'obstacle
                    if (missile.PositionX >= obstacle.PosX &&
                        missile.PositionX < obstacle.FormeObstacle.Length + obstacle.PosX &&
                        missile.PositionY == obstacle.PosY)
                    {
                        missile.Effacer();         // Efface le missile de la console
                        obstacle.SubirDegat();     // Réduit la vie de l'obstacle
                        missileATouche = true;     // Marque le missile comme ayant touché un obstacle

                        // Vérifie si l'obstacle est détruit après le dégât
                        if (obstacle.PointsDeVie <= 0)
                        {
                            obstacle.EffacerObstacle(); // Efface l'obstacle de la console
                            obstacles.Remove(obstacle); // Retire l'obstacle de la liste des obstacles actifs
                        }

                        missiles.Remove(missile); // Retire le missile de la liste des missiles
                        vaisseau.Tire = false;    // Permet au vaisseau de tirer un autre missile
                        break;                    // Arrête la vérification des autres obstacles pour ce missile
                    }
                }

                // Passe au missile suivant si une collision avec un obstacle a été détectée
                if (missileATouche) continue;

                // Vérification de collision avec les ennemis
                foreach (var ennemi in ennemis.ToList())
                {
                    // Vérifie si le missile est en collision avec l'ennemi
                    if (missile.PositionX >= ennemi.PositionX &&
                        missile.PositionX < ennemi.FormeEnnemi.Length + ennemi.PositionX &&
                        missile.PositionY == ennemi.PositionY)
                    {
                        missile.Effacer();       // Efface le missile de la console
                        ennemi.Effacer();        // Efface l'ennemi de la console

                        missiles.Remove(missile); // Retire le missile de la liste des missiles
                        ennemis.Remove(ennemi);   // Retire l'ennemi de la liste des ennemis

                        score += 10;             // Augmente le score du joueur
                        MettreAJourAffichageScore(); // Met à jour l'affichage du score
                        vaisseau.Tire = false;    // Permet au vaisseau de tirer un autre missile
                        missileATouche = true;    // Marque le missile comme ayant touché un ennemi
                        break;                    // Arrête la vérification des autres ennemis pour ce missile
                    }
                }

                // Si tous les ennemis sont détruits, génère un nouvel ensemble d'ennemis
                if (ennemis.Count == 0)
                {
                    RegenererTousLesEnnemis();
                }
            }
        }

        /// <summary>
        /// Régénère un ensemble complet d'ennemis si tous les ennemis ont été détruits.
        /// </summary>
        static void RegenererTousLesEnnemis()
        {
            int nombreLignes = 3;                   // Nombre de lignes d'ennemis
            int nombreEnnemisParLigne = 10;         // Nombre d'ennemis par ligne
            int debutY = 2;                         // Position Y de départ des ennemis
            int largeurEnnemi = 5;                  // Largeur d'un ennemi

            string[] formesEnnemis = { "[]-[]", "<<*>>", "00+00" }; // Formes possibles des ennemis

            int largeurTotaleEnnemis = nombreEnnemisParLigne * largeurEnnemi; // Largeur totale d'une ligne d'ennemis
            int espaceRestant = Console.WindowWidth - largeurTotaleEnnemis;   // Espace restant sur la console
            int espacementXEnnemi = espaceRestant / (nombreEnnemisParLigne + 1); // Espacement entre chaque ennemi

            // Génération des lignes et colonnes d'ennemis
            for (int ligne = 0; ligne < nombreLignes; ligne++)
            {
                for (int col = 0; col < nombreEnnemisParLigne; col++)
                {
                    int positionX = (col * largeurEnnemi) + ((col + 1) * espacementXEnnemi);
                    int positionY = debutY + ligne * 2;

                    if (positionX + largeurEnnemi <= Console.WindowWidth)
                    {
                        string forme = formesEnnemis[ligne % formesEnnemis.Length];
                        Ennemi ennemi = new Ennemi(forme, 1, positionX, positionY, 10);
                        ennemis.Add(ennemi);       // Ajoute l'ennemi à la liste des ennemis
                        ennemi.Dessiner();         // Dessine l'ennemi sur la console
                    }
                }
            }
        }

        /// <summary>
        /// Génère les obstacles à des positions spécifiques de la console.
        /// </summary>
        static void GenererObstacles()
        {
            int nombreObstacles = 5;               // Nombre total d'obstacles
            int espacement = largeurConsole / (nombreObstacles + 1); // Calcul de l'espacement entre les obstacles
            int positionY = hauteurConsole - 5;    // Position Y des obstacles

            // Crée et affiche chaque obstacle
            for (int i = 0; i < nombreObstacles; i++)
            {
                int positionX = (i + 1) * espacement - 4;
                Obstacle obstacle = new Obstacle(positionX, positionY);
                obstacles.Add(obstacle);            // Ajoute l'obstacle à la liste des obstacles
                obstacle.AfficherObstacle();        // Affiche l'obstacle sur la console
            }
        }

        /// <summary>
        /// Met à jour l'affichage de tous les obstacles ayant encore des points de vie.
        /// </summary>
        static void MettreAJourObstacles()
        {
            // Parcourt chaque obstacle pour afficher ceux qui ont encore des points de vie
            foreach (var obstacle in obstacles)
            {
                if (obstacle.PointsDeVie > 0)
                {
                    obstacle.AfficherObstacle();    // Affiche l'obstacle sur la console
                }
            }
        }

        /// <summary>
        /// Met à jour l'affichage du score actuel du joueur dans la console.
        /// </summary>
        static void MettreAJourAffichageScore()
        {
            int positionXScore = (largeurConsole / 2) - 5; // Position X centrée pour l'affichage du score
            Console.SetCursorPosition(positionXScore, 0);  // Positionne le curseur pour afficher le score
            Console.Write($"Score : {score}   ");          // Affiche le score
        }

        /// <summary>
        /// Affiche le meilleur score dans la console.
        /// </summary>
        static void AfficherMeilleurScore()
        {
            int positionXMeilleurScore = largeurConsole - 25; // Position X pour le meilleur score (à droite)
            Console.SetCursorPosition(positionXMeilleurScore, 0); // Positionne le curseur
            Console.Write($"Highscore : {meilleurScore}   "); // Affiche le meilleur score
        }

        /// <summary>
        /// Charge le meilleur score depuis un fichier texte si le fichier existe.
        /// </summary>
        static void ChargerMeilleurScore()
        {
            if (File.Exists(cheminFichierMeilleurScore))
            {
                string texteMeilleurScore = File.ReadAllText(cheminFichierMeilleurScore);
                int.TryParse(texteMeilleurScore, out meilleurScore); // Convertit et charge le meilleur score
            }
        }

        /// <summary>
        /// Sauvegarde le meilleur score actuel dans un fichier texte.
        /// </summary>
        static void SauvegarderMeilleurScore()
        {
            File.WriteAllText(cheminFichierMeilleurScore, meilleurScore.ToString()); // Écrit le meilleur score dans le fichier
        }

        /// <summary>
        /// Génère les ennemis initiaux et les place à des positions spécifiques.
        /// </summary>
        static void GenererEnnemis()
        {
            int nombreLignes = 3;                   // Nombre de lignes d'ennemis
            int nombreEnnemisParLigne = 10;         // Nombre d'ennemis par ligne
            int debutY = 2;                         // Position Y de départ des ennemis
            int largeurEnnemi = 5;                  // Largeur d'un ennemi

            string[] formesEnnemis = { "[]-[]", "<<*>>", "00+00" }; // Formes possibles des ennemis

            int largeurTotaleEnnemis = nombreEnnemisParLigne * largeurEnnemi;
            int espaceRestant = Console.WindowWidth - largeurTotaleEnnemis;
            int espacementXEnnemi = espaceRestant / (nombreEnnemisParLigne + 1);

            // Crée chaque ennemi et le positionne dans la console
            for (int ligne = 0; ligne < nombreLignes; ligne++)
            {
                for (int col = 0; col < nombreEnnemisParLigne; col++)
                {
                    int positionX = (col * largeurEnnemi) + ((col + 1) * espacementXEnnemi);
                    int positionY = debutY + ligne * 2;

                    if (positionX + largeurEnnemi <= Console.WindowWidth)
                    {
                        string forme = formesEnnemis[ligne % formesEnnemis.Length];
                        Ennemi ennemi = new Ennemi(forme, 1, positionX, positionY, 10);
                        ennemis.Add(ennemi);       // Ajoute l'ennemi à la liste
                        ennemi.Dessiner();         // Dessine l'ennemi sur la console
                    }
                }
            }
        }

    }
}
