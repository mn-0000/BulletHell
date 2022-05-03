﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy
{
    class EnemyA : Enemy
    {
       // public BulletA BulletClone;

        public EnemyA(Texture2D texture) : base(texture)
        {
            health = 50;

            // higher the number the easier the enemy.
            this.frequencyOfBullets = 30;
            this.type = "enemyA";
            this.distance = 0;
            //this.lifeDrop = true;
        }

        public EnemyA(Texture2D texture, int bulletFrequency) : base(texture)
        {
            health = 50;

            // higher the number the easier the enemy.
            this.frequencyOfBullets = bulletFrequency;
            this.type = "enemyA";
            this.distance = 0;
            this.lifeDrop = true;
        }
    }
}

