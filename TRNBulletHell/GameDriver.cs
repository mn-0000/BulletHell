using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TRNBulletHell.Game;
using TRNBulletHell.Game.Bullet;
using TRNBulletHell.Game.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Enemy;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Enemy.Boss;
using System.Diagnostics;

namespace TRNBulletHell
{
    public class GameDriver : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D enemyATexture;
        Texture2D playerSprite;
        Texture2D backgroundSprite;
        Texture2D enemyB;
        Player player;
        EnemyA enemyA;
        MidBoss midBoss;
        FinalBoss finalBoss;
        SpriteFont font;
        private List<AbstractEntity> entities;
        protected int minutes;
        protected int seconds;


        public GameDriver()
        {
            _graphics = new GraphicsDeviceManager(this);           
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
            

            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(_graphics.GraphicsDevice, Content.Load<Texture2D>("player"));
            enemyA = new EnemyA(Content.Load<Texture2D>("enemyA"));
            midBoss = new MidBoss(Content.Load<Texture2D>("midboss"));
            finalBoss = new FinalBoss(Content.Load<Texture2D>("boss"));
            enemyB = Content.Load<Texture2D>("enemyB");
            playerSprite = player.getImage();
            font = Content.Load<SpriteFont>("galleryFont");
            backgroundSprite = Content.Load<Texture2D>("background");

            enemyATexture = Content.Load<Texture2D>("enemyA");

            entities = new List<AbstractEntity>
            {
                new EnemyA(enemyATexture)
                {
                    position = new Vector2(100, 100),
                    BulletClone = new BulletA(Content.Load<Texture2D>("bullet")),
                },
                new Player(_graphics.GraphicsDevice ,Content.Load<Texture2D>("player"))
                {

                }
            };

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            minutes = gameTime.TotalGameTime.Minutes;
            seconds = gameTime.TotalGameTime.Seconds;

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var entity in entities.ToArray())
            {
                entity.Update(gameTime, entities);
            }
            EntityUpdate();


            base.Update(gameTime);
        }

        private void EntityUpdate()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].isRemoved)
                {
                    entities.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            if (seconds < 10)
            {
                _spriteBatch.DrawString(font, $"{minutes + " : 0" + seconds}", new Vector2(700, 0), Color.White);
            }
            else
            {
                _spriteBatch.DrawString(font, $"{minutes + " : " + seconds}", new Vector2(700, 10), Color.White);
            }


            _spriteBatch.Draw(midBoss.getImage(), new Vector2(50, 120), Color.White);
            _spriteBatch.Draw(finalBoss.getImage(), new Vector2(50, 300), Color.White);
            _spriteBatch.Draw(enemyB, new Vector2(150, 150), Color.White);
           
            foreach (var entity in entities)
            {
                entity.Draw(_spriteBatch, entities);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
