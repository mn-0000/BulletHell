using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy
{
    public class EnemyB : Enemy 
    {
        public EnemyB(Texture2D texture) : base(texture)
        {
            health = 20;
            MovementCreator creator = new MovementCreator();
            this.movement = creator.CreateMovement("ZigZagPath");
            this.addMove(creator.CreateMovement("CirclePath"));
            this.addMove(creator.CreateMovement("ZigZagPath"));
            this.movement.speed = new Vector2(1f, 1f);
            this.frequencyOfBullets = 30;
        }
      
    }
}
