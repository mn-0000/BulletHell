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
        protected Dictionary<String, List<AbstractEntity>> _entities = new Dictionary<String, List<AbstractEntity>>();
        protected List<AbstractEntity> enemies = new List<AbstractEntity>();
        protected List<AbstractEntity> players = new List<AbstractEntity>();
        protected List<AbstractEntity> enemyBullets = new List<AbstractEntity>();
        protected List<AbstractEntity> playerBullets = new List<AbstractEntity>();
        CollisionDetection collisionDetection = new CollisionDetection();
       protected int minutes;
        protected int seconds;

        private const float _delay = 2; // seconds
        private float _remainingDelay = _delay;

        private int finalBossCount = 0;
        private bool win = false;
        Wave first;
        Wave second;
        Wave third;
        Wave fourth;


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
 
            font = Content.Load<SpriteFont>("galleryFont");
            backgroundSprite = Content.Load<Texture2D>("background");

            enemyATexture = Content.Load<Texture2D>("enemyA");
            enemyBTexture = Content.Load<Texture2D>("enemyB");
            midBossTexture = Content.Load<Texture2D>("midBoss");
            finalBossTexture = Content.Load<Texture2D>("boss");
            playerBullet2D = Content.Load<Texture2D>("bullet");
            enemyBullet = Content.Load<Texture2D>("EnemyBullet");


            first = new Wave(0, 3, "EnemyA", enemyATexture);
            second = new Wave(30, 1, "MidBoss", midBossTexture);
            third = new Wave(60, 5, "EnemyB", enemyBTexture);
            fourth = new Wave(90, 1, "FinalBoss", finalBossTexture);



            players.Add(new Player(_graphics.GraphicsDevice, Content.Load<Texture2D>("player"))
            {
                playerBullet = new PlayerBullet(playerBullet2D)
            });

            _entities.Add("Players", players);
            _entities.Add("Enemies", enemies);
            _entities.Add("PlayerBullets", new List<AbstractEntity>());
            _entities.Add("EnemyBullets", new List<AbstractEntity>());

        }

        protected override void Update(GameTime gameTime)
        {
            //for clock display
            minutes = gameTime.TotalGameTime.Minutes;
            seconds = gameTime.TotalGameTime.Seconds;

            //Set delay for spawning.
            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _remainingDelay -= timer;

        


            double waveTimer = gameTime.TotalGameTime.TotalSeconds;
           

            // Returns true if spawn was created in a wave. 
            if (first.createWave(waveTimer, _remainingDelay, enemies, enemyBullet) || second.createWave(waveTimer, _remainingDelay, enemies, enemyBullet) || third.createWave(waveTimer, _remainingDelay, enemies, enemyBullet) || fourth.createWave(waveTimer, _remainingDelay, enemies, enemyBullet))
            {
                _remainingDelay = _delay;
            }


            if (gameTime.TotalGameTime.TotalSeconds >= 120 && _remainingDelay <= 0 && finalBossCount < 1)
            {
                finalBossCount++;
                
            }
            
            // check if boss is dead or game is over
            if(finalBossCount >= 1 && (gameTime.TotalGameTime.TotalSeconds >= 150 || finalBossDead()))
            {
                win = true;
            }

            bool finalBossDead()
            {
                return (_entities["Enemies"].ToArray().Length == 0);
            }

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // update all entities
            foreach (var players in _entities["Players"])
            {
                players.Update(gameTime, _entities["PlayerBullets"]);
            }

            foreach (var enemy in _entities["Enemies"])
            {
                enemy.Update(gameTime, _entities["EnemyBullets"]);
            }

            foreach(var bullet in _entities["PlayerBullets"])
            {
                bullet.Update(gameTime, _entities["PlayerBullets"]);
            }

            foreach (var bullet in _entities["EnemyBullets"])
            {
                bullet.Update(gameTime, _entities["EnemyBullets"]);
            }

            // detect collisions
            collisionDetection.detectCollision(_entities, gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            foreach (var player in _entities["Players"])
            {
                player.Draw(_spriteBatch);
            }

            foreach (var enemy in _entities["Enemies"])
            {
                enemy.Draw(_spriteBatch);
            }

            foreach (var enemy in _entities["PlayerBullets"])
            {
                enemy.Draw(_spriteBatch);
            }

            foreach (var enemy in _entities["EnemyBullets"])
            {
                enemy.Draw(_spriteBatch);
            }

            if (seconds < 10)
            {
                _spriteBatch.DrawString(font, $"{minutes + " : 0" + seconds}", new Vector2(700, 0), Color.White);
            }
            else
            {
                _spriteBatch.DrawString(font, $"{minutes + " : " + seconds}", new Vector2(700, 10), Color.White);
            }

            // display health if player(s) is alive
            if(_entities["Players"].Count != 0)
            {
                Player p = (Player)_entities["Players"][0];
                _spriteBatch.DrawString(font, $"Health: { p.GetHealth().ToString()}", new Vector2(20, 10), Color.White);
            }
            else
            {
                _spriteBatch.DrawString(font, "Game Over", new Vector2(325, this.Window.ClientBounds.Height / 2), Color.White);
            }

            if(win)
            {
                _spriteBatch.DrawString(font, "Winner", new Vector2(325, this.Window.ClientBounds.Height / 2), Color.White);
                _entities["Enemies"].Clear();
                _entities["PlayerBullets"].Clear();
                _entities["EnemyBullets"].Clear();
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
