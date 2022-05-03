using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TRNBulletHell.Game.Entity.Bullet;
using TRNBulletHell.Game.Entity.LifeSystem;

namespace TRNBulletHell.Game.Entity.Enemy
{
    public abstract class Enemy : AbstractEntity
    {

        //List of movements enemy will perform.
        //public PlayerBullet enemyBullet;
        public BulletA enemyBullet;
        public  List<Movement> movements = new List<Movement>();
        public int ProduceBulletcounter = 0;
        public int frequencyOfBullets;
        protected Boolean lifeDrop;
        protected int health;
        public LifeSprite lifeTexture;
        public string type;
        public int distance;
        public BulletSpawn bulletSpawn;


        public Enemy(Texture2D texture) :base(texture)
        {
            lifeTexture = new LifeSprite( GameDriver.textureList[0]);
            setRandLifeDrop();
        }

        public void addMove(Movement m)
        {
            movements.Add(m);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public override void Update(GameTime gameTime)
        {
            ProduceBulletcounter++;

            this.movement.direction = new Vector2((float)Math.Cos(movement._rotation), (float)Math.Sin(movement._rotation));
            this.movement.Moving(gameTime);

            if (this.movement.isComplete() && counter < movements.Count)
            {
                this.movement = movements[counter];
                counter++;
            }

            if(movements[movements.Count-1].isComplete())
            {
                this.isRemoved = true;
            }
           // this.shootBullet();

            checkHealth();
        }

        public void rotateHelper()
        {

        }

        public void checkHealth()
        {
            if (health <= 0)  // If enemy is killed, try to drop extra life.
            {
                isRemoved = true;
                dropLife();
            }
        }

        /// <summary>
        /// Randomly sets lifeDrop var to be true or false.
        /// </summary>
        public void setRandLifeDrop()
        {
            Random r1 = new Random();

            int num1 = r1.Next(10);
            int num2 = r1.Next(10);

            if (num1 == num2)
            {
                this.lifeDrop = true;
            }
            else
            {
                this.lifeDrop = false;
            }

        }

        /// <summary>
        /// Drops a life if the lifeDrop var is true.
        /// </summary>
        public void dropLife()
        {
            if (this.lifeDrop)
            {
                LifeSprite life = lifeTexture.Clone() as LifeSprite;
                life.movement.direction = new Vector2();
                life.movement.direction = new Vector2(0, -1);
                life.movement.position = new Vector2();
                life.movement.position.X = this.movement.position.X;
                life.movement.position.Y = this.movement.position.Y;
                EntityLists.lifeSpriteList.Add(life);
            }
        }

    }
}
