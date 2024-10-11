using System;
using System.Threading;

namespace ShootMeUp_GHE
{
    internal class Vaisseau
    {
        /// <summary>
        /// constante pour la forme du vaiseau
        /// </summary>
        private string _formeVaisseau = "<<|O|>>";

        /// <summary>
        /// possition du vaisseau par rapport l'axe X
        /// </summary>
        private int _positionX;

        /// <summary>
        /// possition du vaisseau par rapport l'axe Y
        /// </summary>
        private int _positionY;

        /// <summary>
        /// nombre de vies du vaisseau
        /// </summary>
        private int _vies;

        /// <summary>
        /// boolean pour tirer un missile 
        /// </summary>
        private bool  _shot = false;

        /// <summary>
        /// constructeur du vaisseau
        /// </summary>
        /// <param name="x"> possition X </param>
        /// <param name="y"> possition Y </param>
        /// <param name="vies"> nombre de vies </param>
        public Vaisseau(int x, int y, int vies)
        {
            _positionX = x;
            _positionY = y;
            _vies = vies;
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
        /// recuperer le nombre de vies du vaisseau
        /// </summary>
        public int Vies
        {
            get { return _vies; }
            set { _vies = value; }
        }

        /// <summary>
        /// retourn  
        /// </summary>
        public bool Shot
        {
            get { return _shot; }
            set { _shot = value; }
        }

        /// <summary>
        /// recuperer la forme du vaiseau
        /// </summary>
        public string FormeVaisseau
        {
            get { return _formeVaisseau; }
            private set { _formeVaisseau = value; }
        }

        /// <summary>
        /// méthode pour dessiner le vaisseau
        /// </summary>
        public void Dessiner()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(_formeVaisseau);
        }

        /// <summary>
        /// méthode pour effacer le vaisseau pendat qu'il bouge
        /// </summary>
        public void Clear()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write("       ");
        }

        /// <summary>
        /// méthode pour le mouvement du vaisseau
        /// </summary>
        /// <param name="key"></param>
        public void Move(ConsoleKeyInfo key)
        {
            // si le nombre de vies du vaisseau est supérieur à 0
            if (_vies > 0)
            {
                // si la touche gauche est pressée et la position de l'axe X ne depasse pas la fenêtre
                if (key.Key == ConsoleKey.LeftArrow && _positionX > 0)
                {
                    //efface le missile
                    Clear();

                    // decrementation de l'axe X pour que le vaisseau bouge à gauche
                    _positionX--;
                }

                // si la touche gauche est pressée et la position de l'axe Y ne depasse pas la fenêtre
                if (key.Key == ConsoleKey.RightArrow && _positionX < Console.WindowWidth - _formeVaisseau.Length)
                { 
                    //efface le missile
                    Clear();

                    // Augmentation de l'axe X pour que le vaisseau bouge à droite
                    _positionX++;
                }

                //si la touche space est pressée et aucun missile est tiré
                if ((key.Key == ConsoleKey.Spacebar) && (_shot = false))
                {
                    Shot = true;
                }

                //appel de la méthode pour dessiner le vaisseau
                Dessiner();
            }
            else
            {
                //efface l'écran
                Clear();
            }
        }
    }

}
