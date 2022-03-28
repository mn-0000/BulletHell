using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity.Enemy.Boss
{
    class FinalBoss : Boss
    {
        public float Speed;

        public int Step;
        public BulletA BulletClone;
        public float timer;

        public FinalBoss(Texture2D texture) : base(texture)
        {
            timer = 0f;
            Speed = 2f;
            health = 300;

            MovementCreator creator = new MovementCreator();
            this.movement = creator.CreateMovement("AcrossScreen");
            this.addMove(creator.CreateMovement("CirclePath"));
            this.addMove(creator.CreateMovement("ZigZagPath"));

            this.frequencyOfBullets = 15;
        }
    }
}
