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
            this.distance = enemy.distance;
            // higher the number the easier the enemy.
            this.frequencyOfBullets = enemy.frequencyOfBullets;
            this.lifeDrop = false;
        }
        public override void Update(GameTime gameTime)
        {

            //Debug.WriteLine("To Rads: " + MathHelper.ToRadians(4f).ToString());
            movement._rotation += MathHelper.ToRadians(2f);

            Debug.WriteLine("Rotation: " + movement._rotation.ToString());

            ProduceBulletcounter++;

            this.movement.direction = new Vector2((float)Math.Cos(movement._rotation), (float)Math.Sin(movement._rotation));
            Debug.WriteLine("Direction in Enemy: " + movement.direction.ToString());
            this.movement.Moving(gameTime);

            if (this.movement.isComplete() && counter < movements.Count)
            {
                this.movement = movements[counter];
                counter++;
            }
        }
    }

}
