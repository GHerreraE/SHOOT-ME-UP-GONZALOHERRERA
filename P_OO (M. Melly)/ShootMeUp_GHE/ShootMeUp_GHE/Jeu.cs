using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public void JeuGo()
        {
            LoadHighscore();
            vaisseau = new Vaisseau(3, (Console.WindowWidth - 1) / 2, 27);
            vaisseau.Move();
            DessinerEnnemi();
            DessinerObstacle();

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
                    EnnemiRespawn();
                }

                foreach (var enemy in _listeEnnemi)
                {
                    enemy.MoveTwo();
                }

                EnemyCollisions();
                CheckEnemyBulletCollision();
                ShowPlayerHealth();
                MoveTwoObstacles();
                CurrentScore();
            }

            
        }

        public void DessinerEnnemi()
        {
            //calcul pour l'espacement entre les ennemis
            int espaces = (Console.WindowWidth - 1) / _nb_ennemi;   //variable pour mettre l espace entre chaque ennemi

            //boucle for pour la géneration des ennemi
            for (int i = 0; i < _nb_ennemi; i++)
            {
                int posX = (i + 1) * espaces;               //variable pour la position X de chaque ennemi

                var ennemi1 = new Ennemi("||*||", 1, posX, 3, 30);    //variable pour stocker un nouveau ennemi
                _listeEnnemi.Add(ennemi1);                             //ajout d un ennemi type 1 dans la liste
                ennemi1.Dessiner();                                 //affichage d un ennemi type 1 dans la console

                var ennemi2 = new Ennemi("##*##", 2, posX, 5, 20);    //variable pour stocker un nouveau ennemi
                _listeEnnemi.Add(ennemi2);                             //ajout d un ennemi type 2 dans la liste
                ennemi2.Dessiner();                                 //affichage d un ennemi type 2 dans la console

                var ennemi3 = new Ennemi("{}*{}", 3, posX, 7, 10);    //variable pour stocker un nouveau ennemi
                _listeEnnemi.Add(ennemi3);                             //ajout d un ennemi type 3 dans la liste
                ennemi3.Dessiner();                                 //affichage d un ennemi type 3 dans la console
            }
        }

        public void DessinerObstacle()
        {
            int positionY = vaisseau.PositionY - 2;    //variable pour la position y de l'obstacle
            int obstacleSpacing = 30;              //espacement entre les obstacles

            //boucle pour afficher les obstacles avec l'espacement
            for (int i = -1; i <= 1; i++)
            {
                int positionX = vaisseau.PositionX + (i * obstacleSpacing); //variable pour la position x qui prend une nouvelle valeur en fonction de i
                Obstacles obstacle = new Obstacles(positionX, positionY); //on instancie des obstacles
                _listeObstacle.Add(obstacle);   //ajouter l'obstacle dans la liste
                obstacle.Dessiner();    //afficher l'obstacle
            }

        }

        public void MoveTwoObstacles()
        {
            //boucle pour mettre a jour un obstacle
            foreach (var obstacle in _listeObstacle)
            {
                //si l obstacle a plus que 0 de vie
                if (obstacle.vie > 0)
                {
                    obstacle.Dessiner(); //on l'affiche
                }
            }
        }

        public void EnnemiRespawn()
        {
            _listeEnnemi.Clear(); // effacer les ennemis
            DessinerEnnemi();   // générer de nouveaux ennemis 
        }


        public void Collision()
        {
            //variable pour utiliser la balle du joueur
            var missile = vaisseau.missile;

            //si la balle est null
            if (missile == null) return;

            //pour chaque ennemi dans _enemyList on verifie la collision
            foreach (Ennemi ennemi in _listeEnnemi)
            {
                //si la position x de la balle est a la meme que l ennemi, ainsi que la position y
                if (bullet.PositionX >= ennemi.positionX && bullet.PositionX <= (ennemi.positionX + ennemi.formeEnnemi.Length - 1) && (missile.PositionY - 1) == ennemi.positionY)
                {
                    bullet.Clear();                  //cacher la balle
                    vaisseau.ResetBullet();           //reinitialiser la balle
                    enemy.HideEnemy();              //cacher ennemi
                    _enemiesToRemove.Add(enemy);    //ajouter ennemi dans la table des enemis supprimés
                    _deadEnemies.Add(enemy);        //ajouter ennemi dans la table des ennemis morts(table pour être utilisée dans la méthode Highscore)
                    break;

                }
            }
            //chaque ennemi dans la table _enemiesToRemove sera efface dans la table _enemyList
            foreach (var enemy in _enemiesToRemove)
            {
                _enemyList.Remove(enemy);   //effacer ennemi
            }
        }



    }
}


    

