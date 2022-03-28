using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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

        public Enemy(Texture2D texture) :base(texture)
        {

        }
        public void addMove(Movement m)
        {
            movements.Add(m);
        }

        public override void Update(GameTime gameTime, List<AbstractEntity> entities)
        {
            counter++;
            this.movement.Moving();

            //From tutorial 006.

            this.movement.direction = new Vector2((float)Math.Cos(movement._rotation), (float)Math.Sin(movement._rotation));

            if (this.movement.isComplete() && counter < movements.Count)
            {
                this.movement = movements[counter];
                
            }

            if(movements[movements.Count-1].isComplete())
            {
                this.isRemoved = true;
            }
            this.shootBullet(entities);
        }

        public void shoot(List<AbstractEntity> entities)
        {
            
                PlayerBullet bullet = new PlayerBullet(enemyBullet.getImage());
                bullet.movement.direction = new Vector2();
                bullet.movement.direction.X = this.movement.direction.X;
                bullet.movement.direction.Y = this.movement.direction.Y;
                bullet.movement.position = new Vector2();
                bullet.movement.position.X = this.movement.position.X;
                bullet.movement.position.Y = this.movement.position.Y;
                entities.Add(bullet);
            
        }


        public void shootBullet(List<AbstractEntity> entities)
        {
            if ((counter % 25) == 0)
            {
                shoot(entities);
            }
        }


    }
}
