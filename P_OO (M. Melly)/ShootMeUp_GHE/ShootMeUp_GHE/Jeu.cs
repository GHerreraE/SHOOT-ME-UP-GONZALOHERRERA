using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Input;
namespace ShootMeUp_GHE
{
    internal class Jeu
    {
        private string _jeuFini = "GAME OVER";
        private const int _ennemiCaracteres = 6;
        private const int _nb_ennemi = 15;
        private List<Ennemi> _listeEnnemi = new List<Ennemi>();
        private List<Ennemi> _effacerEnnemi = new List<Ennemi>();
        private List<Ennemi> _mortEnnemi = new List<Ennemi>();
        private List<Obstacles> _listeObstacle = new List<Obstacles>();
        private int _direction = 0;
        Vaisseau vaisseau;

        private readonly string highscoreFilePath = "highscore.txt";
        private int _highscore = 0;
        private int _currentScore = 0;
        public int highscore
        {
            get
            {
                return _highscore;
            }
            set
            {
                _highscore = value;
            }
        }

        public int Largeur
        {
            get
            {
                int length = vaisseau.FormeVaisseau.Length;
                return length;
            }
        }

        public void GameStart()
        {
            LoadHighscore();
            player = new Player(3, (Console.WindowWidth - 1) / 2, 27);
            player.Show();
            EnemyGenerator();
            ObstacleGenerator();

            DateTime lastEnemyMoveTime = DateTime.Now; // savoir quand l ennemi a 
            int enemyMoveInterval = 200; // millisecondes entre mouvement d'ennemis, a ajuster si il y a besoin

            while (true)
            {
                vaisseau.Dessiner();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    vaisseau.Move(key);
                }

                vaisseau.Dessiner();

                // verifier si assez de temps a passe pour mettre a jour les ennemis
                if ((DateTime.Now - lastEnemyMoveTime).TotalMilliseconds >= enemyMoveInterval)
                {
                    EnemyUpdate();                    // bouger ennemis
                    lastEnemyMoveTime = DateTime.Now; // changer l'heure du mouvement
                }

                if (_listeEnnemi.Count == 0)
                {
                    RespawnEnemies();
                }

                foreach (var enemy in _listeEnnemi)
                {
                    enemy.Move();
                }

                EnemyCollisions();
                CheckEnemyBulletCollision();
                ShowPlayerHealth();
                UpdateObstacles();
                CurrentScore();
            }
        }

      


       
        
        
    }
}


    

