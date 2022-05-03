using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;

namespace TRNBulletHell.Game
{
    public class BulletManager
    {
        public void spawnBullets()
        {
            foreach (var spawners in EntityLists.bulletSpawner)
            {
                CreateBullet spawnBullet = new CreateBullet();
                spawnBullet.createBullet(spawners);
            }
        }



    }
}
