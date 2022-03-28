using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy
{
    class EnemyA : Enemy
    {
        public BulletA BulletClone;

        public EnemyA(Texture2D texture) : base(texture)
        {
            // choose the movements when you are creating the waves or we could choose the movements in the JSON and parse that way. 
            // Use builder pattern to create enemies.
            // Must instatiate this.movement in order to .Draw().

            MovementCreator creator = new MovementCreator();


            this.movement = creator.CreateMovement("CirclePath");
            this.addMove(creator.CreateMovement("AcrossScreen"));
            this.addMove(creator.CreateMovement("ZigZagPath"));
        }

        /*  public override void Update(GameTime gameTime, List<AbstractEntity> entities)
          {
              this.movement.Moving();

            /*  var bullet = BulletClone.Clone() as BulletA;
              bullet.movement.direction = new Vector2(0, 1);
              bullet.movement.position = this.movement.position;
              entities.Add(bullet);
          }*/


    }
}

