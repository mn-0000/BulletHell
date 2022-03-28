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
        //Texture2D playerSprite;
        Texture2D backgroundSprite;
        Texture2D playerBullet2D;
        //PlayerBullet playerBullet;
        SpriteFont font;
        protected Dictionary<String, List<AbstractEntity>> _entities = new Dictionary<String, List<AbstractEntity>>();
        protected List<AbstractEntity> enemies = new List<AbstractEntity>();
        protected List<AbstractEntity> players = new List<AbstractEntity>();
        protected List<AbstractEntity> enemyBullets = new List<AbstractEntity>();
        protected List<AbstractEntity> playerBullets = new List<AbstractEntity>();
        CollisionDetection collisionDetection = new CollisionDetection();
        protected int minutes;
        protected int seconds;
        EnemyFactory enemyFactory = new EnemyFactory();
        BulletFactory bulletFactory = new BulletFactory();
        MovementCreator movementCreator = new MovementCreator();
        private const float _delay = 2; // seconds
        private float _remainingDelay = _delay;
        private int enemyACount = 0;
        private int enemyBCount = 0;
        private int midBossCount = 0;
        private int finalBossCount = 0;
        private bool win = false;

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
            //players.Add(new Player(_graphics.GraphicsDevice, Content.Load<Texture2D>("player")));
            //enemyA = new EnemyA(Content.Load<Texture2D>("enemyA"));
            //enemyB = new EnemyB(Content.Load<Texture2D>("enemyB"));
            //midBoss = new MidBoss(Content.Load<Texture2D>("midboss"));
            //finalBoss = new FinalBoss(Content.Load<Texture2D>("boss"));
            //playerSprite = player.getImage();
            font = Content.Load<SpriteFont>("galleryFont");
            backgroundSprite = Content.Load<Texture2D>("background");

            enemyATexture = Content.Load<Texture2D>("enemyA");
            enemyBTexture = Content.Load<Texture2D>("enemyB");
            midBossTexture = Content.Load<Texture2D>("midBoss");
            finalBossTexture = Content.Load<Texture2D>("boss");
            playerBullet2D = Content.Load<Texture2D>("bullet");

            players.Add(new Player(_graphics.GraphicsDevice, Content.Load<Texture2D>("player"))
            {
                playerBullet = new PlayerBullet(playerBullet2D)
            });
/*
            enemies.Add(new EnemyA(enemyATexture)
            {
                BulletClone = new BulletA(playerBullet2D)
            });
*/
            _entities.Add("Players", players);
            _entities.Add("Enemies", enemies);
            _entities.Add("PlayerBullets", new List<AbstractEntity>());
            _entities.Add("EnemyBullets", new List<AbstractEntity>());

        }

        protected override void Update(GameTime gameTime)
        {
            minutes = gameTime.TotalGameTime.Minutes;
            seconds = gameTime.TotalGameTime.Seconds;
            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _remainingDelay -= timer;

            // enemyAs spawn
            if (_remainingDelay <= 0 && enemyACount < 3)
            {
                enemyACount++;
                EnemyA a = (EnemyA)enemyFactory.CreateEnemy("EnemyA", enemyATexture);
                a.enemyBullet = new PlayerBullet(playerBullet2D);
                enemies.Add(a);                 
                _remainingDelay = _delay;
            }

            // MidBoss spawn
            if (gameTime.TotalGameTime.TotalSeconds >= 30 && _remainingDelay <= 0 && midBossCount < 1)
            {
                midBossCount++;
                Enemy m = enemyFactory.CreateEnemy("MidBoss", midBossTexture);
                m.enemyBullet = new PlayerBullet(playerBullet2D);
                enemies.Add(m);
                _remainingDelay = _delay;
            }

            // enemyBs spawn
            if (gameTime.TotalGameTime.TotalSeconds >= 90 && _remainingDelay <= 0 && enemyBCount < 5)
            {
                enemyBCount++;
                Enemy b = enemyFactory.CreateEnemy("EnemyB", enemyBTexture);
                b.enemyBullet = new PlayerBullet(playerBullet2D);
                enemies.Add(b);
                _remainingDelay = _delay;
            }

            // FinalBoss spawn
            if (gameTime.TotalGameTime.TotalSeconds >= 120 && _remainingDelay <= 0 && finalBossCount < 1)
            {
                finalBossCount++;
                Enemy f = enemyFactory.CreateEnemy("FinalBoss", finalBossTexture);
                f.enemyBullet = new PlayerBullet(playerBullet2D);
                enemies.Add(f);
                _remainingDelay = _delay;
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
