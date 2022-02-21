﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TRNBulletHell.Game.Bullet;
using TRNBulletHell.Game.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Enemy;
using TRNBulletHell.Game.Entity;
namespace TRNBulletHell
{
    public class GameDriver : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D enemyATexture;
        Texture2D playerSprite;
        Texture2D backgroundSprite;
        //Texture2D bulletTexture;
        Texture2D enemyB;
        Player player;
        EnemyA enemyA;
        SpriteFont font;
        //BulletA bulletA;
        private List<AbstractEntity> entities;

        public GameDriver()
        {
            _graphics = new GraphicsDeviceManager(this);           
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _graphics.IsFullScreen = false;

        }

        protected override void Initialize()
        {
            player = new Player(Content.Load<Texture2D>("player"));
            enemyA = new EnemyA(Content.Load<Texture2D>("enemyA"));
            // TODO: Add your initialization logic here
            

            base.Initialize();
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //enemyASprite = Content.Load<Texture2D>("enemyA");
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
                }
            };

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            player.checkIfPlayersMoving(state);

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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
            //_spriteBatch.Draw(enemyATexture, enemyA.position, Color.White);
            _spriteBatch.Draw(enemyB, new Vector2(150, 150), Color.White);
            //_spriteBatch.Draw(enemyA.Bullet.Texture, enemyA.Bullet.Position, Color.White);
            //_spriteBatch.Draw(enemyASprite, new Vector2(300, 0), Color.White);
            _spriteBatch.Draw(playerSprite, player.getPosition(), Color.White);
            _spriteBatch.DrawString(font, player.position.ToString(), new Vector2(150, 0), Color.White);

            foreach (var entity in entities)
            {
                entity.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
