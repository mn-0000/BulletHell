using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Move
{
    class MovementCreator
    {
        public Movement createMovement(String type)
        {
            if(type == "AcrossScreen")
            {
                return new AcrossScreen();
            }
            if(type == "CirclePath")
            {
                return new CirclePath();
            }
            if (type == "ZigZagPath")
            {
                return new ZigZagPath();
            }
            if(type == "Player")
            {
                return new PlayerMovement();
            }
            return null;
        }
    }
}
