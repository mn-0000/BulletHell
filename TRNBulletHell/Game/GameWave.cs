using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Enemy;

namespace TRNBulletHell.Game
{

    class GameWave
    {
        EnemyFactory enemyFactory = new EnemyFactory();
        private int total;
        private int startTime;
        string type;
        private int intervalTime;
        private int bulletFrequency = 0;

        private int count;
        Texture2D texture;

        public GameWave(int time, int total, string type, Texture2D texture)
        {
            this.startTime = time;
            this.total = total;
            this.texture = texture;
            this.type = type;
            this.count = 0;
        }

        public int GetBulletFrequency()
        {
            return bulletFrequency;
        }

        public void SetBulletFrequency(int frequency)
        {
            bulletFrequency = frequency;
        }

        public int GetStartTime()
        {
            return startTime;
        }

        public int GetIntervalTime()
        {
            return intervalTime;
        }

        public void SetIntervalTime(int interval)
        {
            intervalTime = interval;
        }

        public bool createWave(double seconds, float _remainingDelay, Texture2D enemyBullet)
        {
            if (seconds >= startTime && _remainingDelay <= 0 && this.count < total)
            {
                this.count++;
                EnemyBuilder builder = new EnemyBuilder(this.texture, enemyBullet, type);
                builder.createEnemy(EntityLists.enemyList);
                return true;
            }
            return false;
        }

        public bool createWave(double seconds, float _remainingDelay, Texture2D enemyBullet, int bulletFrequency)
        {
            if (seconds >= startTime && _remainingDelay <= 0 && this.count < total)
            {
                this.count++;
                EnemyBuilder builder = new EnemyBuilder(this.texture, enemyBullet, type);
                builder.createEnemy(EntityLists.enemyList, bulletFrequency);
                return true;
            }
            return false;
        }

        public bool IsDoneCreatingEnemies()
        {
            if (count == total)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


