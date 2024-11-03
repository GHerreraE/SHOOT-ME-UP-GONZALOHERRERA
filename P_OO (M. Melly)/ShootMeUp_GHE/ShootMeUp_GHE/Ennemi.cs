/******************************************************************************
** PROGRAMME  Ennemi.cs                                                      **
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
** Cette classe représente les ennemis dans le jeu. Chaque ennemi possède    **
** une forme visuelle, une position, des points de vie et la capacité de tirer**
** des missiles. La classe gère le déplacement, le tir, et les collisions    **
** des missiles ennemis avec le vaisseau ou les obstacles. Lorsque l'ennemi  **
** est détruit, il est retiré de l'affichage.                                **
******************************************************************************/

using System;
using System.Collections.Generic;

namespace ShootMeUp_GHE
{
    public class Ennemi
    {
        private string _formeEnnemi;               // Forme visuelle de l'ennemi
        private int _positionX;                    // Position X de l'ennemi dans la console
        private int _positionY;                    // Position Y de l'ennemi dans la console
        private int _vies;                         // Points de vie actuels de l'ennemi
        private int _nbScore;                      // Points rapportés par l'ennemi en cas de destruction
        private int _direction = 1;                // Direction actuelle de déplacement (1: droite, -1: gauche)
        private static Random aleatoire = new Random(); // Générateur aléatoire pour les tirs
        private Missile _missileEnnemi;            // Missile tiré par l'ennemi

        // Propriétés pour accéder aux attributs de l'ennemi
        public string FormeEnnemi => _formeEnnemi;
        public int PositionX => _positionX;
        public int PositionY => _positionY;
        public int Vies => _vies;
        public Missile MissileEnnemi { get; set; }

        /// <summary>
        /// Constructeur de l'ennemi qui initialise sa forme, ses points de vie, sa position, et son score.
        /// </summary>
        /// <param name="formeEnnemi">Forme visuelle de l'ennemi</param>
        /// <param name="vies">Points de vie initiaux de l'ennemi</param>
        /// <param name="positionX">Position X initiale de l'ennemi</param>
        /// <param name="positionY">Position Y initiale de l'ennemi</param>
        /// <param name="nbScore">Score rapporté par l'ennemi lorsqu'il est détruit</param>
        public Ennemi(string formeEnnemi, int vies, int positionX, int positionY, int nbScore)
        {
            _formeEnnemi = formeEnnemi;
            _vies = vies;
            _positionX = positionX;
            _positionY = positionY;
            _nbScore = nbScore;
        }

        /// <summary>
        /// Affiche l'ennemi à sa position actuelle dans la console.
        /// </summary>
        public void Dessiner()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(_formeEnnemi);
        }

        /// <summary>
        /// Efface l'ennemi de la console en remplaçant sa forme par des espaces.
        /// </summary>
        public void Effacer()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(new string(' ', _formeEnnemi.Length));
        }

        /// <summary>
        /// Essaye de tirer un missile avec une probabilité de 5%.
        /// </summary>
        /// <returns>True si un missile est tiré, sinon False</returns>
        public bool TenterTir()
        {
            if (_missileEnnemi == null && aleatoire.Next(0, 200) < 5) // 5% de chance de tirer
            {
                _missileEnnemi = new Missile(_positionX + _formeEnnemi.Length / 2, _positionY + 1);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Met à jour la position et l'état du missile ennemi.
        /// Vérifie les collisions avec les obstacles et le vaisseau du joueur.
        /// </summary>
        /// <param name="vaisseau">Instance du vaisseau du joueur</param>
        /// <param name="obstacles">Liste des obstacles présents dans le jeu</param>
        /// <returns>True s'il y a collision, sinon False</returns>
        public bool MettreAJourMissile(Vaisseau vaisseau, List<Obstacle> obstacles)
        {
            if (_missileEnnemi != null)
            {
                _missileEnnemi.Effacer();

                // Vérifie la collision du missile avec chaque obstacle
                foreach (var obstacle in obstacles)
                {
                    if (_missileEnnemi.PositionX >= obstacle.PosX &&
                        _missileEnnemi.PositionX < obstacle.PosX + obstacle.FormeObstacle.Length &&
                        _missileEnnemi.PositionY == obstacle.PosY)
                    {
                        obstacle.SubirDegat(); // Réduit les points de vie de l'obstacle
                        _missileEnnemi = null; // Supprime le missile après la collision
                        return true;           // Collision détectée avec un obstacle
                    }
                }

                // Vérifie la collision avec le vaisseau du joueur
                if (!_missileEnnemi.DeplacerVersLeBas() ||
                    (_missileEnnemi.PositionX >= vaisseau.PosX &&
                     _missileEnnemi.PositionX < vaisseau.PosX + vaisseau.FormeVaisseau.Length &&
                     _missileEnnemi.PositionY == vaisseau.PosY))
                {
                    if (_missileEnnemi.PositionY == vaisseau.PosY &&
                        _missileEnnemi.PositionX >= vaisseau.PosX &&
                        _missileEnnemi.PositionX < vaisseau.PosX + vaisseau.FormeVaisseau.Length)
                    {
                        vaisseau.Vies--; // Réduit les points de vie du joueur
                        vaisseau.MettreAJourAffichageVies();
                    }

                    _missileEnnemi = null; // Supprime le missile après la collision
                    return true; // Collision détectée avec le joueur ou les limites de l'écran
                }
                else
                {
                    _missileEnnemi.Dessiner();
                }
            }
            return false; // Aucune collision détectée
        }

        /// <summary>
        /// Déplace l'ennemi horizontalement, et descend d'une ligne lorsqu'il atteint les bords de la console.
        /// Met fin au jeu si l'ennemi atteint le bas de la console.
        /// </summary>
        /// <param name="largeurConsole">Largeur de la console</param>
        /// <param name="hauteurConsole">Hauteur de la console</param>
        public void DeplacerAvecLimites(int largeurConsole, int hauteurConsole)
        {
            Effacer(); // Efface l'ennemi à sa position actuelle

            // Change de direction si l'ennemi atteint un bord de la console
            if ((_positionX <= 0 && _direction == -1) || (_positionX + _formeEnnemi.Length >= largeurConsole && _direction == 1))
            {
                _positionY++; // Descend d'une ligne
                _direction *= -1; // Inverse la direction (gauche/droite)
            }
            else
            {
                _positionX += _direction; // Déplacement horizontal
            }

            // Vérifie si l'ennemi a atteint le bas de la console (condition de fin de jeu)
            if (_positionY >= hauteurConsole - 1)
            {
                Console.SetCursorPosition(0, hauteurConsole - 1);
                Console.Write("Game Over! Les ennemis ont atteint le bas.");
                Environment.Exit(0); // Termine le jeu
            }

            Dessiner(); // Redessine l'ennemi à sa nouvelle position
        }

        /// <summary>
        /// Réduit les points de vie de l'ennemi lorsqu'il subit des dégâts.
        /// Supprime l'ennemi de l'affichage s'il est détruit.
        /// </summary>
        /// <returns>True si l'ennemi est détruit, sinon False</returns>
        public bool SubirDegat()
        {
            _vies--;
            if (_vies <= 0)
            {
                Effacer();
                return true; // Indique que l'ennemi est détruit
            }
            return false; // L'ennemi est toujours en vie
        }
    }
}
