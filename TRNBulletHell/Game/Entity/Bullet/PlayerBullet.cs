﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Bullet
{
    public class PlayerBullet : Bullet
    {
        private double timer;
       // private double life;

        public PlayerBullet(Texture2D texture) : base(texture)
        {
            movement = new BulletMovement();
            movement.speed = new Vector2 (2f, 2f);
            life = 10;
            damage = 10;
        }

        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= life)
            {
                isRemoved = true;
            }

            movement.Moving(gameTime);
        }

    }
}
