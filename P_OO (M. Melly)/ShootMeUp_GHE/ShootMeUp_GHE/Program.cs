using System;

namespace ShootMeUp_GHE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new Game();

            while (game.IsRunning)
            {
                game.UpdateGame();
            }

            Console.Clear();
            Console.WriteLine("Jeu terminé !");
        }
    }
}
