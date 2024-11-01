using System;
using System.Collections.Generic;

namespace ShootMeUp_GHE
{
    internal class Program
    {
        static List<Missile> missiles = new List<Missile>(); // Liste pour stocker les missiles

        static void Main(string[] args)
        {
            Console.CursorVisible = false; // Masquer le curseur

            Vaisseau vaisseau = new Vaisseau(56, 28, 3); // Créer un vaisseau
            bool gameRunning = true;

            while (gameRunning)
            {
                

                // Dessiner le vaisseau
                vaisseau.Dessiner();

                // Dessiner tous les missiles et les déplacer
                for (int i = missiles.Count - 1; i >= 0; i--)
                {
                    missiles[i].Dessiner();
                    missiles[i].Move(true);

                    // Vérifier si le missile est sorti de l'écran
                    if (missiles[i].PositionY < 1)
                    {
                        missiles.RemoveAt(i); // Retirer le missile de la liste s'il sort de l'écran
                    }
                }

                // Gérer les entrées de l'utilisateur
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true); // Lire la touche sans l'afficher

                    // Gérer le mouvement du vaisseau
                    vaisseau.Move(key);

                    // Gérer le tir de missile
                    if (key.Key == ConsoleKey.Spacebar && !vaisseau.Shot)
                    {
                        missiles.Add(new Missile(vaisseau.PositionX + vaisseau.FormeVaisseau.Length / 2, vaisseau.PositionY - 1));
                        vaisseau.Shot = true; // Marquer que le vaisseau a tiré
                    }
                    else if (key.Key != ConsoleKey.Spacebar)
                    {
                        vaisseau.Shot = false; // Réinitialiser le tir si la barre d'espace n'est pas enfoncée
                    }
                }

              

                // Ajouter une pause pour ralentir le jeu
                System.Threading.Thread.Sleep(20); // Ajuster la vitesse du jeu
            }

            Console.Clear();
            Console.WriteLine("Game Over!"); // Afficher un message de fin de jeu
            Console.ReadKey(); // Attendre une touche pour quitter
        }
    }
}
