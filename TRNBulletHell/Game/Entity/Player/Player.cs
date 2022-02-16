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
        Vector2 playerPosition;
        
        public Player()
        {
            // Initialize starting position at the bottom of the screen.
            this.Xposition = 300;
            this.Yposition = 300;

            playerPosition = new Vector2(0, 0);
            playerPosition.X = this.Xposition;
            playerPosition.Y = this.Yposition;
        }


        public void moveLeft()
        {

            float newPosition = playerPosition.X + -5;
            if (newPosition < 0)
            {
                newPosition = 0;
            }
            playerPosition.X = newPosition;
   
        }

        public void moveRight()
        {
            float newPosition = playerPosition.X + 5;
            if (newPosition > 700)
            {
                newPosition = 695;
            }
            playerPosition.X = newPosition;
        }

        public void moveUp()
        {
            float newPosition = playerPosition.Y + -5;
            if (newPosition < 0)
            {
                newPosition = 2;
            }
            playerPosition.Y = newPosition;

        }

        public void moveDown()
        {
            float newPosition = playerPosition.Y + 5;
            if (newPosition > 320)
            {
                newPosition = 300;
            }
            playerPosition.Y = newPosition;
        }

        public Vector2 playersPosition()
        {
            return this.playerPosition;
        }
    }
}