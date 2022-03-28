﻿using Microsoft.Xna.Framework;
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
            health = 30;
            // choose the movements when you are creating the waves or we could choose the movements in the JSON and parse that way. 
            // Use builder pattern to create enemies.
            // Must instatiate this.movement in order to .Draw().

            MovementCreator creator = new MovementCreator();


            this.movement = creator.CreateMovement("AcrossScreen");
            this.addMove(creator.CreateMovement("AcrossScreen"));
          //  this.addMove(creator.CreateMovement("ZigZagPath"));

            // higher the number the easier the enemy.
            this.frequencyOfBullets = 30;
        }

        public override void Update(GameTime gameTime, IEnumerable<AbstractEntity> entities)
        {
            this.movement.Moving();

            /*  var bullet = BulletClone.Clone() as BulletA;
              bullet.movement.direction = new Vector2(0, 1);
              bullet.movement.position = this.movement.position;
              entities.Add(bullet);
          }*/


            /*  var bullet = BulletClone.Clone() as BulletA;
              bullet.movement.direction = new Vector2(0, 1);
              bullet.movement.position = this.movement.position;
              entities.Add(bullet);*/

            if (health <= 0)
            {
                isRemoved = true;
            }
        }
    }
}

