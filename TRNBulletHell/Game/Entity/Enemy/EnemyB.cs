using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy
{
    public class EnemyB : Enemy 
    {
        public EnemyB(Texture2D texture) : base(texture)
        {
            health = 20;
            this.frequencyOfBullets = 30;
            this.type = "enemyB";

            //Bullet spawner distance
            this.distance = 0;
        }

        public EnemyB(Texture2D texture, int bulletFrequency) : base(texture)
        {
            health = 20;

            // higher the number the easier the enemy.
            this.frequencyOfBullets = bulletFrequency;
            this.type = "enemyB";
            this.distance = 0;
            //this.lifeDrop = true;
        }
    }
}
