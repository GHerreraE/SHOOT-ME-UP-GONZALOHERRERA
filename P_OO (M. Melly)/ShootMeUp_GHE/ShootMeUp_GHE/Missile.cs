/******************************************************************************
** PROGRAMME  Missile.cs                                                     **
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
** Cette classe représente les missiles tirés par le joueur ou les ennemis   **
** dans le jeu. Chaque missile a une position X et Y, une forme visuelle, et **
** peut être déplacé vers le haut ou le bas. La classe inclut des méthodes   **
** pour dessiner, effacer, et déplacer le missile, ainsi que pour vérifier   **
** s'il est toujours dans les limites de la console.                         **
******************************************************************************/

using System;

public class Missile
{
    private int _positionX;                    // Position X actuelle du missile dans la console
    private int _positionY;                    // Position Y actuelle du missile dans la console
    private readonly string _formeMissile = "│"; // Forme visuelle du missile

    /// <summary>
    /// Constructeur de la classe Missile qui initialise la position du missile.
    /// </summary>
    /// <param name="x">Position X initiale du missile</param>
    /// <param name="y">Position Y initiale du missile</param>
    public Missile(int x, int y)
    {
        _positionX = x;
        _positionY = y;
    }

    // Propriétés pour obtenir la position X et Y du missile
    public int PositionX => _positionX;
    public int PositionY => _positionY;

    /// <summary>
    /// Affiche le missile à sa position actuelle dans la console.
    /// </summary>
    public void Dessiner()
    {
        Console.SetCursorPosition(_positionX, _positionY);
        Console.Write(_formeMissile);
    }

    /// <summary>
    /// Efface le missile de sa position actuelle dans la console.
    /// </summary>
    public void Effacer()
    {
        Console.SetCursorPosition(_positionX, _positionY);
        Console.Write(" ");
    }

    /// <summary>
    /// Déplace le missile vers le haut de la console, en diminuant la position Y.
    /// Retourne false si le missile atteint la limite de la console.
    /// </summary>
    /// <returns>True si le missile est encore actif, False s'il atteint la limite</returns>
    public bool Deplacer()
    {
        Effacer(); // Efface le missile de sa position actuelle

        // Vérifie si le missile est toujours en dessous de la ligne 2
        if (_positionY > 2) // Limite pour laisser les 2 premières lignes pour l'affichage du score
        {
            _positionY--;  // Déplace le missile vers le haut
            Dessiner();    // Redessine le missile à sa nouvelle position
            return true;   // Indique que le missile est toujours actif
        }
        else
        {
            return false;  // Le missile a atteint la limite de la console (ligne 2)
        }
    }

    /// <summary>
    /// Déplace le missile vers le bas de la console, en augmentant la position Y.
    /// Retourne false si le missile atteint la limite inférieure de la console.
    /// </summary>
    /// <returns>True si le missile est encore actif, False s'il atteint la limite inférieure</returns>
    public bool DeplacerVersLeBas()
    {
        Effacer(); // Efface le missile de sa position actuelle

        // Vérifie si le missile est toujours au-dessus de la limite inférieure de la console
        if (_positionY < Console.WindowHeight - 1)
        {
            _positionY++; // Déplace le missile vers le bas
            Dessiner();   // Redessine le missile à sa nouvelle position
            return true;  // Indique que le missile est toujours actif
        }
        else
        {
            return false; // Le missile a atteint la limite inférieure de la console
        }
    }
}
