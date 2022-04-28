using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Enemy;

namespace TRNBulletHell.Game
{
    class CreateBullet
    {
        Enemy enemy;
        public void shootBullet()
        {

            PlayerBullet bullet = new PlayerBullet(GameDriver.textureList[1]);
            bullet.movement.direction = new Vector2(0, -1);
            bullet.movement.position = new Vector2();
            bullet.movement.position.X = enemy.movement.position.X;
            bullet.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bullet);
        }

        public void createBullet(Enemy enemy)
        {
            this.enemy = enemy;
            // frequency can determine the different levels.
            //frequency here = 30
            if ((enemy.ProduceBulletcounter % enemy.frequencyOfBullets) == 0)
            {
                shootBullet();
            }
        }
    }
}
