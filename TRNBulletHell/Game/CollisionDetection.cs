using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Enemy;
using Microsoft.Xna.Framework;
using TRNBulletHell.Game.Entity.LifeSystem;

namespace TRNBulletHell.Game
{
    public class CollisionDetection
    {
        bool invincible = false;
        TimeSpan timer = new TimeSpan(0, 0, 3);
        public void detectCollision(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime;
            if (timer <= TimeSpan.Zero)
            {
                invincible = false;
            }

            // Do 20dmg to player if collides with enemy
            foreach (var p in EntityLists.playerList.ToArray())
            {
                Player player = (Player)p;
                foreach(var enemy in EntityLists.enemyList)
                {
                    if (player.Rectangle.Intersects(enemy.Rectangle))
                    {
                        player.TakeDamage(10);
                        Debug.WriteLine("player touch enemy");
                    }
                }
            }

            // Player takes damage if hit by enemy bullet
            foreach (var p in EntityLists.playerList.ToArray())
            {
                Player player = (Player)p;
                foreach (var b in EntityLists.enemyBulletList.ToArray())
                {
                    if(!invincible)
                    {
                        Bullet bullet = (Bullet)b;
                        if (player.Rectangle.Intersects(bullet.Rectangle))
                        {
                            player.TakeDamage(bullet.GetDamage());
                            EntityLists.enemyBulletList.Remove(b);
                            respawnPlayer(player);
                            Debug.WriteLine("player hit");
                        }
                    }
                }

                // Player gets extra life if runs into the life sprite.
                foreach (var ls in EntityLists.lifeSpriteList.ToArray())
                {
                    LifeSprite life = ls;
                    if (player.Rectangle.Intersects(life.Rectangle))
                    {
                        player.addLife();
                        EntityLists.lifeSpriteList.Remove(ls);
                        Debug.WriteLine("plus one life");
                    }
                }

                // remove player
                if (p.isRemoved)
                {
                    EntityLists.playerList.Remove(p);
                }
            }

            // Enemy takes damage if hit by player bullet
            foreach (var enemy in EntityLists.enemyList.ToArray())
            {
                foreach (var bullet in EntityLists.playerBulletList.ToArray())
                {
                    if (enemy.Rectangle.Intersects(bullet.Rectangle))
                    {
                        enemy.TakeDamage(bullet.GetDamage());
                        EntityLists.playerBulletList.Remove(bullet);
                        Debug.WriteLine("enemy hit");
                    }

                    // remove enemy and bullet
                    if (enemy.isRemoved)
                    {
                        EntityLists.enemyList.Remove(enemy);
                    }
                }
            }

        }

        void respawnPlayer(Player player)
        {
            player.movement.position.X = 400;
            player.movement.position.Y = 450;
            EntityLists.enemyBulletList.Clear();
            EntityLists.playerBulletList.Clear();
            invincible = true;
            this.timer = new TimeSpan(0, 0, 3);
        }
    }
}
