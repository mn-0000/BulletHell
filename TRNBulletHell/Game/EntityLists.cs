using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Enemy;
using TRNBulletHell.Game.Entity.LifeSystem;

namespace TRNBulletHell.Game
{
    public sealed class EntityLists
    {
        private static EntityLists instance = null;
        public static List<Enemy> enemyList = new List<Enemy>();
        public static List<Player> playerList = new List<Player>();
        public static List<Bullet> enemyBulletList = new List<Bullet>();
        public static List<Bullet> playerBulletList = new List<Bullet>();
        public static List<LifeSprite> lifeSpriteList = new List<LifeSprite>();

        private EntityLists() { }
        public static EntityLists Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EntityLists();
                }
                return instance;
            }
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var players in EntityLists.playerList)
            {
                players.Update(gameTime);
            }

            foreach (var enemy in EntityLists.enemyList)
            {
                enemy.Update(gameTime);
            }

            foreach (var bullet in EntityLists.playerBulletList)
            {
                bullet.Update(gameTime);
            }

            foreach (var bullet in EntityLists.enemyBulletList)
            {
                bullet.Update(gameTime);
            }
            foreach (var life in EntityLists.lifeSpriteList)
            {
                life.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var player in EntityLists.playerList)
            {
                player.Draw(spriteBatch);
            }

            foreach (var enemy in EntityLists.enemyList)
            {
                enemy.Draw(spriteBatch);
            }

            foreach (var bullet in EntityLists.playerBulletList)
            {
                bullet.Draw(spriteBatch);
            }

            foreach (var bullet in EntityLists.enemyBulletList)
            {
                bullet.Draw(spriteBatch);
            }
            foreach (var life in EntityLists.lifeSpriteList)
            {
                life.Draw(spriteBatch);
            }
        }
    }
}
