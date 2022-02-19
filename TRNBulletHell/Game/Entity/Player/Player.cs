using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace TRNBulletHell.Game.Entity.Player
{
    class Player : AbstractEntity
    {
        
        
        public Player(Texture2D image)
        {
            this.texture = image;
            // Initialize starting position at the bottom of the screen.
            this.Xposition = 300;
            this.Yposition = 300;

            position = new Vector2(0, 0);
            position.X = this.Xposition;
            position.Y = this.Yposition;
        }


        private void moveLeft(int speed)
        {

            float newPosition = position.X + -speed;
            if (newPosition < 0)
            {
                newPosition = 0;
            }
            position.X = newPosition;
   
        }

        private void moveRight(int speed)
        {
            float newPosition = position.X + speed;
            if (newPosition > 750)
            {
                newPosition = 750;
            }
            position.X = newPosition;
        }

        private void moveUp(int speed)
        {
            float newPosition = position.Y + -speed;
            if (newPosition < 0)
            {
                newPosition = 0;
            }
            position.Y = newPosition;

        }

        private void moveDown(int speed)
        {
            float newPosition = position.Y + speed;
            if (newPosition > 400)
            {
                newPosition = 400;
            }
            position.Y = newPosition;
        }

        public void checkIfPlayersMoving(KeyboardState state )
        {
            int speed = 5;
            if(state.IsKeyDown(Keys.LeftShift) || state.IsKeyDown(Keys.RightShift))
            {
                speed = 2;
            }

            if (state.IsKeyDown(Keys.Left))
            {
                this.moveLeft(speed);
                //move player left
            }
            if (state.IsKeyDown(Keys.Right))
            {
                this.moveRight(speed);
                //move player right
            }
            if (state.IsKeyDown(Keys.Up))
            {
                this.moveUp(speed);
                //move player forward 
            }
            if (state.IsKeyDown(Keys.Down))
            {
                this.moveDown(speed);
                //move player backwards
            }

            /**
             * Alternatively if a character chooses to use the WASD keys
             * the codes below should work perfect.
             * 
             **/

            if (state.IsKeyDown(Keys.W))
            {
                this.moveUp(speed);
            }

            if (state.IsKeyDown(Keys.S))
            {
                this.moveDown(speed);
            }

            if (state.IsKeyDown(Keys.A))
            {
                this.moveLeft(speed);
            }

            if (state.IsKeyDown(Keys.D))
            {
                this.moveRight(speed);
            }
        }
       
    }
}