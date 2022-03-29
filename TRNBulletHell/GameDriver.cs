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

            // waves
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
            //for clock display
            minutes = gameTime.TotalGameTime.Minutes;
            seconds = gameTime.TotalGameTime.Seconds;

            //Set delay for spawning.
            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _remainingDelay -= timer;

            // enemyAs spawn
            /*   if (_remainingDelay <= 0 && enemyACount < 3)
               {
                   enemyACount++;
                   EnemyA a = (EnemyA)enemyFactory.CreateEnemy("EnemyA", enemyATexture);
                   a.enemyBullet = new PlayerBullet(playerBullet2D);
                   enemies.Add(a);                 
                   _remainingDelay = _delay;
               }*/


            double waveTimer = gameTime.TotalGameTime.TotalSeconds;
           // Wave first = new Wave(0, 3, "EnemyA", enemyATexture);
            if (first.createWave(waveTimer, _remainingDelay, enemyBullet) || 
                second.createWave(waveTimer, _remainingDelay, enemyBullet) || 
                third.createWave(waveTimer, _remainingDelay, enemyBullet) || 
                fourth.createWave(waveTimer, _remainingDelay, enemyBullet))
            {
                _remainingDelay = _delay;
            }

            // Wave first = new Wave(30, 1, "MidBoss", midBossTexture);
            // MidBoss spawn
            /*    if (gameTime.TotalGameTime.TotalSeconds >= 30 && _remainingDelay <= 0 && midBossCount < 1)
                {
                    midBossCount++;
                    Enemy m = enemyFactory.CreateEnemy("MidBoss", midBossTexture);
                    m.enemyBullet = new PlayerBullet(playerBullet2D);
                    enemies.Add(m);
                    _remainingDelay = _delay;
                }*/

            // Wave third = new Wave(90, 6, "EnemyB", enemyBTexture);
            // enemyBs spawn
            /* if (gameTime.TotalGameTime.TotalSeconds >= 90 && _remainingDelay <= 0 && enemyBCount < 5)
             {
                 enemyBCount++;
                 Enemy b = enemyFactory.CreateEnemy("EnemyB", enemyBTexture);
                 b.enemyBullet = new PlayerBullet(playerBullet2D);
                 enemies.Add(b);
                 _remainingDelay = _delay;
             }*/
            // Wave four = new Wave(120, 1, "FinalBoss", finalBossTexture);
            // FinalBoss spawn
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
                return (EntityLists.enemyList.ToArray().Length == 0);
            }

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // update all entities
            EntityLists.Update(gameTime);

            // detect collisions
            collisionDetection.detectCollision(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);

            foreach (var player in EntityLists.playerList)
            {
                player.Draw(_spriteBatch);
            }

            foreach (var enemy in EntityLists.enemyList)
            {
                enemy.Draw(_spriteBatch);
            }

            foreach (var enemy in EntityLists.playerBulletList)
            {
                enemy.Draw(_spriteBatch);
            }

            foreach (var enemy in EntityLists.enemyBulletList)
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
            if(EntityLists.playerList.Count != 0)
            {
                _spriteBatch.DrawString(font, $"Health: { EntityLists.playerList[0].GetHealth().ToString()}", new Vector2(20, 10), Color.White);
            }
            else
            {
                _spriteBatch.DrawString(font, "Game Over", new Vector2(325, this.Window.ClientBounds.Height / 2), Color.White);
            }

            if(win)
            {
                _spriteBatch.DrawString(font, "Winner", new Vector2(325, this.Window.ClientBounds.Height / 2), Color.White);
                EntityLists.enemyList.Clear();
                EntityLists.playerBulletList.Clear();
                EntityLists.enemyBulletList.Clear();
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
