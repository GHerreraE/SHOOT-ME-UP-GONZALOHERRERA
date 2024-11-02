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
        private bool _missileEtat = false;
        private static Random random = new Random();
        public Missile _missilesEnnemi;
        private int compteurShot = 300;
        private int compteur = 0;



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
            //effacer l'ennemi
            Clear();
            //si cest 0 il bouge a droite
            if (direction == 0)
            {
                _positionX++;
            }
            //si cest 1 il bouge en bas  
            else if (direction == 1)
            {
                _positionY++;
            }
            //si c'est 2 il bouge a gauche
            else if (direction == 2)
            {
                _positionY--;
            }
            Dessiner();// montrer l'ennemi a sa nouvelle position
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

        public void MoveTwo()
        {
            //si le compteur est plus haut que le cooldown
            if (compteur >= compteurShot)
            {
                int shootChance = random.Next(0, 450); //variable qui prend la valeur mise au hasard

                //si le nombre est 1 est que l'ennemi est pas entrain de tirer
                if (shootChance < 1 && _missilesEnnemi == null)
                {
                    TirerMissile(); // alors l ennemi tire 
                }

                compteur = 0; //mettre le compteur a 0
            }
            else
            {
                compteur++; //sinon incrementer
            }

            UpdateEnemyBullet();
        }

        public void ResetEnemyBullet()
        {
            _missilesEnnemi = null;  // la balle est nulle
            _missileEtat = false;  // le joueur ne tire pas
        }
    }
}
