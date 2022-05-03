using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
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
        BulletSpawn spawner;

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
            spawner = new BulletSpawn(GameDriver.textureList[0], a);
            a.bulletSpawn = spawner;
            
            if(type == "FinalBoss")
            {
                this.finalBoss();
                enemies.Add(a);
                spawner.movement = creator.CreateMovement("FinalBossBullet");
                spawner.addMove(creator.CreateMovement("FinalBossBullet"));
                EntityLists.bulletSpawner.Add(spawner);
            }
            else { 
            getRandomNumber();
                switch (randomMovement)
                {
                    case 0:
                        this.addMovementsOne();
                        enemies.Add(a);
                        EntityLists.bulletSpawner.Add(spawner);
                        return;
                    case 1:
                        this.addMovementsTwo();
                        enemies.Add(a);
                        EntityLists.bulletSpawner.Add(spawner);
                        return;
                    case 2:
                        this.addMovementsThree();
                        enemies.Add(a);
                        EntityLists.bulletSpawner.Add(spawner);
                        return;
                    case 3:
                        this.addMovementsFour();
                        enemies.Add(a);
                        EntityLists.bulletSpawner.Add(spawner);
                        return;
                    default:
                        throw new ArgumentException("Unexpected random number");
                }
            }
        }

        public void finalBoss()
        {
            a.movement = creator.CreateMovement("finalBoss");
            a.addMove(creator.CreateMovement("finalBoss"));
        }

        public void addMovementsOne()
        {
            a.movement = creator.CreateMovement("AcrossScreen");
            a.addMove(creator.CreateMovement("AcrossScreen"));
            a.addMove(creator.CreateMovement("ZigZagPath"));

            spawner.movement = creator.CreateMovement("AcrossScreen");
            spawner.addMove(creator.CreateMovement("AcrossScreen"));
            spawner.addMove(creator.CreateMovement("ZigZagPath"));

        }

        public void addMovementsTwo()
        {
            a.movement = creator.CreateMovement("ZigZagPath");
            a.addMove(creator.CreateMovement("CirclePath"));
            a.addMove(creator.CreateMovement("ZigZagPath"));

            spawner.movement = creator.CreateMovement("ZigZagPath");
            spawner.addMove(creator.CreateMovement("CirclePath"));
            spawner.addMove(creator.CreateMovement("ZigZagPath"));
        }

        public void addMovementsThree()
        {
            a.movement = creator.CreateMovement("ZigZagPath");
            a.addMove(creator.CreateMovement("CirclePath"));
            a.addMove(creator.CreateMovement("AcrossScreen"));

            spawner.movement = creator.CreateMovement("ZigZagPath");
            spawner.addMove(creator.CreateMovement("CirclePath"));
            spawner.addMove(creator.CreateMovement("AcrossScreen"));
        }


        public void addMovementsFour()
        {
            a.movement = creator.CreateMovement("CirclePath");
            a.addMove(creator.CreateMovement("CirclePath"));
            a.addMove(creator.CreateMovement("AcrossScreen"));

            spawner.movement = creator.CreateMovement("CirclePath");
            spawner.addMove(creator.CreateMovement("CirclePath"));
            spawner.addMove(creator.CreateMovement("AcrossScreen"));
        }
    }
}
