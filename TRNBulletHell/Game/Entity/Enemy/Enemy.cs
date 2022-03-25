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
        public Enemy(Texture2D texture) :base(texture)
        {

        }
        public void addMove(Movement m)
        {
            movements.Add(m);
        }

        public virtual void Update()
        {
            this.movement.Moving();

            if (this.movement.isComplete() && movements.Count > 0)
            {
                this.movement = movements[0];
                movements.RemoveAt(0);
            }
        }

    }
}
