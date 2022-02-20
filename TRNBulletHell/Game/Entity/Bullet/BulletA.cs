<<<<<<< HEAD:TRNBulletHell/Game/Bullet/BulletA/BulletA.cs
﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
=======
﻿using Microsoft.Xna.Framework.Graphics;
>>>>>>> 2-FactoryClasses:TRNBulletHell/Game/Entity/Bullet/BulletA.cs
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity;

namespace TRNBulletHell.Game.Bullet.BulletA
{
    public class BulletA : Bullet
    {
<<<<<<< HEAD:TRNBulletHell/Game/Bullet/BulletA/BulletA.cs

=======
>>>>>>> 2-FactoryClasses:TRNBulletHell/Game/Entity/Bullet/BulletA.cs
        public BulletA(Texture2D texture) : base(texture)
        {

        }
<<<<<<< HEAD:TRNBulletHell/Game/Bullet/BulletA/BulletA.cs

        public override void Update(GameTime gameTime)
        {
           Position += Direction * LinearVelocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
=======
>>>>>>> 2-FactoryClasses:TRNBulletHell/Game/Entity/Bullet/BulletA.cs
    }

}
