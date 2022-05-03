using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Enemy;
namespace TRNBulletHell.Game.Entity.BulletPattern
{
    class BulletPatterns
    {
        public void regular(BulletSpawn enemy)
        {
            
            PlayerBullet bullet = new PlayerBullet(GameDriver.textureList[1]);
            bullet.movement.direction = new Vector2(0, -1);
            bullet.movement.position = new Vector2();
            bullet.movement.position.X = enemy.movement.position.X;
            bullet.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bullet);
        }

        public void sprayBullets(BulletSpawn enemy)
        {
            PlayerBullet bullet = new PlayerBullet(GameDriver.textureList[1]);
            bullet.movement.direction = new Vector2(0, -1);
            bullet.movement.position = new Vector2();
            bullet.movement.position.X = enemy.movement.position.X;
            bullet.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bullet);

            PlayerBullet bulletTwo = new PlayerBullet(GameDriver.textureList[1]);
            bulletTwo.movement.direction = new Vector2(0.2f, -1);
            bulletTwo.movement.position = new Vector2();
            bulletTwo.movement.position.X = enemy.movement.position.X;
            bulletTwo.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bulletTwo);

            PlayerBullet bulletFive = new PlayerBullet(GameDriver.textureList[1]);
            bulletFive.movement.direction = new Vector2(0.4f, -1);
            bulletFive.movement.position = new Vector2();
            bulletFive.movement.position.X = enemy.movement.position.X;
            bulletFive.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bulletFive);


            PlayerBullet bulletThree = new PlayerBullet(GameDriver.textureList[1]);
            bulletThree.movement.direction = new Vector2(0.6f, -1);
            bulletThree.movement.position = new Vector2();
            bulletThree.movement.position.X = enemy.movement.position.X;
            bulletThree.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bulletThree);

            PlayerBullet bulletFour = new PlayerBullet(GameDriver.textureList[1]);
            bulletFour.movement.direction = new Vector2(0.8f, -1);
            bulletFour.movement.position = new Vector2();
            bulletFour.movement.position.X = enemy.movement.position.X;
            bulletFour.movement.position.Y = enemy.movement.position.Y;
            EntityLists.enemyBulletList.Add(bulletFour);
        }

        public void toawrdsUser(BulletSpawn enemy)
        {
            PlayerBullet bulletFour = new PlayerBullet(GameDriver.textureList[1]);
            
            bulletFour.movement.position.X = enemy.movement.position.X;
            bulletFour.movement.position.Y = enemy.movement.position.Y;
            Vector2 check = EntityLists.playerList[0].movement.position - bulletFour.movement.position;
            bulletFour.movement.direction = check;


            EntityLists.enemyBulletList.Add(bulletFour);

        }
        
    }
}
