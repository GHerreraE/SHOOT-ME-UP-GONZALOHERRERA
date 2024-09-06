
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Snail
{
    internal class Snail
    {
        public string _Snail;
        public int _HPsnail;
        public int _PosX;
        public int _PosY;


        public Snail(string Corps, int VieEsc)
        {
            this._Snail = Corps;
            this._HPsnail = VieEsc;
        }

        public void Move()
        {
            _PosX++;
            _HPsnail--;
        }
        public void Hide()
        {
            Console.Clear();
        }
        public bool IsAlive()
        {
            if(_HPsnail > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Show()
        {
            Console.SetCursorPosition(_PosX,_PosY);
        }
        public override string ToString()
        {
            return _Snail;
        }
        
        static void Main(string[] args)
        {
            Snail snail1 = new Snail("_@_ö", 50);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorVisible = false;

            while (snail1.IsAlive())
            {   

                Console.WriteLine(snail1.ToString());
                snail1.Move();
                Thread.Sleep(100);
                snail1.Hide();
                snail1.Show();
            }

        }
    }
}
