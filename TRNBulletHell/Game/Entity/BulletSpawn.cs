using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TRNBulletHell.Game.Entity.Enemy;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity
{
   public class BulletSpawn : Enemy.Enemy
    {
        public Enemy.Enemy FollowingEnemy;

        public BulletSpawn(Texture2D texture, Enemy.Enemy enemy) : base(texture)
        {
            this.FollowingEnemy = enemy;
            //this.movement = new BulletMovement();         // These don't seem to affect the movement.
            //this.movement = new BulletSpawnMovement();    // These don't seem to affect the movement.
            this.distance = enemy.distance;
            // higher the number the easier the enemy.
            this.frequencyOfBullets = enemy.frequencyOfBullets;
            this.lifeDrop = false;
        }
    }
}
