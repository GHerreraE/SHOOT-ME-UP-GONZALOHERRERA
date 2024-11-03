/******************************************************************************
** PROGRAMME  Vaisseau.cs                                                    **
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
** Cette classe représente le vaisseau du joueur dans le jeu. Le vaisseau    **
** peut se déplacer horizontalement et tirer des missiles. La classe gère    **
** les points de vie du vaisseau, son affichage dans la console, ainsi que   **
** les actions de tir et de mise à jour des missiles.                        **
******************************************************************************/

using System;

public class Vaisseau
{
    private string _formeVaisseau = "<<|O|>>";   // Forme visuelle du vaisseau
    private int _positionX;                      // Position X actuelle du vaisseau dans la console
    private int _positionY;                      // Position Y actuelle du vaisseau dans la console
    private int _vies;                           // Points de vie actuels du vaisseau
    public bool Tire { get; set; }               // État de tir (True si le vaisseau a tiré un missile)

    public Missile Missile { get; private set; } // Missile actuellement tiré par le vaisseau

    /// <summary>
    /// Constructeur du vaisseau qui initialise sa position et ses points de vie.
    /// </summary>
    /// <param name="x">Position X initiale du vaisseau</param>
    /// <param name="y">Position Y initiale du vaisseau</param>
    /// <param name="vies">Points de vie initiaux du vaisseau</param>
    public Vaisseau(int x, int y, int vies)
    {
        _positionX = x;
        _positionY = y;
        _vies = vies;
    }

    // Propriétés pour accéder aux positions X et Y du vaisseau, ainsi qu'à sa forme et ses points de vie
    public int PosX => _positionX;
    public int PosY => _positionY;
    public string FormeVaisseau => _formeVaisseau;

    // Propriété pour obtenir et modifier les points de vie du vaisseau
    public int Vies
    {
        get => _vies;
        set
        {
            _vies = value;
            MettreAJourAffichageVies(); // Met à jour l'affichage des vies dans la console
        }
    }

    /// <summary>
    /// Affiche le vaisseau dans la console à sa position actuelle.
    /// </summary>
    public void Dessiner()
    {
        Console.SetCursorPosition(_positionX, _positionY);
        Console.Write(_formeVaisseau);
    }

    /// <summary>
    /// Efface le vaisseau de la console en remplaçant sa forme par des espaces.
    /// </summary>
    public void Effacer()
    {
        Console.SetCursorPosition(_positionX, _positionY);
        Console.Write(new string(' ', _formeVaisseau.Length));
    }

    /// <summary>
    /// Déplace le vaisseau vers la gauche ou la droite en fonction de la touche pressée.
    /// Limite le mouvement pour que le vaisseau reste dans les limites de la console.
    /// </summary>
    /// <param name="touche">La touche de direction appuyée par le joueur</param>
    public void Deplacer(ConsoleKeyInfo touche)
    {
        Effacer(); // Efface la position actuelle du vaisseau

        // Déplacement vers la gauche
        if (touche.Key == ConsoleKey.LeftArrow && _positionX > 0)
        {
            _positionX--;
        }
        // Déplacement vers la droite
        else if (touche.Key == ConsoleKey.RightArrow && _positionX < Console.WindowWidth - _formeVaisseau.Length)
        {
            _positionX++;
        }

        Dessiner(); // Affiche le vaisseau à sa nouvelle position
    }

    /// <summary>
    /// Permet au vaisseau de tirer un missile s'il n'y a pas déjà un missile actif.
    /// </summary>
    public void TirerMissile()
    {
        if (!Tire)
        {
            Tire = true;
            Missile = new Missile(_positionX + (_formeVaisseau.Length / 2), _positionY - 1);
        }
    }

    /// <summary>
    /// Met à jour la position du missile tiré par le vaisseau.
    /// Si le missile atteint la limite de la console, il est supprimé.
    /// </summary>
    public void MettreAJourMissile()
    {
        if (Missile != null)
        {
            if (!Missile.Deplacer())
            {
                RestaurerMissile(); // Supprime le missile s'il sort de l'écran
            }
        }
    }

    /// <summary>
    /// Supprime le missile du vaisseau en l'effaçant de la console et en réinitialisant l'état de tir.
    /// </summary>
    public void RestaurerMissile()
    {
        if (Missile != null)
        {
            Missile.Effacer(); // Efface le missile de l'écran
            Missile = null;
        }
        Tire = false; // Réinitialise l'état de tir
    }

    /// <summary>
    /// Met à jour l'affichage des points de vie du vaisseau en haut de l'écran.
    /// </summary>
    public void MettreAJourAffichageVies()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write($"Vies : {_vies}   ");
    }
}
