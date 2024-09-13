using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootMeUp_GHE
{
    internal class Missile
    {
        /// <summary>
        /// variable pour la forme du vaisseau
        /// </summary>
        public string FormeMissile = "|";

        /// <summary>
        /// variable pour la position du vaisseau par rapport l'axe X
        /// </summary>
        private int _PositionX;

        /// <summary>
        /// variable pour la position du vaisseau par rapport l'axe Y
        /// </summary>
        private int _PositionY;

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
        public Missile(int x, int y, int vies)
        {
            _PositionX = x;
            _PositionY = y;
           
        }


        /// <summary>
        /// méthode pour dessiner le vaisseau
        /// </summary>
        public void Dessiner()
        {
            Console.SetCursorPosition(_PositionX, _PositionY);
            Console.Write(FormeMissile);
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
            if (_PositionX > 0)
            {
                _PositionY--;
            }
        }

        private void MoveRight()
        {
            if (_PositionX > 0)
            {
                _PositionY++;
            }
        }

        public void Move(ConsoleKeyInfo key)
        {
            
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
            }
           
            {
                Clear();
            }

        }
}
