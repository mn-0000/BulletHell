using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TRNBulletHell.Game;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Bullet.BulletA;
using TRNBulletHell.Game.Entity.Enemy;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Enemy.Boss;
using System.Diagnostics;
using TRNBulletHell.Game.Entity.Move;

namespace TRNBulletHell
{
    public class GameDriver : Microsoft.Xna.Framework.Game
    {
        // graphics/textures
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D enemyATexture;
        Texture2D enemyBTexture;
        Texture2D midBossTexture;
        Texture2D finalBossTexture;
        Texture2D enemyBullet;
        Texture2D backgroundSprite;
        Texture2D playerBullet2D;
        SpriteFont font;

        // variables
        protected int minutes;
        protected int seconds;
        private const float _delay = 2; // seconds
        private float _remainingDelay = _delay;
        private int finalBossCount = 0;
        private bool win = false;

        // waves
        Wave first;
        Wave second;
        Wave third;
        Wave fourth;

        CollisionDetection collisionDetection = new CollisionDetection();
        EntityLists entities = EntityLists.Instance;

        enum GameState
        {
            MainMenu,
            Playing,
            Options,
            Quit,
        }

        GameState CurrentGameState = GameState.MainMenu;
        cButton btnPlay, btnOptions, btnQuit, btnMenu;

        public GameDriver()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            // graphics/textures
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("galleryFont");
            backgroundSprite = Content.Load<Texture2D>("background");
            enemyATexture = Content.Load<Texture2D>("enemyA");
            enemyBTexture = Content.Load<Texture2D>("enemyB");
            midBossTexture = Content.Load<Texture2D>("midBoss");
            finalBossTexture = Content.Load<Texture2D>("boss");
            playerBullet2D = Content.Load<Texture2D>("bullet");
            enemyBullet = Content.Load<Texture2D>("EnemyBullet");

            // Buttons
            btnPlay = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Play", 30);
            btnPlay.setPosition(new Vector2(325, 100));

            btnOptions = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Options", 55);
            btnOptions.setPosition(new Vector2(325, 200));

            btnQuit = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Quit", 30);
            btnQuit.setPosition(new Vector2(325, 300));

            btnMenu = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Back", 35);
            btnMenu.setPosition(new Vector2(325, 400));


            // Next Deliverable a class that reads the JSON file will define the waves and the quantity of the waves for a longer Game Play.
            first = new Wave(0, 3, "EnemyA", enemyATexture);
            second = new Wave(30, 1, "MidBoss", midBossTexture);
            third = new Wave(60, 5, "EnemyB", enemyBTexture);
            fourth = new Wave(90, 1, "FinalBoss", finalBossTexture);
            EntityLists.playerList.Add(new Player(_graphics.GraphicsDevice, Content.Load<Texture2D>("player"))
            {
                playerBullet = new PlayerBullet(playerBullet2D)
            });
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    this.IsMouseVisible = true;
                    if (btnPlay.isClicked) CurrentGameState = GameState.Playing;
                    if (btnOptions.isClicked) CurrentGameState = GameState.Options;
                    if (btnQuit.isClicked) CurrentGameState = GameState.Quit;
                    btnPlay.Update(mouse);
                    btnOptions.Update(mouse);
                    btnQuit.Update(mouse);
                    break;

                case GameState.Options:
                    this.IsMouseVisible = true;
                    if (btnMenu.isClicked) CurrentGameState = GameState.MainMenu;
                    btnMenu.Update(mouse);
                    break;

                case GameState.Quit:
                    Exit();
                    break;

                case GameState.Playing:
                    this.IsMouseVisible = false;
                    //for clock display
                    minutes = gameTime.TotalGameTime.Minutes;
                    seconds = gameTime.TotalGameTime.Seconds;

                    //Set delay for spawning.
                    var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    _remainingDelay -= timer;

                    // Create waves
                    double waveTimer = gameTime.TotalGameTime.TotalSeconds;
                    if (first.createWave(waveTimer, _remainingDelay, enemyBullet) ||
                        second.createWave(waveTimer, _remainingDelay, enemyBullet) ||
                        third.createWave(waveTimer, _remainingDelay, enemyBullet) ||
                        fourth.createWave(waveTimer, _remainingDelay, enemyBullet))
                    {
                        _remainingDelay = _delay;
                    }

                    // mark final boss entry
                    if (gameTime.TotalGameTime.TotalSeconds >= 120 && _remainingDelay <= 0 && finalBossCount < 1)
                    {
                        finalBossCount++;
                    }

                    // check if boss is dead or game is over
                    if (finalBossCount >= 1 && (gameTime.TotalGameTime.TotalSeconds >= 150 || EntityLists.enemyList.ToArray().Length == 0))
                    {
                        win = true;
                    }

                    // exit if esc pressed
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        Exit();
                    }

                    // update all entities
                    EntityLists.Update(gameTime);

                    // detect collisions
                    collisionDetection.detectCollision(gameTime);
                    break;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    _spriteBatch.DrawString(font, "Bullet Hell Game", new Vector2(300, this.Window.ClientBounds.Height / 100), Color.White);
                    btnPlay.Draw(_spriteBatch);
                    btnOptions.Draw(_spriteBatch);
                    btnQuit.Draw(_spriteBatch);
                    break;

                case GameState.Options:
                    _spriteBatch.DrawString(font, "Options", new Vector2(350, this.Window.ClientBounds.Height / 100), Color.White);
                    btnMenu.Draw(_spriteBatch);
                    break;

                case GameState.Playing:
                    EntityLists.Draw(_spriteBatch);

                    if (seconds < 10)
                    {
                        _spriteBatch.DrawString(font, $"{minutes + " : 0" + seconds}", new Vector2(700, 0), Color.White);
                    }
                    else
                    {
                        _spriteBatch.DrawString(font, $"{minutes + " : " + seconds}", new Vector2(700, 10), Color.White);
                    }

                    // display health if player(s) is alive
                    if (EntityLists.playerList.Count != 0)
                    {
                        _spriteBatch.DrawString(font, $"Health: { EntityLists.playerList[0].GetHealth().ToString()}", new Vector2(20, 10), Color.White);
                    }
                    else
                    {
                        _spriteBatch.DrawString(font, "Game Over", new Vector2(300, this.Window.ClientBounds.Height / 2), Color.White);
                        _spriteBatch.DrawString(font, "Press ESC to exit", new Vector2(300, this.Window.ClientBounds.Height / 2 + 100), Color.White);
                        EntityLists.enemyList.Clear();
                        EntityLists.playerBulletList.Clear();
                        EntityLists.enemyBulletList.Clear();
                    }

                    if (win)
                    {
                        _spriteBatch.DrawString(font, "Winner", new Vector2(300, this.Window.ClientBounds.Height / 2), Color.White);
                        _spriteBatch.DrawString(font, "Press ESC to return to menu", new Vector2(200, this.Window.ClientBounds.Height / 2 + 100), Color.White);
                        EntityLists.enemyList.Clear();
                        EntityLists.playerBulletList.Clear();
                        EntityLists.enemyBulletList.Clear();
                    }
                    break;
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
