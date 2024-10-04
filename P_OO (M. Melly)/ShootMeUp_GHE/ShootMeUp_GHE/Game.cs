using System;

namespace ShootMeUp_GHE
{
    internal class Game
    {
        private readonly Vaisseau _vaisseau;
        private bool _isRunning;

        public Game()
        {
            Console.Clear();
            _vaisseau = new Vaisseau(Console.WindowWidth / 2, Console.WindowHeight - 1, 3); // Position initiale du vaisseau
            _isRunning = true;
        }

        public void UpdateGame()
        {
            // Gestion de la saisie utilisateur
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true); // Lire la touche sans l'afficher
                if (key.Key == ConsoleKey.Escape) // Quitter le jeu
                {
                    _isRunning = false;
                    return;
                }
                else if (key.Key == ConsoleKey.Spacebar) // Tirer un missile
                {
                    _vaisseau.ShotMissile();
                }

                _vaisseau.Move(key); // Déplacer le vaisseau
            }
        }

        public bool IsRunning => _isRunning; // Propriété pour vérifier si le jeu est en cours
    }
}
