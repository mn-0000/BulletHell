using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy
{
    class EnemyBuilder
    {
        EnemyFactory enemyFactory = new EnemyFactory();
        Texture2D texture;
        string type;
        MovementCreator creator = new MovementCreator();
        Texture2D enemyBullet;
        Enemy a;
        Random random = new Random();
        int randomMovement = 0;


        public EnemyBuilder(Texture2D texture, Texture2D bullet, string type)
        {
            this.texture = texture;
            this.type = type;
            this.enemyBullet = bullet;          



        }

        public void getRandomNumber()
        {
           randomMovement = random.Next(0, 4);
        }

        public void createEnemy(List<Enemy> enemies)
        {
            this.a = enemyFactory.CreateEnemy(type, texture);
            a.enemyBullet = new BulletA(enemyBullet);
            getRandomNumber();
            switch (randomMovement)
            {
                case 0:
                    this.addMovementsOne();
                    enemies.Add(a);
                    return;
                case 1:
                    this.addMovementsTwo();
                    enemies.Add(a);
                    return;
                case 2:
                    this.addMovementsThree();
                    enemies.Add(a);
                    return;
                case 3:
                    this.addMovementsFour();
                    enemies.Add(a);
                    return;
                default:
                    throw new ArgumentException("Unexpected random number");
            }

            
        }

        public void addMovementsOne()
        {
            a.movement = creator.CreateMovement("AcrossScreen");
            a.addMove(creator.CreateMovement("AcrossScreen"));
            a.addMove(creator.CreateMovement("ZigZagPath"));
        }

        public void addMovementsTwo()
        {
            a.movement = creator.CreateMovement("ZigZagPath");
            a.addMove(creator.CreateMovement("CirclePath"));
            a.addMove(creator.CreateMovement("ZigZagPath"));
        }

        public void addMovementsThree()
        {
            a.movement = creator.CreateMovement("ZigZagPath");
            a.addMove(creator.CreateMovement("CirclePath"));
            a.addMove(creator.CreateMovement("AcrossScreen"));
        }


        public void addMovementsFour()
        {
            a.movement = creator.CreateMovement("CirclePath");
            a.addMove(creator.CreateMovement("CirclePath"));
            a.addMove(creator.CreateMovement("AcrossScreen"));
        }
    }
}
