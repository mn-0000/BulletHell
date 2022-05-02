﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    public class BulletMovement : Movement
    {
        public BulletMovement()
        {
            
        }
    
        public override void Moving(GameTime gameTime)
        {
            this.position -= this.direction * speed;
        }

      
    }
}
