using System;
using System.Threading;

namespace ShootMeUp_GHE
{
    internal class Vaisseau
    {
        private string _formeVaisseau = "<<|O|>>";
        private int _positionX;
        private int _positionY;
        private int _vies;
        private bool _shotMissile = false;

        private const int ShipSpeed = 15; // Vitesse du vaisseau (en millisecondes)

        public Vaisseau(int x, int y, int vies)
        {
            _positionX = x;
            _positionY = y;
            _vies = vies;
        }

        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        public int Vies
        {
            get { return _vies; }
            set { _vies = value; }
        }

        public string FormeVaisseau
        {
            get { return _formeVaisseau; }
            set { _formeVaisseau = value; }
        }

        public bool ShotMissile
        {
            get { return _shotMissile; }
            set { _shotMissile = value; }
        }

        public void Dessiner()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(_formeVaisseau);
        }

        public void Clear()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(new string(' ', _formeVaisseau.Length)); // Effacer le vaisseau
        }

        public void Move(ConsoleKeyInfo key)
        {
            if (_vies > 0)
            {
                if (key.Key == ConsoleKey.LeftArrow && _positionX > 0)
                {
                    Clear();
                    _positionX--;
                }
                else if (key.Key == ConsoleKey.RightArrow && _positionX < Console.WindowWidth - _formeVaisseau.Length)
                {
                    Clear();
                    _positionX++;
                }

                Dessiner();
                Thread.Sleep(ShipSpeed); // Limiter la vitesse de rafraîchissement
            }
        }
    }
}
