/******************************************************************************
** PROGRAMME  Obstacle.cs                                                    **
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
** Cette classe représente les obstacles dans le jeu. Chaque obstacle a une  **
** position (X et Y), une forme visuelle et des points de vie. Les obstacles **
** peuvent être affichés, effacés de la console, et peuvent subir des dégâts **
** jusqu'à leur destruction. Lorsqu'un obstacle est détruit, il est effacé   **
** de l'écran.                                                               **
******************************************************************************/

using System;

namespace ShootMeUp_GHE
{
    public class Obstacle
    {
        private string _formeObstacle = "████████"; // Forme visuelle de l'obstacle
        private int _posX;                         // Position X de l'obstacle dans la console
        private int _posY;                         // Position Y de l'obstacle dans la console
        private int _pointsDeVie;                  // Points de vie actuels de l'obstacle

        /// <summary>
        /// Constructeur de la classe Obstacle qui initialise la position et les points de vie.
        /// </summary>
        /// <param name="posX">Position X de l'obstacle</param>
        /// <param name="posY">Position Y de l'obstacle</param>
        /// <param name="pointsDeVie">Points de vie de l'obstacle, par défaut à 5</param>
        public Obstacle(int posX, int posY, int pointsDeVie = 5)
        {
            _posX = posX;
            _posY = posY;
            _pointsDeVie = pointsDeVie;
        }

        // Propriété en lecture seule pour la forme de l'obstacle
        public string FormeObstacle => _formeObstacle;

        // Propriété en lecture seule pour les points de vie de l'obstacle
        public int PointsDeVie => _pointsDeVie;

        // Propriétés en lecture seule pour la position X et Y
        public int PosX => _posX;
        public int PosY => _posY;

        // Propriété indiquant si l'obstacle est détruit (true si points de vie <= 0)
        public bool Detruit => _pointsDeVie <= 0;

        /// <summary>
        /// Affiche visuellement l'obstacle dans la console à sa position actuelle.
        /// </summary>
        public void AfficherObstacle()
        {
            if (_pointsDeVie > 0) // Vérifie que l'obstacle n'est pas détruit
            {
                Console.SetCursorPosition(_posX, _posY);
                Console.Write(_formeObstacle);
            }
        }

        /// <summary>
        /// Réduit les points de vie de l'obstacle lorsqu'il subit un dégât.
        /// Si les points de vie atteignent zéro, l'obstacle est effacé de l'écran.
        /// </summary>
        public void SubirDegat()
        {
            _pointsDeVie--; // Diminue les points de vie de l'obstacle

            if (_pointsDeVie <= 0)
            {
                EffacerObstacle(); // Efface visuellement l'obstacle s'il est détruit
            }
        }

        /// <summary>
        /// Efface l'obstacle de l'écran en remplaçant sa forme par des espaces.
        /// </summary>
        public void EffacerObstacle()
        {
            Console.SetCursorPosition(_posX, _posY);
            Console.Write(new string(' ', _formeObstacle.Length));
        }
    }
}
