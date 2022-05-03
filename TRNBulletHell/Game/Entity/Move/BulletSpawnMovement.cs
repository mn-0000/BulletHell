using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    public class BulletSpawnMovement : Movement
    {
        //public float _rotationVelocity = 4f;

        public BulletSpawnMovement()
        {

        }

        public override void Moving(GameTime gametime)
        {
            //this._rotation -= MathHelper.ToRadians(_rotationVelocity);
            //this.direction = new Vector2((float)Math.Cos(_rotation), (float)Math.Sin(_rotation));
            //this.position -= this.direction * speed;
            //Debug.WriteLine("Bullet Spawn rotation: " + this._rotation.ToString());
            //Debug.WriteLine("Bullet Spawn direction: " + this.direction.ToString());
        }
    }
}
