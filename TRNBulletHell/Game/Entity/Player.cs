using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using TRNBulletHell.Game.Entity.Move;
using TRNBulletHell.Game.Entity.Bullet;
using System.Linq;

namespace TRNBulletHell.Game.Entity
{
    public class Player : AbstractEntity
    {
        public PlayerBullet playerBullet;
        protected Texture2D rectangleTexture;
        public bool hasDied = false;
        public bool ShowHitbox = false;
        private KeyboardState _currentKey;
        private KeyboardState _prevousKey;
        private int health;
        private int lives;

        public Player(GraphicsDevice graphics,Texture2D image) : base(image)
        {
            // Initialize starting position at the bottom of the screen.
            // texture for drawing hitbox
            rectangleTexture = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            rectangleTexture.SetData<Color>(new Color[] { Color.White });
            this.movement = new PlayerMovement();
            this.health = 100;
            this.lives = 1;
        }

        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)movement.position.X - 1, (int)movement.position.Y - 14, 50, 50);
            }
        }


        public override void Update(GameTime gameTime)
        {
            this.movement.Moving(gameTime);
            _prevousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if (_currentKey.IsKeyDown(Keys.Space) && _prevousKey.IsKeyUp(Keys.Space))
            {
                PlayerBullet bullet = new PlayerBullet(playerBullet.getImage());
            
                

                 bullet.movement.direction = new Vector2(0, 1);
                 bullet.movement.position = new Vector2();




                 bullet.movement.position.X = this.movement.position.X;
                  bullet.movement.position.Y = this.movement.position.Y;
                 EntityLists.playerBulletList.Add(bullet);
            }

            checkIsRemoved();
        }

        public void checkIsRemoved()
        {
            if (health <= 0 && lives == 0)  // health hit 0 and no lives left.
            {
                isRemoved = true;
            }
            else if (health <= 0 && lives >= 1)  // health hit 0 and still has lives.
            {
                health = 100;
                removeLife();
            }
        }

        public void TakeDamage(int damage)
        {
            if(!GameOptions.IsGodModeEnabled())
            {
                health -= damage;
            }
        }

        public int GetHealth()
        {
            return health;
        }

        public int getLives()
        {
            return this.lives;
        }

        public void setLives(int life)
        {
            this.lives = life;
        }

        public void addLife()
        {
            this.lives += 1;
        }

        public void removeLife()
        {
            this.lives -= 1;
        }

    }
}