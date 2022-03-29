using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Enemy;

namespace TRNBulletHell.Game
{
    public sealed class EntityLists
    {
        private static EntityLists instance = null;
        public static List<Enemy> enemyList = new List<Enemy>();
        public static List<Player> playerList = new List<Player>();
        public static List<Bullet> enemyBulletList = new List<Bullet>();
        public static List<Bullet> playerBulletList = new List<Bullet>();
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
        }

        /*
        public List<Player> GetPlayerList()
        {
            return players;
        }

        public List<Bullet> GetPlayerBulletList()
        {
            return playerBullets;
        }

        public List<Enemy> GetEnemyList()
        {
            return enemies;
        }

        public List<Bullet> GetEnemyBulletList()
        {
            return enemyBullets;
        }
        */
    }
}
