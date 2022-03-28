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
       // public BulletA BulletClone;

        public EnemyA(Texture2D texture) : base(texture)
        {
            health = 50;
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

    }
}

