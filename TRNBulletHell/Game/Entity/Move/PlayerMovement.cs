using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerMovement : Movement
{
    public PlayerMovement()
    {
        // Starting position
        position = new Vector2(320, 320);
    
    }
	
        override
        public void Moving(GameTime gameTime)
        {
        KeyboardState state = Keyboard.GetState();

            int speed = 5;
            if (state.IsKeyDown(Keys.LeftShift) || state.IsKeyDown(Keys.RightShift))
            {
                speed = 1;
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
    public void moveLeft(int speed)
    {

        float newPosition = position.X + -speed;
        if (newPosition < 25)
        {
            newPosition = 25;
        }
        position.X = newPosition;

    }

    public void moveRight(int speed)
    {
        float newPosition = position.X + speed;
        if (newPosition > 775)
        {
            newPosition = 775;
        }
        position.X = newPosition;
    }

    public void moveUp(int speed)
    {
        float newPosition = position.Y + -speed;
        if (newPosition < 300)
        {
            newPosition = 300;
        }
        position.Y = newPosition;

    }

    public void moveDown(int speed)
    {
        float newPosition = position.Y + speed;
        if (newPosition > 450)
        {
            newPosition = 450;
        }
        position.Y = newPosition;
    }
}


