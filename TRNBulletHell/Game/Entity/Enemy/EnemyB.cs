﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy
{
    class EnemyB : Enemy 
    {


        public EnemyB(Texture2D texture) : base(texture)
        {
            MovementCreator creator = new MovementCreator();


            this.movement = creator.CreateMovement("ZigZagPath");
            this.addMove(creator.CreateMovement("CirclePath"));
            this.addMove(creator.CreateMovement("ZigZagPath"));
        }

      
    }
}
