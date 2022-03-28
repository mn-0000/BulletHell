﻿using Microsoft.Xna.Framework;
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
        Texture2D playerSprite;
        Texture2D backgroundSprite;
        Texture2D playerBullet2D;
        PlayerBullet playerBullet;
        Player player;
        EnemyA enemyA;
        EnemyB enemyB;
        MidBoss midBoss;
        FinalBoss finalBoss;
        SpriteFont font;
        protected Dictionary<String, IEnumerable<AbstractEntity>> _entities = new Dictionary<String, IEnumerable<AbstractEntity>>();
        protected List<Enemy> enemies = new List<Enemy>();
        protected List<Player> players = new List<Player>();
        protected List<Bullet> enemyBullets = new List<Bullet>();
        protected List<Bullet> playerBullets = new List<Bullet>();
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
            players.Add(new Player(_graphics.GraphicsDevice, Content.Load<Texture2D>("player")));
            enemyA = new EnemyA(Content.Load<Texture2D>("enemyA"));
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

            enemies.Add(new EnemyA(enemyATexture)
            {
                BulletClone = new BulletA(playerBullet2D)
            });

            _entities.Add("Players", players);
            _entities.Add("Enemies", enemies);
            _entities.Add("PlayerBullets", new List<Bullet>());
            _entities.Add("EnemyBullets", new List<Bullet>());

        }

        protected override void Update(GameTime gameTime)
        {
            minutes = gameTime.TotalGameTime.Minutes;
            seconds = gameTime.TotalGameTime.Seconds;
            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _remainingDelay -= timer;

            // enemyAs spawn
            for (int i = 0; i < 5; i++)
            {
                if (_remainingDelay <= 0 && enemyACount < 5)
                {
                    enemyACount++;
                    enemies.Add(enemyFactory.CreateEnemy("EnemyA", enemyATexture));
                    _remainingDelay = _delay;
                }
            }

            // enemyBs spawn
            for (int i = 0; i < 5; i++)
            {
                if (gameTime.TotalGameTime.Seconds >= 30 && _remainingDelay <= 0 && enemyBCount < 5)
                {
                    enemyBCount++;
                    enemies.Add(enemyFactory.CreateEnemy("EnemyB", enemyBTexture));
                    _remainingDelay = _delay;
                }
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
            collisionDetection.detectCollision(_entities);
            


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(font, enemyA.movement.position.X.ToString() , new Vector2(100, 0), Color.White);
            //player.Draw(_spriteBatch);
            //enemyA.Draw(_spriteBatch);

            foreach (var player in _entities["Players"])
            {
                player.Draw(_spriteBatch);
            }

            foreach (var enemy in _entities["Enemies"])
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


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
