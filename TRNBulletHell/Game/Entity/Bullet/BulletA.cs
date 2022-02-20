using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;

namespace TRNBulletHell.Game.Bullet.BulletA
{
    public class BulletA : Bullet
    {
        public BulletA(Texture2D texture) : base(texture)
        {
            
        }

        public override void Update(GameTime gameTime, List<AbstractEntity> entities)
        {
            if (this.position.Y > 450)
            {
                isRemoved = true;
            }

            position += direction * speed;
        }
    }

}
