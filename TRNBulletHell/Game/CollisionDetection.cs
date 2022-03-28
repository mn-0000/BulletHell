using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRNBulletHell.Game.Entity;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.Enemy;

namespace TRNBulletHell.Game
{
    public class CollisionDetection
    {

        public void detectCollision(Dictionary<String, IEnumerable<AbstractEntity>> enitityList)
        {
            // Do 20dmg to player if collides with enemy
            foreach(var p in enitityList["Players"])
            {
                Player player = (Player)p;
                foreach(var enemy in enitityList["Enemies"])
                {
                    if (player.Rectangle.Intersects(enemy.Rectangle))
                    {
                        player.TakeDamage(20);
                    }
                }
            }

            // Player takes damage if hit by enemy bullet
            foreach (var p in enitityList["Players"])
            {
                Player player = (Player)p;
                foreach (var b in enitityList["EnemyBullets"])
                {
                    Bullet bullet = (Bullet)b;
                    if (player.Rectangle.Intersects(bullet.Rectangle))
                    {
                        player.TakeDamage(bullet.GetDamage());
                        b.Removed();
                    }
                }

                // remove player
                if(p.isRemoved)
                {
                    List<AbstractEntity> newPlayerList = enitityList["Players"].ToList();
                    newPlayerList.Remove(p);
                    enitityList["Players"] = newPlayerList;
                }
            }

            // Enemy takes damage if hit by player bullet
            foreach (var e in enitityList["Enemies"])
            {
                Enemy enemy = (Enemy)e;
                foreach (var b in enitityList["PlayerBullets"])
                {
                    Bullet bullet = (Bullet)b;
                    if (enemy.Rectangle.Intersects(bullet.Rectangle))
                    {
                        enemy.TakeDamage(bullet.GetDamage());
                        b.Removed();
                    }
                }

                // remove enemy
                if (e.isRemoved)
                {
                    List<AbstractEntity> newEnemyList = enitityList["Enemies"].ToList();
                    newEnemyList.Remove(e);
                    enitityList["Players"] = newEnemyList;
                }
            }


        }
    }
}
