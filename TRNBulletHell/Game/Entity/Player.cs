using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell.Game.Entity
{
    class Player : AbstractEntity
    {
        protected Texture2D rectangleTexture;
        public bool hasDied = false;
        public bool ShowHitbox = false;


        public Player(GraphicsDevice graphics,Texture2D image) : base(image)
        {
            // Initialize starting position at the bottom of the screen.


            // texture for drawing hitbox
            rectangleTexture = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            rectangleTexture.SetData<Color>(new Color[] { Color.White });
            //  this.movement = new PlayerMovement();
            this.movement = new ZigZagPath();
        }

        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)movement.position.X - 1, (int)movement.position.Y - 14, 5, 5);
            }
        }

        public void Update()
        {
            this.movement.Moving();

        }
       
    }
}