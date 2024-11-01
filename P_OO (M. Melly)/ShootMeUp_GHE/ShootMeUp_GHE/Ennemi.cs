using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootMeUp_GHE
{
    internal class Ennemi
    {

        private string _formeEnnemi;
        private int _positionX;
        private int _positionY;
        private int _vies;
        private int _nbScore;
        private bool _missileEtat;
        private static Random random = new Random();
        public Missile _missilesEnnemi;



        public string formeEnnemi
        {
            get
            {
                return _formeEnnemi;
            }
            set
            {
                _formeEnnemi = value;
            }
        }

        public int positionX
        {
            get
            {
                return _positionX;
            }
            set
            {
                _positionX = value;
            }
        }

        public int positionY
        {
            get
            {
                return _positionY;
            }
            set
            {
                _positionY = value;
            }
        }

        public int vies
        {
            get
            {
                return _vies;
            }
            set
            {
                _vies = value;
            }
        }

        public int nbScore
        {
            get
            {
                return _nbScore;
            }
            set
            {
                _nbScore = value;
            }
        }

        public Ennemi(string formeEnnemi, int vie, int positionX, int positionY, int nbScore)
        {
            _formeEnnemi = formeEnnemi;
            _vies = vie;
            _positionX = positionX;
            _positionY = positionY;
            _nbScore = nbScore;
        }

        public void Dessiner()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(_formeEnnemi);
        }

        public void Clear()
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.Write(new string(' ', _formeEnnemi.Length)); // Efface l'ennemi
        }

        public void Move(int direction)
        {
            Clear();

            // Tableau de mouvements : droite, bas, gauche, haut
            int[] mouvementX = { 1, 0, -1, 0 }; // Changement de position X
            int[] mouvementY = { 0, 1, 0, -1 }; // Changement de position Y

            // Appliquer le mouvement
            _positionX += mouvementX[direction];
            _positionY += mouvementY[direction];

            // Vérification des limites de la fenêtre
            _positionX = Clamp(_positionX, 0, Console.WindowWidth - 1);
            _positionY = Clamp(_positionY, 0, Console.WindowHeight - 1);
            Dessiner();
        }

        private int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public void TirerMissile()
        {
            // Créer un missile si aucun n'est présent
            if (_missilesEnnemi == null)
            {
                _missilesEnnemi = new Missile(_positionX + 2, _positionY + 1);
            }
        }

        public void UpdateMissile()
        {
            // Vérifier si le missile est présent
            if (_missilesEnnemi != null)
            {
                _missilesEnnemi.Clear();
                _missilesEnnemi.PositionY--;

                // Vérifier si le missile est toujours dans la fenêtre
                if (_missilesEnnemi.PositionY >= 0)
                {
                    _missilesEnnemi.Dessiner();
                }
                else
                {
                    // Si le missile sort de l'écran, le supprimer
                    _missilesEnnemi = null;
                }
            }
        }


        public void UpdateEnemyBullet()
        {
            //si la balle nest pas null
            if (_missilesEnnemi != null)
            {
                bool isInBounds = _missilesEnnemi.MoveDown(); //variable qui prend la valeur selon la méthode
                // si la balle sort
                if (!isInBounds)
                {
                    _missilesEnnemi = null; //balle devient null
                    _missileEtat = false; //ennemi ne tire plus
                }
            }
        }
    }
}
