using System;
using System.Threading;

namespace ShootMeUp_GHE
{
    internal class Missile
    {
        private int _positionX;
        private int _positionY;
        private readonly string _formeMissile = "|";

        private const int MissileSpeed = 25; // Vitesse du missile (en millisecondes)

        public Missile(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        public void Dessiner()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(_formeMissile);
        }

        public void Clear()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(" "); // Effacer le missile
        }

        public void Shooter()
        {
            if (_positionY > 0)
            {
                Clear(); // Effacer l'ancienne position du missile
                _positionY--; // Déplacer le missile vers le haut
                Dessiner(); // Dessiner le missile à la nouvelle position
                Thread.Sleep(MissileSpeed); // Limiter la vitesse de rafraîchissement du missile
            }
        }
    }
}
