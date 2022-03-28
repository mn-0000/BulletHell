﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Enemy;

namespace TRNBulletHell.Game
{

    class Wave
    {
        EnemyFactory enemyFactory = new EnemyFactory();
        private int total;
        private int intervalTime;
        string type;

        private int count;
        Texture2D texture;

        public Wave(int time, int total, string type, Texture2D texture)
        {
            this.intervalTime = time;
            this.total = total;
            this.texture = texture;
            this.type = type;
            this.count = 0;
        }

        public bool createWave(double seconds, float _remainingDelay, List<AbstractEntity> enemies, Texture2D enemyBullet)
        {
            
            
            if (seconds >= intervalTime && _remainingDelay <= 0 && this.count < total)
            {
               this.count++;
                Enemy a = enemyFactory.CreateEnemy(type, texture);
                //a.enemyBullet = new PlayerBullet(enemyBullet);
                a.enemyBullet = new BulletA(enemyBullet);
                enemies.Add(a);
                return true;

            }
           
            return false;
        }
    }
}


