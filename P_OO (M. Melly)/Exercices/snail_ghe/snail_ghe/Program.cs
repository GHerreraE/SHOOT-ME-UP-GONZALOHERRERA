using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace snail_ghe
{

    internal class Snail /* on peut mettre n'importe quel nom*/
    {
        /**** declaration des variables ****/
        /*si la variable est en public, on pourra l'utiliser directement dans le main*/
        /*si la varible est en private, on ne pourra pas l'utiliser directement dans le main, on devra d'utiliser une méthode comme bypass*/
        public string _Snail;
        public int _lifeSnail;
        public int _posX;
        public int _posY;


        /// <summary>
        /// Méthode pour le mouvement et reduction de life du Snail
        /// </summary>
        public void Move()
        {
            _posX++;
            _lifeSnail--;
        }

        /// <summary>
        /// Méthode pour effacer l'écran pour chaque mouvement
        /// </summary>
        public void Hide()
        {
            Console.Clear();
        }


        /// <summary>
        /// Méthode boolean, il vérifie chaque fois si le snail est encore vivant
        /// </summary>
        /// <returns></returns>
        public bool Vivant()
        {
            if (_lifeSnail > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Méthode pour la position du curseur pour chaque deplacement
        /// </summary>
        public void Montrer()
        {
            Console.SetCursorPosition(_posX, _posY);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Corps"></param>
        /// <param name="VieEsc"></param>
        public Snail(string Corps, int VieEsc)
        {
            this._Snail = Corps;
            this._lifeSnail = VieEsc;
        }



        /// <summary>
        /// Permet d'afficher le design du snail
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _Snail;
        }

        static void Main(string[] args)
        {
            Snail snail1 = new Snail("a", 50);
            while (snail1.Vivant())
            {
                Console.WriteLine(snail1.ToString());
                snail1.Move();
                Thread.Sleep(100);
                snail1.Hide();
                snail1.Montrer();
            }


        }
    }

}
