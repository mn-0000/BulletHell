<<<<<<< HEAD:TRNBulletHell/Game/Bullet/BulletB/BulletB.cs
﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
=======
﻿using Microsoft.Xna.Framework.Graphics;
>>>>>>> 2-FactoryClasses:TRNBulletHell/Game/Entity/Bullet/BulletB.cs
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Bullet.BulletB
{
    public class BulletB : Bullet
    {
        public BulletB(Texture2D texture) : base(texture)
        {

        }
<<<<<<< HEAD:TRNBulletHell/Game/Bullet/BulletB/BulletB.cs

        public override void Update(GameTime gameTime)
        {
            Position += Direction * LinearVelocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
=======
>>>>>>> 2-FactoryClasses:TRNBulletHell/Game/Entity/Bullet/BulletB.cs
    }
}
