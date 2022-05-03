using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public abstract class Movement
{ 
        //speed and velocity?
    public Vector2 position;
    public Vector2 origin = new Vector2();
    public Vector2 direction;
    public float _rotation;
    public Vector2 speed = new Vector2(2f, 2f);
    public int screenWidth = 775;
    private Boolean complete = false;
    public float _rotationVelocity = 1f;

    public abstract void Moving(GameTime gametime);

    public void completedMovement()
    {
        this.complete = true;
    }
    public Boolean isComplete()
    {
        return complete;
    }

    public void outsideWidthBoundary()
    {
        if(this.position.X < -100 || this.position.X > 780)
        {
            this.completedMovement();
        }
    }

  

}
