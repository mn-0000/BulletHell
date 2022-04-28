using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;

namespace TRNBulletHell.Game
{
    class BulletManager
    {

        public void spawnBullets()
        {

            foreach (var enemy in EntityLists.enemyList)
            {
                CreateBullet spawnBullet = new CreateBullet();
                spawnBullet.createBullet(enemy);
            }
        }



    }
}
