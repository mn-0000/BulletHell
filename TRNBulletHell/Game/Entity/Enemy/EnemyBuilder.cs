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
        Enemy newEnemy;
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

        public void createEnemy()
        {
            this.newEnemy = enemyFactory.CreateEnemy(type, texture);
            newEnemy.enemyBullet = new BulletA(enemyBullet);
            spawner = new BulletSpawn(EntityTextures.textureList[0], newEnemy);
            newEnemy.bulletSpawn = spawner;
            
            if(type == "FinalBoss")
            {
                this.finalBoss();
                EntityLists.enemyList.Add(newEnemy);
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
                        EntityLists.enemyList.Add(newEnemy);
                        EntityLists.bulletSpawner.Add(spawner);
                        return;
                    case 1:
                        this.addMovementsTwo();
                        EntityLists.enemyList.Add(newEnemy);
                        EntityLists.bulletSpawner.Add(spawner);
                        return;
                    case 2:
                        this.addMovementsThree();
                        EntityLists.enemyList.Add(newEnemy);
                        EntityLists.bulletSpawner.Add(spawner);
                        return;
                    case 3:
                        this.addMovementsFour();
                        EntityLists.enemyList.Add(newEnemy);
                        EntityLists.bulletSpawner.Add(spawner);
                        return;
                    default:
                        throw new ArgumentException("Unexpected random number");
                }
            }
        }

        public void finalBoss()
        {
            newEnemy.movement = creator.CreateMovement("finalBoss");
            newEnemy.addMove(creator.CreateMovement("finalBoss"));
        }

        public void addMovementsOne()
        {
            newEnemy.movement = creator.CreateMovement("AcrossScreen");
            newEnemy.addMove(creator.CreateMovement("AcrossScreen"));
            newEnemy.addMove(creator.CreateMovement("ZigZagPath"));

            spawner.movement = creator.CreateMovement("AcrossScreen");
            spawner.addMove(creator.CreateMovement("AcrossScreen"));
            spawner.addMove(creator.CreateMovement("ZigZagPath"));

        }

        public void addMovementsTwo()
        {
            newEnemy.movement = creator.CreateMovement("ZigZagPath");
            newEnemy.addMove(creator.CreateMovement("CirclePath"));
            newEnemy.addMove(creator.CreateMovement("ZigZagPath"));

            spawner.movement = creator.CreateMovement("ZigZagPath");
            spawner.addMove(creator.CreateMovement("CirclePath"));
            spawner.addMove(creator.CreateMovement("ZigZagPath"));
        }

        public void addMovementsThree()
        {
            newEnemy.movement = creator.CreateMovement("ZigZagPath");
            newEnemy.addMove(creator.CreateMovement("CirclePath"));
            newEnemy.addMove(creator.CreateMovement("AcrossScreen"));

            spawner.movement = creator.CreateMovement("ZigZagPath");
            spawner.addMove(creator.CreateMovement("CirclePath"));
            spawner.addMove(creator.CreateMovement("AcrossScreen"));
        }


        public void addMovementsFour()
        {
            newEnemy.movement = creator.CreateMovement("CirclePath");
            newEnemy.addMove(creator.CreateMovement("CirclePath"));
            newEnemy.addMove(creator.CreateMovement("AcrossScreen"));

            spawner.movement = creator.CreateMovement("CirclePath");
            spawner.addMove(creator.CreateMovement("CirclePath"));
            spawner.addMove(creator.CreateMovement("AcrossScreen"));
        }
    }
}
