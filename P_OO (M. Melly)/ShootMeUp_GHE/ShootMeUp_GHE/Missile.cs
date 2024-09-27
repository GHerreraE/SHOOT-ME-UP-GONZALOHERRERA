using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// methode pour la mouvement du missile
        /// </summary>
        /// <param name="ShootMissile"></param>
        public void Shooter(bool shootMissile)
        {
            //tant que la position Y ne dépasse pas les limites de la console
            while (_positionY > 0 && _positionY < (Console.WindowHeight - 1))
            {
                Clear(); //efface le missile

                //si le missile est affiché, la position Y decrement pour faire monter le missile
                if (shootMissile == true)
                {
                    _positionY--;
                }
                
                Dessiner(); //affiche le missile

                Thread.Sleep(50); //delai avant de reafficher le missile

                //si le missile sort de la fenêtre ou s'il ne doit plus tirer, on sort de la boucle
                if (_positionY <= 0 || _positionY >= Console.WindowHeight - 1)
                {
                    break;
                }
            }

            Clear(); //efface le missile
        }


    }

}

