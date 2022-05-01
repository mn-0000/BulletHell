using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.BulletPattern;
using TRNBulletHell.Game.Entity.Enemy;

namespace TRNBulletHell.Game
{
    class CreateBullet
    {
        Enemy enemy;


        public void createBullet(Enemy enemy)
        {
            this.enemy = enemy;
            // frequency can determine the different levels.
            //frequency here = 30
            if ((enemy.ProduceBulletcounter % enemy.frequencyOfBullets) == 0)
            {
                if (enemy.type == "midBoss")
                {
                    BulletPatterns bulletPatterns = new BulletPatterns();
                    bulletPatterns.sprayBullets(enemy);

                }
                else
                {
                    BulletPatterns bulletPatterns = new BulletPatterns();
                    bulletPatterns.regular(enemy);
                }
                    
            }
        }
    }
}
