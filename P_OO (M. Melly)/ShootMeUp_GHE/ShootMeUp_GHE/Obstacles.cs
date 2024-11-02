using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootMeUp_GHE
{
    internal class Obstacles
    {
        private string _formeObstacle = "████████"; // la forme de l obstacle
        private int _positionX;                        // position x de l obstacle
        private int _positionY;                        // position y de l obstacle
        private int _vie;                      // la vie de l obstacle

        public string formeObstacle
        {
            get { return _formeObstacle; }
            set { _formeObstacle = value; }
        }

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

        public int vie
        {
            get { return _vie; }
            set { _vie = value; }
        }

        public Obstacles(int PositionX, int PositionY, int vie = 6)
        {
            _positionX = PositionX;
            _positionY = PositionY; 
            _vie = vie;
        }

        public void Dessiner()
        {
            Console.SetCursorPosition(_positionX, _positionY); //changer position
            Console.Write(_formeObstacle);            //afficher la forme
        }

        public void Clear()
        {
            Console.SetCursorPosition(_positionX, _positionY);                //nouvelle position
            Console.Write(new string(' ', _formeObstacle.Length));   //efface l'obstacle avec une nouvelle forme qui fait la longueur de l'obstacle
        }

        public void VieDegats()
        {
            _vie--;
            if (_vie < 0)
            {
                Clear();
            }

        }

        /// <summary>
        /// méthode pour effacer l'obstacle
        /// </summary>
        private void clearObstacle()
        {
            Clear();
        }
    }
}
