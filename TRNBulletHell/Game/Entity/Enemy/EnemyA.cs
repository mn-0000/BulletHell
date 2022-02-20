﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Enemy
{
    class EnemyA : Enemy
    {
        public float Speed;
<<<<<<< HEAD:TRNBulletHell/Game/Entity/Enemy/EnemyA/EnemyA.cs
        public int Step;
        public EnemyA(Texture2D texture) { 
         
            this.texture = texture;
        
       
            Speed = 2f;
        }
        public EnemyA()
=======

        public EnemyA(Texture2D texture) : base(texture)
>>>>>>> 2-FactoryClasses:TRNBulletHell/Game/Entity/Enemy/EnemyA.cs
        {


            Speed = 2f;
        }

        public void firstAttack()
        {
                switch (Step)
                {
                    case 0:
                        this.position.X += Speed;
                        if (this.position.X == 230) Step++;
                        break;
                    case 1:
                        this.position.Y += Speed;
                        if (this.position.Y == 150) Step++;
                        break;
                    case 2:
                        this.position.X += Speed;
                        if (this.position.X == 400) Step++;
                        break;
                    case 3:
                        this.position.Y += Speed;
                        if (this.position.Y == 300) Step++;
                        break;
                    case 4:
                        this.position.X += Speed;
                        if (this.position.X == 500) Step++;
                        break;
                    case 5:
                        this.position.Y -= Speed;
                        if (this.position.Y == 100) Step++;
                        break;
                    case 6:
                        this.position.X -= Speed;
                        if (this.position.X == 100) Step++;
                        break;
                    default:
                        break;
                }
        }
    }
}
