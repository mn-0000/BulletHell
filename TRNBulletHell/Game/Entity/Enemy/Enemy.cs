using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;

namespace TRNBulletHell.Game.Entity.Enemy
{
    public abstract class Enemy : AbstractEntity
    {

        //List of movements enemy will perform.
        public PlayerBullet enemyBullet;
        public  List<Movement> movements = new List<Movement>();
        int counter = 0;
        int ProduceBulletcounter = 0;
        protected int frequencyOfBullets;
        
        protected int health;

        public Enemy(Texture2D texture) :base(texture)
        {

        }
        public void addMove(Movement m)
        {
            movements.Add(m);
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public override void Update(GameTime gameTime, IEnumerable<AbstractEntity> entities)
        {
            ProduceBulletcounter++;
            this.movement.Moving();


            this.movement.direction = new Vector2((float)Math.Cos(movement._rotation), (float)Math.Sin(movement._rotation));

            if (this.movement.isComplete() && counter < movements.Count)
            {
                this.movement = movements[counter];
                counter++;
            }

            if(movements[movements.Count-1].isComplete())
            {
                this.isRemoved = true;
            }
            this.shootBullet(entities);
        }


 
        public void shoot(IEnumerable<AbstractEntity> entities)
        {


            /*    float angleDelta = (float)(Math.PI * 2) / 15;  

                float angleSin = (float)Math.Sin(angleDelta);
                float angleCos = (float)Math.Cos(angleDelta);
                x = this.movement.position.X;
                 y = this.movement.position.Y;
                for (int i = 0; i < 15; i++)
                {
                    PlayerBullet bullet = new PlayerBullet(enemyBullet.getImage());
                    bullet.movement.direction = new Vector2();
                    bullet.movement.direction = new Vector2(-1, -1);
                    // bullet.BaseSpeed = speed;
                    bullet.movement.position = (new Vector2(x, y));


                    float newX = x * angleCos - y * angleSin;
                    float newY = x * angleSin + y * angleCos;
                    x = newX; y = newY;
                    entities.Add(bullet);
                }*/


           /* float x = 0, y = -1;
            for (int i = 0; i < 5; i++)
            {
                PlayerBullet bullet = new PlayerBullet(enemyBullet.getImage());
                bullet.movement.direction = new Vector2();
                bullet.movement.direction = new Vector2(x, y);
                //  bullet.movement.direction.Y = this.movement.direction.Y * 3;
                bullet.movement.position = new Vector2();
                bullet.movement.position.X = this.movement.position.X;
                bullet.movement.position.Y = this.movement.position.Y;
                x--;
                y--;
                entities.Add(bullet);*/

                PlayerBullet bullet = new PlayerBullet(enemyBullet.getImage());
                bullet.movement.direction = new Vector2();
                bullet.movement.direction = new Vector2(0, -1);
            //  bullet.movement.direction.Y = this.movement.direction.Y * 3;
                 bullet.movement.position = new Vector2();
                bullet.movement.position.X = this.movement.position.X;
                bullet.movement.position.Y = this.movement.position.Y;
                entities = entities.Concat(new[] { bullet });

        }


        public void shootBullet(IEnumerable<AbstractEntity> entities)
        {
            // frequency can determine the different levels.
            //frequency here = 30
            if ((ProduceBulletcounter % frequencyOfBullets) == 0)
            {
                shoot(entities);
            }
        }


    }
}
