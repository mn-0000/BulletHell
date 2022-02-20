using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace TRNBulletHell.Game.Entity
{
    class Player : AbstractEntity
    {
        public bool hasDied = false;
        
        public Player(Texture2D image) : base(image)
        {
            // Initialize starting position at the bottom of the screen.
            this.Xposition = 300;
            this.Yposition = 300;

            position = new Vector2(0, 0);
            position.X = this.Xposition;
            position.Y = this.Yposition;
        }

        public override void Update(GameTime gameTime, List<AbstractEntity> entities)
        {
            checkIfPlayersMoving(Keyboard.GetState());

            // runs through the list of entities and kills the player if touching bullet/enemy
            foreach(var entity in entities)
            {
                if (entity == this) continue;
                if(entity.Rectangle.Intersects(this.Rectangle))
                {
                    this.hasDied = true;
                }
            }
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
        }
       
    }
}