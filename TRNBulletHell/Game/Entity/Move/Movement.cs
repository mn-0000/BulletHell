using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public abstract class Movement
{ 
        //speed and velocity?
    public Vector2 position;
    public Vector2 origin;
    public Vector2 direction;
    public Vector2 speed = new Vector2(2f, 2f);
    public int screenWidth = 775;
    private Boolean complete = false;
    

    public abstract void Moving();

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
