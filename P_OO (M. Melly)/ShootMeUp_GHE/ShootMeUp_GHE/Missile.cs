using System;
using System.Threading;

internal class Missile
{
    /// <summary>
    /// possition du vaisseau par rapport l'axe X
    /// </summary>
    private int _positionX;

    /// <summary>
    /// possition du vaisseau par rapport l'axe Y
    /// </summary>
    private int _positionY;

    /// <summary>
    /// constante pour la forme du missile 
    /// </summary>
    private string _formeMissile = "│";

    private DateTime lastMoveTime;
    private static int moveInterval = 30;

    /// <summary>
    /// constructeur du missile
    /// </summary>
    /// <param name="x">possition sur X</param>
    /// <param name="y">position sur Y</param>
    public Missile(int x, int y)
    {
        _positionX = x;
        _positionY = y;
    }

    /// <summary>
    /// recuperer la position sur l'axe X
    /// </summary>
    public int PositionX
    {
        get { return _positionX; }
        set { _positionX = value; }
    }

    /// <summary>
    /// recuperer la position sur l'axe Y
    /// </summary>
    public int PositionY
    {
        get { return _positionY; }
        set { _positionY = value; }
    }

    /// <summary>
    /// méthode pour dessiner le missile  
    /// </summary>
    public void Dessiner()
    {
        Console.SetCursorPosition(_positionX, _positionY);
        Console.Write(_formeMissile);
    }

    /// <summary>
    /// méthode pour effacer le missile pendat qu'il bouge
    /// </summary>
    public void Clear()
    {
        Console.SetCursorPosition(_positionX, _positionY);
        Console.Write(" ");
    }

    /// <summary>
    /// méthode pour le mouvement du missile 
    /// </summary>
    public bool Move()
    {
        // cache la balle
        Clear();

        // si la balle est toujours à l'intérieur de la zone jouable (Y > 0)
        if (_positionY > 0)
        {
            // déplace la balle vers le haut
            _positionX--;
            // affiche la balle à sa nouvelle position
            Dessiner();
            // ajoute un délai de 30 milisecondes
            Thread.Sleep(30);
            // retourne true car la balle existe toujours
            return true;
        }
        else
            // si la balle atteint le bord elle "meurt"
            return false;
    }

    public bool MoveDown()
    {
        // vérifie si le délai est fini depuis le dernier mouvement
        if ((DateTime.Now - lastMoveTime).TotalMilliseconds >= moveInterval)
        {
            Clear(); // efface la balle

            _positionY++; // incremente la position y
            lastMoveTime = DateTime.Now; // met à jour le dernier mouvement

            // si la balle est toujours dans la console
            if (_positionY < Console.WindowHeight)
            {
                Move(); // affiche la balle dans la nouvelle position
                return true;
            }
            else
            {
                return false; // false si la balle a depasser la console
            }
        }
        return true; // si le délai est fini alors il retourne true
    }

}