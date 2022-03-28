using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy
{
    public abstract class Enemy : AbstractEntity
    {

        //List of movements enemy will perform.
        public  List<Movement> movements = new List<Movement>();
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
            this.movement.Moving();

            
            if (this.movement.isComplete() && counter < movements.Count)
            {
                this.movement = movements[counter];
                counter++;
            }

            if(movements[movements.Count-1].isComplete())
            {
                this.isRemoved = true;
            }
        }

    }
}
