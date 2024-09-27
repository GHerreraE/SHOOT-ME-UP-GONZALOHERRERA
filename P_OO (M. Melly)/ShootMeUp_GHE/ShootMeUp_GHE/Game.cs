using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootMeUp_GHE
{
    internal class Game
    {

        public void ShootPlayerMissile()
        {
            Missile playerMissile;
            playerMissile = null;
            Vaisseau player = new Vaisseau(x: Console.WindowWidth / 2, y: Console.WindowHeight - 2, vies: 3);

            // verifier si un missil est tirer
            if (player.ShotMissile)
            {
                // si il n'y a pas de missile 
                if (playerMissile == null)
                {
                    // creer un nouveau missile 
                    playerMissile = new Missile(player.PositionX + player.FormeVaisseau.Length / 2, player.PositionY - 1);
                }
                else
                {
                    playerMissile.Shooter(true);// faire bouger le missile   
                    // si le missile atteint la hauteur max
                    if (playerMissile.PositionY < 2)
                    {
                        playerMissile.Clear();// effacer la trace du missile 
                        playerMissile = null;// detruir le missile
                        player.ShotMissile = false;// pas de missile tirer
                    }
                    
                }
            }
        }
    }
}
