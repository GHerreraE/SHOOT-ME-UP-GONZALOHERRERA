using System;
using System.Windows.Input;

namespace ShootMeUp_GHE
{
    internal class Vaisseau
    {
        /// <summary>
        /// variable pour la forme du vaisseau
        /// </summary>
        private string _FormeVaisseau = "<<|O|>>";

        /// <summary>
        /// variable pour la position du vaisseau par rapport l'axe X
        /// </summary>
        private int _PositionX;

        /// <summary>
        /// variable pour la position du vaisseau par rapport l'axe Y
        /// </summary>
        private int _PositionY;

        /// <summary>
        /// variable pour le nombre de vies du vaisseau
        /// </summary>
        private int _Vies;

        /// <summary>
        /// variable pour tirer un missile
        /// </summary>
        private bool _ShotMissile = false;

        /// <summary>
        /// constructeur du vaisseau
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="vies"></param>
        /// <returns></returns>
        public Vaisseau(int x, int y, int vies)
        {
            _PositionX = x;
            _PositionY = y;
            _Vies = vies;        
        }

        /// <summary>
        /// retourne la position de l'axe Y
        /// </summary>
        public int PositionY
        {
            get { return _PositionY; }
            set { _PositionY = value; }
        }

        /// <summary>
        /// retourne la position de l'axe X
        /// </summary>
        public int PositionX
        {
            get { return _PositionX; }
            set { _PositionX = value; }
        }

        /// <summary>
        /// retourne la valeur de la vie du vaisseau
        /// </summary>
        public int Vies
        {
            get { return _Vies; }
            set { _Vies = value; }
        }

        /// <summary>
        /// retourne les caractères de la forme du vaisseau
        /// </summary>
        public string FormeVaisseau
        {
            get { return _FormeVaisseau; }
            set { _FormeVaisseau = value; }
        }

        /// <summary>
        /// retourne le boolean du shot du missile
        /// </summary>
        public bool ShotMissile
        {
            get { return _ShotMissile; }
            set { _ShotMissile = value; }
        }

        /// <summary>
        /// méthode pour dessiner le vaisseau
        /// </summary>
        public void Dessiner()
        {
            Console.SetCursorPosition(_PositionX, _PositionY); // Positionner chaque ligne
            Console.Write(_FormeVaisseau);
        }

        /// <summary>
        /// méthode pour nettoyer la console pour chaque déplacement du vaisseau
        /// </summary>
        public void Clear()
        {
            Console.SetCursorPosition(_PositionX, _PositionY); // Effacer chaque ligne
            Console.Write("       "); // Remplir de blancs
        }

        /// <summary>
        /// méthode pour le mouvement du vaisseau
        /// </summary>
        public void Move(ConsoleKeyInfo key)
        {
            //si le vaisseau a plus que 0 de vie
            if (_Vies > 0)
            {
                //si la fleche gauche est pressée et la position du vaisseau ne depasse pas la fenetre
                if (key.Key == ConsoleKey.LeftArrow && _PositionX > 0)
                {
                    Clear();
                    _PositionX--;
                }

                //si la fleche droite est pressée et la position du vaisseau ne depasse pas la fenetre pour l'expandir
                if (key.Key == ConsoleKey.RightArrow && _PositionX < Console.WindowWidth - _FormeVaisseau.Length)
                {
                    Clear();
                    _PositionX++;
                }

                // si la touche espace est prese et que auccun missile a ete tire
                if (key.Key == ConsoleKey.Spacebar && (_ShotMissile == false))
                {
                    _ShotMissile = true; //tirer
                }

                Dessiner(); //appel de la méthode
            }
            else
            {
                //efface l'écran
                Clear();
            }
        }

    }





}

