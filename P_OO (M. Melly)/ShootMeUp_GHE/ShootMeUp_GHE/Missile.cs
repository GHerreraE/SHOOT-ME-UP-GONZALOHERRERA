using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace ShootMeUp_GHE
{
    internal class Missile
    {
        /// <summary>
        /// variable pour la position de l'axe X
        /// </summary>
        private int _positionX;

        /// <summary>
        /// variable pour la position de l'axe Y
        /// </summary>
        private int _positionY;

        /// <summary>
        /// variable pour la forme du missile
        /// </summary>
        private string _formeMissile = "│";

        /// <summary>
        /// constructeur du missile
        /// </summary>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="formeMissile"></param>
        public Missile(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        /// <summary>
        /// retourne la position de l'axe X
        /// </summary>
        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        /// <summary>
        /// retourne la position de l'axe Y
        /// </summary>
        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        
        /// <summary>
        /// méthode pour designer le missile
        /// </summary>
        public void Dessiner()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(_formeMissile);
        }

        /// <summary>
        /// méthode pour effacer le missile pour chaque déplacement
        /// </summary>
        public void Clear()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(" ");//remplacer le symbole par un espace vide
        }

        public void Update(bool PlayerAttack)
        {
            // jusqu'a la fin de la fenetre - 1 le missile est dessine, si non il est efface  
            if (_positionY < (Console.WindowHeight - 1))
            {
                Clear();// effacer la trace du missile 
                if (PlayerAttack == true)
                {
                    _positionY--;// decrementation de Y pour que le missile monte
                    
                }
                else
                {
                    _positionY++;
                }
                Dessiner();// afficher le missile
            }
            else
            {
                Clear();// effacer le missile
            }
        }

    }
}
