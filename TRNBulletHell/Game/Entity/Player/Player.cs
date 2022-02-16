using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace TRNBulletHell.Game.Entity.Player
{
    class Player : Entity
    {
        
        
        public Player()
        {
            // Initialize starting position at the bottom of the screen.
            this.Xposition = 300;
            this.Yposition = 300;

            position = new Vector2(0, 0);
            position.X = this.Xposition;
            position.Y = this.Yposition;
        }


        public void moveLeft()
        {

            float newPosition = position.X + -5;
            if (newPosition < 0)
            {
                newPosition = 0;
            }
            position.X = newPosition;
   
        }

        public void moveRight()
        {
            float newPosition = position.X + 5;
            if (newPosition > 750)
            {
                newPosition = 750;
            }
            position.X = newPosition;
        }

        public void moveUp()
        {
            float newPosition = position.Y + -5;
            if (newPosition < 0)
            {
                newPosition = 0;
            }
            position.Y = newPosition;

        }

        public void moveDown()
        {
            float newPosition = position.Y + 5;
            if (newPosition > 400)
            {
                newPosition = 400;
            }
            position.Y = newPosition;
        }

       
    }
}