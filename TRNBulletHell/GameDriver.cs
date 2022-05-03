using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TRNBulletHell.Game;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Enemy;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Enemy.Boss;
using System.Diagnostics;
using TRNBulletHell.Game.Entity.Move;
using System.Text.Json;
using System.Text.Json.Serialization;
using BulletManager = TRNBulletHell.Game.BulletManager;
using System.IO;
using System.Reflection;
using System.Linq;

namespace TRNBulletHell
{
    public class GameDriver : Microsoft.Xna.Framework.Game
    {
        // graphics/textures
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D enemyATexture;
        public Texture2D enemyBTexture;
        public Texture2D midBossTexture;
        public Texture2D finalBossTexture;
        Texture2D bigBullet;
        Texture2D enemyBullet;
        Texture2D backgroundSprite;
        Texture2D playerBullet2D;
        Texture2D lifeTexture;
        SpriteFont font;
        
        // variables
        protected int minutes;
        protected int seconds;
        private float _delay = 2; // seconds
        private float _remainingDelay = 2;
        private int finalBossCount = 0;
        private bool win = false;

        // gameclock vars
        bool locked = false;
        int offsetMinutes = 0;
        int offsetSeconds = 0;

        // previous mouse state
        MouseState oldState = new MouseState();

        // List of waves
        List<GameWave> waves = new List<GameWave>();
        
        // Current wave indicator
        int currentWave = 0;

        CollisionDetection collisionDetection = new CollisionDetection();
        BulletManager bulletManager = new BulletManager();
        EntityLists entities = EntityLists.Instance;

        enum GameState
        {
            MainMenu,
            Playing,
            Options,
            Quit,
        }

        GameState CurrentGameState = GameState.MainMenu;
        cButton btnPlay, btnOptions, btnQuit, btnBack, btnDifficulty, btnGodMode;



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
            //_graphics.ApplyChanges();
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
            lifeTexture = Content.Load<Texture2D>("HeartSprite2");
            bigBullet = Content.Load<Texture2D>("big-bullet-resized");
            EntityTextures.textureList.Add(lifeTexture);
            EntityTextures.textureList.Add(enemyBullet);
            EntityTextures.textureList.Add(bigBullet);

            // Process user-provided JSON stage file
            // Edit path to file here
            string stageDetails = File.ReadAllText("C:\\Users\\Colin Willis\\Desktop\\teamreptileninjas\\TRNBulletHell\\JSON-Script\\Sample.json");
            RootObject jsonObject = JsonSerializer.Deserialize<RootObject>(stageDetails);

            // Process wave data and create waves.
            // Currently the following attributes of the JSON file are not used:
            // bulletRate, damage
            waves = ProcessWavesData(jsonObject);

            EntityLists.playerList.Add(new Player(_graphics.GraphicsDevice, Content.Load<Texture2D>("player"))
            {
                playerBullet = new PlayerBullet(playerBullet2D)
            });

            // Menu Buttons
            btnPlay = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Play", 30);
            btnPlay.setPosition(new Vector2(325, 100));
            btnOptions = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Options", 55);
            btnOptions.setPosition(new Vector2(325, 200));
            btnQuit = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Quit", 30);
            btnQuit.setPosition(new Vector2(325, 300));

            // Options Buttons
            btnDifficulty = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Difficulty", 65);
            btnDifficulty.setPosition(new Vector2(100, 100));
            btnGodMode = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "God Mode", 75);
            btnGodMode.setPosition(new Vector2(100, 200));
            btnBack = new cButton(Content.Load<Texture2D>("Button"), _graphics.GraphicsDevice, font, "Back", 35);
            btnBack.setPosition(new Vector2(325, 400));
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    this.IsMouseVisible = true;
                    if (btnPlay.isClicked) CurrentGameState = GameState.Playing;
                    if (btnOptions.isClicked) CurrentGameState = GameState.Options;
                    if (btnQuit.isClicked) CurrentGameState = GameState.Quit;
                    btnPlay.Update(currentMouseState);
                    btnOptions.Update(currentMouseState);
                    btnQuit.Update(currentMouseState);
                    break;

                case GameState.Options:
                    this.IsMouseVisible = true;
                    if (btnBack.isClicked) CurrentGameState = GameState.MainMenu;

                    // record single click and toggle option
                    if (currentMouseState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                    {
                        if (btnDifficulty.isClicked) GameOptions.SwitchDifficulty();
                        if (btnGodMode.isClicked) GameOptions.ToggleGodMode();
                    }
                    oldState = currentMouseState;

                    btnBack.Update(currentMouseState);
                    btnDifficulty.Update(currentMouseState);
                    btnGodMode.Update(currentMouseState);
                    break;

                case GameState.Quit:
                    Exit();
                    break;

                case GameState.Playing:
                    this.IsMouseVisible = false;

                    //set clock display
                    if (!locked)
                    {
                        offsetSeconds = gameTime.TotalGameTime.Seconds;
                        offsetMinutes = ((gameTime.TotalGameTime.Seconds - offsetSeconds) / 60);
                        locked = true;
                    }

                    int totalTime = (int)gameTime.TotalGameTime.TotalSeconds - offsetMinutes * 60 - offsetSeconds;
                    minutes = totalTime / 60;
                    seconds = totalTime % 60;  

                    //Set delay for spawning.
                    var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
                    _remainingDelay -= timer;

                    double waveTimer = gameTime.TotalGameTime.TotalSeconds - offsetSeconds;

                    
                    // Create waves
                    if (currentWave < waves.Count)
                    {
                        _delay = waves[currentWave].GetIntervalTime(); // update spawn interval based on JSON script
                        if (waves[currentWave].createWave(waveTimer, _remainingDelay, enemyBullet, waves[currentWave].GetBulletFrequency()))
                        {
                            _remainingDelay = _delay;
                        }

                        // If the wave's enemies are all created, move on to the next wave
                        if (waves[currentWave].IsDoneCreatingEnemies())
                        {
                            currentWave++;
                        }
                    }

                    // check if boss is dead or game is over
                    if ((currentWave == waves.Count && finalBossDead()) || gameTime.TotalGameTime.TotalSeconds - offsetSeconds >= waves.Last().GetStartTime() + 45)
                    {
                        win = true;
                    } 

                    bool finalBossDead()
                    {
                        return (EntityLists.enemyList.ToArray().Length == 0);
                    }

                    // exit if esc pressed
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        Exit();
                    }

                    // update all entities
                    EntityLists.Update(gameTime);

                    //Spawn Bullets from Enemys
                    this.bulletManager.spawnBullets();

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
                    btnBack.Draw(_spriteBatch);

                    btnDifficulty.Draw(_spriteBatch);
                    _spriteBatch.DrawString(font, GameOptions.GetDifficulty(), new Vector2(400, 115), Color.White);

                    btnGodMode.Draw(_spriteBatch);
                    _spriteBatch.DrawString(font, GameOptions.GetGodMode(), new Vector2(400, 215), Color.White);
                    break;

                case GameState.Playing:
                    EntityLists.Draw(_spriteBatch);

                    if (seconds < 10)
                    {
                        _spriteBatch.DrawString(font, $"{minutes + " : 0" + seconds}", new Vector2(700, 0), Color.White);
                    }
                    else
                    {
                        _spriteBatch.DrawString(font, $"{minutes + " : " + seconds}", new Vector2(700, 0), Color.White);

                    }

                    // display health if player(s) is alive
                    if (EntityLists.playerList.Count != 0)
                    {
                        _spriteBatch.DrawString(font, $"Health: { EntityLists.playerList[0].GetHealth().ToString()}", new Vector2(20, 10), Color.White);
                        _spriteBatch.DrawString(font, $"Extra Lives: {EntityLists.playerList[0].getLives().ToString()}", new Vector2(20, 50), Color.White);
                    }
                    else
                    {
                        _spriteBatch.DrawString(font, "Game Over", new Vector2(325, this.Window.ClientBounds.Height / 2), Color.White);
                        _spriteBatch.DrawString(font, "Press ESC to exit", new Vector2(300, this.Window.ClientBounds.Height / 2 + 100), Color.White);
                        EntityLists.enemyList.Clear();
                        EntityLists.playerBulletList.Clear();
                        EntityLists.enemyBulletList.Clear();
                        EntityLists.lifeSpriteList.Clear();
                    }

                    if (win)
                    {
                        _spriteBatch.DrawString(font, "Winner", new Vector2(325, this.Window.ClientBounds.Height / 2), Color.White);
                        _spriteBatch.DrawString(font, "Press ESC to exit", new Vector2(300, this.Window.ClientBounds.Height / 2 + 100), Color.White);
                        EntityLists.enemyList.Clear();
                        EntityLists.playerBulletList.Clear();
                        EntityLists.enemyBulletList.Clear();
                        EntityLists.lifeSpriteList.Clear();
                    }

                    break;
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Process waves data provided by the deserialization of the JSON file.
        /// </summary>
        /// <param name="wavesData"> the deserialization data </param>
        /// <returns> a list of waves found in the data </returns>
        private List<GameWave> ProcessWavesData(RootObject wavesData)
        {
            List<GameWave> gameWaves = new List<GameWave>();

            Wave[] waves = wavesData.stage.wave;
            for (int i = 0; i < waves.Length; i++)
            {
                string enemyType = waves[i].enemyType;

                // Query the fields in GameDriver to look for enemy texture.
                // Should only return 1 result (which is the appropriate enemy texture).
                var texture = from field in typeof(GameDriver).GetFields()
                              where field.Name.ToLower() == (enemyType + "Texture").ToLower()
                              select field;
                Texture2D enemyTexture = (Texture2D)texture.First().GetValue(this);

                // Add wave to list of waves
                GameWave gameWave = new GameWave(waves[i].waveTime, waves[i].enemyAmount, enemyType, enemyTexture);
                gameWave.SetIntervalTime(waves[i].spawnInterval);
                gameWave.SetBulletFrequency(waves[i].bulletRate);
                gameWaves.Add(gameWave);
            }
            return gameWaves;
        }


    }
}