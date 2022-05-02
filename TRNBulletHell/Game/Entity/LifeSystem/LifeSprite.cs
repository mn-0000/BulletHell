using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.LifeSystem
{
    /// <summary>
    /// Class is for the life sprite that drops from the enemies.
    /// The player can pi
    /// </summary>
    public class LifeSprite : AbstractEntity
    {
        public LifeSprite(Texture2D texture) : base(texture)
        {
            movement = new LifeDropMovement();
            movement.speed = new Vector2(1.5f, 1.5f);
        }

        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)movement.position.X - 1, (int)movement.position.Y - 1, 5, 5);
            }
        }

        public override void Update(GameTime gameTime)
        {
            movement.Moving(gameTime);
        }
    }

}
