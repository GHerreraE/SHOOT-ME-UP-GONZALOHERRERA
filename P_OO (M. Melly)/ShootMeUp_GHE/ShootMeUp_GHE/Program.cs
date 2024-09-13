using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShootMeUp_GHE
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.CursorVisible = false;
            var ship = new Vaisseau(55,28,3);


            //Boucle de jeu
            while (true)
            {
 
                //Print objects
                ship.Dessiner();

                //Compute next coordinates
                if(Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    ship.Move(key);
                    
                }
                
                //Waits for sync FPS
                Thread.Sleep(30);
                
            }
        }
    }
}
