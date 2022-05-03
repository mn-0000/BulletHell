using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;

namespace TRNBulletHell.Game.Entity.BulletPattern
{
    public class BulletRopePattern
    {

        public BulletRopePattern()
        {
         
        }
         
        public void RopePattern(BulletSpawn enemy)
        {
            // Right
            PlayerBullet bullet1 = new PlayerBullet(EntityTextures.textureList[1]);
            bullet1.movement.direction = enemy.movement.direction;
            bullet1.movement.position.X = enemy.movement.position.X + 40;
            bullet1.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bullet1);

            // Left
            PlayerBullet bullet2 = new PlayerBullet(EntityTextures.textureList[1]);
            bullet2.movement.direction = enemy.movement.direction;
            bullet2.movement.position.X = enemy.movement.position.X - 40;
            bullet2.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bullet2);

            // Left -> down
            PlayerBullet bullet3 = new PlayerBullet(EntityTextures.textureList[1]);
            bullet3.movement.direction = enemy.movement.direction;
            bullet3.movement.position.X = enemy.movement.position.X - 40;
            bullet3.movement.position.Y = enemy.movement.position.Y + 34;
            EntityLists.enemyBulletList.Add(bullet3);

            // Right -> down
            PlayerBullet bullet4 = new PlayerBullet(EntityTextures.textureList[1]);
            bullet4.movement.direction = enemy.movement.direction;
            bullet4.movement.position += bullet4.movement.position;
            bullet4.movement.position.X = enemy.movement.position.X + 40;
            bullet4.movement.position.Y = enemy.movement.position.Y + 34;
            //bullet4.movement.position.Y = (enemy.movement.position.Y + 50) - MathHelper.ToRadians((float)(bullet4.movement.position.X * Math.Sin(45)));
            EntityLists.enemyBulletList.Add(bullet4);

            // Right -> up
            PlayerBullet bullet5 = new PlayerBullet(EntityTextures.textureList[1]);
            bullet5.movement.direction = enemy.movement.direction;
            bullet5.movement.position.X = enemy.movement.position.X + 40;
            bullet5.movement.position.Y = enemy.movement.position.Y - 34;
            EntityLists.enemyBulletList.Add(bullet5);

            // Left -> up
            PlayerBullet bullet6 = new PlayerBullet(EntityTextures.textureList[1]);
            bullet6.movement.direction = enemy.movement.direction;
            bullet6.movement.position.X = enemy.movement.position.X - 40;
            bullet6.movement.position.Y = enemy.movement.position.Y - 34;
            EntityLists.enemyBulletList.Add(bullet6);
        }
    }
}
