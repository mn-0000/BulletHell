using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public abstract class Movement
{ 
        //speed and velocity?
    public Vector2 position;
    public Vector2 origin;
    public Vector2 speed = new Vector2(2f, 2f);
    public int screenWidth = 775;


    public abstract void Moving();
    
}
