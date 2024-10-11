using System;

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
    public void Draw()
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
    public void Move(bool JoeurMissile)
    {
        Clear();

        // si la position de l'axe Y ne depasse pas la fenêtre -1  
        if ((_positionY < (Console.WindowHeight - 1)))
        {
            // efface la trace du missile
            Clear();

            // si le joeur lance un missile
            if (JoeurMissile == true)
            {
                // decrementation de l'axe Y pour que le missile monte
                _positionY--;
            }

            // appel à la méthode pour afficher le missile
            Draw();
        }
        else
        {
            // effacer le missile
            Clear();
        }
        
    }

}