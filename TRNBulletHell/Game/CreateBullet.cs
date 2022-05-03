using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.BulletPattern;
using TRNBulletHell.Game.Entity.Enemy;

namespace TRNBulletHell.Game
{
    class CreateBullet
    {


        public void createBullet(BulletSpawn spawner)
        {
            // frequency can determine the different levels.
            //frequency here = 30
            if ((spawner.FollowingEnemy.ProduceBulletcounter % (spawner.FollowingEnemy.frequencyOfBullets * GameOptions.GetDifficultyOffset())) == 0)
            {
                if (spawner.FollowingEnemy.type == "enemyA")
                {
                    BulletPatterns bulletPatterns = new BulletPatterns();
                    bulletPatterns.regular(spawner);
                }
                else if (spawner.FollowingEnemy.type == "enemyB")
                {
                    BulletPatterns bulletPatterns = new BulletPatterns();
                    bulletPatterns.sprayBullets(spawner);
                }
                else if (spawner.FollowingEnemy.type == "midBoss")
                {
                    BulletRopePattern brp = new BulletRopePattern();
                    brp.RopePattern(spawner);
                }
                else if (spawner.FollowingEnemy.type == "finalBoss")
                {
                    BulletRopePattern brp = new BulletRopePattern();
                    brp.RopePattern(spawner);
                }

            }
        }
    }
}
