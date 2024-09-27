using Microsoft.Win32.SafeHandles;
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
           
            Console.CursorVisible = false;          //desactiver le courseur
            var vaiseau = new Vaisseau(50,28,3);    //création du vaisseau
            
            

            //boucle de jeu
            while (true)
            {
                //designer le vaisseau
                vaiseau.Dessiner();

                //si une touche est pressée, la position du vaisseau change
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    
                    //mouvement du vaisseau
                    vaiseau.Move(key);
                    





                }
                


            }
        }
    }
}
