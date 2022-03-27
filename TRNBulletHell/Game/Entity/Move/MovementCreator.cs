using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    public class MovementCreator : EntityFactory
    {
        public override Bullet.Bullet CreateBullet(string type, Texture2D texture)
        {
            throw new NotImplementedException();
        }

        public override Enemy.Enemy CreateEnemy(string type, Texture2D texture)
        {
            throw new NotImplementedException();
        }

        public override Movement CreateMovement(string type)
        {
            if (type == "AcrossScreen")
            {
                return new AcrossScreen();
            }
            if (type == "CirclePath")
            {
                return new CirclePath();
            }
            if (type == "ZigZagPath")
            {
                return new ZigZagPath();
            }
            if (type == "Player")
            {
                return new PlayerMovement();
            }
            return null;
        }
    }
}
