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

namespace TRNBulletHell.Game
{
    public class CollisionDetection
    {
        bool invincible = false;
        TimeSpan timer = new TimeSpan(0, 0, 3);
        public void detectCollision(Dictionary<String, List<AbstractEntity>> entityList, GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime;
            if (timer <= TimeSpan.Zero)
            {
                invincible = false;
            }

            // Do 20dmg to player if collides with enemy
            foreach (var p in entityList["Players"].ToArray())
            {
                Player player = (Player)p;
                foreach(var enemy in entityList["Enemies"])
                {
                    if (player.Rectangle.Intersects(enemy.Rectangle))
                    {
                        player.TakeDamage(10);
                        Debug.WriteLine("player touch enemy");
                    }
                }
            }

            // Player takes damage if hit by enemy bullet
            foreach (var p in entityList["Players"].ToArray())
            {
                Player player = (Player)p;
                foreach (var b in entityList["EnemyBullets"].ToArray())
                {
                    if(!invincible)
                    {
                        Bullet bullet = (Bullet)b;
                        if (player.Rectangle.Intersects(bullet.Rectangle))
                        {
                            player.TakeDamage(bullet.GetDamage());
                            entityList["EnemyBullets"].Remove(b);
                            respawnPlayer(player, entityList);
                            Debug.WriteLine("player hit");
                        }
                    }
                }

                // remove player
                if(p.isRemoved)
                {
                    entityList["Players"].Remove(p);
                }
            }

            // Enemy takes damage if hit by player bullet
            foreach (var e in entityList["Enemies"].ToArray())
            {
                Enemy enemy = (Enemy)e;
                foreach (var b in entityList["PlayerBullets"].ToArray())
                {
                    Bullet bullet = (Bullet)b;
                    if (enemy.Rectangle.Intersects(bullet.Rectangle))
                    {
                        enemy.TakeDamage(bullet.GetDamage());
                        entityList["PlayerBullets"].Remove(b);
                        Debug.WriteLine("enemy hit");
                    }

                    // remove enemy and bullet
                    if (e.isRemoved)
                    {
                        entityList["Enemies"].Remove(e);
                    }
                }
            }

        }

        void respawnPlayer(Player player, Dictionary<String, List<AbstractEntity>> entityList)
        {
            player.movement.position.X = 400;
            player.movement.position.Y = 450;
            entityList["EnemyBullets"].Clear();
            entityList["PlayerBullets"].Clear();
            invincible = true;
            this.timer = new TimeSpan(0, 0, 3);
        }
    }
}
