using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy
{
    abstract class Enemy : AbstractEntity
    {

        //List of movements enemy will perform.
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
