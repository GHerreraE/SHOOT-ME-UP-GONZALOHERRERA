using System;
using System.Windows.Input;

namespace ShootMeUp_GHE
{
    internal class Vaisseau
    {
        /// <summary>
        /// variable pour la forme du vaisseau
        /// </summary>
        public string FormeVaisseau = "<<O|O>>";

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
        public int Vies;

        /// <summary>
        /// variable pour tirer un missile
        /// </summary>
        public bool ShotMissile = false;

        public int PositionX()
        {
            return _PositionX;
        }

        public int PositionY()
        {
            return _PositionY;
        }


        /// <summary>
        /// constructeur du vaisseau
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="vies"></param>
        /// <returns></returns>
        public Vaisseau (int x, int y, int vies)
        {
            _PositionX = x;
            _PositionY = y;
            Vies = vies;  
        }

       
        /// <summary>
        /// méthode pour dessiner le vaisseau
        /// </summary>
        public void Dessiner()
        {
            Console.SetCursorPosition(_PositionX, _PositionY);
            Console.Write(FormeVaisseau);
        }

        
        /// <summary>
        /// méthode pour nettoyer la console pour chaque déplacement du vaisseau
        /// </summary>
        public void Clear()
        {
            Console.SetCursorPosition(_PositionX, _PositionY);
            Console.Clear();
        }
        
     

        private void MoveLeft()
        {
            if(_PositionX >0)
            {
                _PositionX--;
            }
        }

        private void MoveRight()
        {
            if (_PositionX > 0)
            {
                _PositionX++;
            }
        }

        public void Move(ConsoleKeyInfo key)
        {
            if (Vies > 0)
            {

                if (key.Key == ConsoleKey.LeftArrow && (_PositionX > 0))
                {
                    MoveLeft();
                    Clear();
                }
                else if (key.Key == ConsoleKey.RightArrow && (_PositionX < Console.WindowWidth - FormeVaisseau.Length))
                {
                    MoveRight();
                    Clear();
                }

                Dessiner();
            }else
            {
                Clear();
            }

        }

       

       
    }
}
