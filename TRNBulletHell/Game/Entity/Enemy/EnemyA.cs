using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Bullet.BulletA;

namespace TRNBulletHell.Game.Entity.Enemy
{
    class EnemyA : Enemy
    {
        public float Speed;
        public int Step;
        public BulletA Bullet;

        public EnemyA(Texture2D texture) : base(texture)
        {


            Speed = 2f;
        }
<<<<<<< HEAD:TRNBulletHell/Game/Entity/Enemy/EnemyA/EnemyA.cs
        public void firstAttack(GameTime gameTime)
=======

        public void firstAttack()
>>>>>>> 2-FactoryClasses:TRNBulletHell/Game/Entity/Enemy/EnemyA.cs
        {
                switch (Step)
                {
                    case 0:
                        this.position.X += Speed;
                        //Bullet = AddBullet();
                   
                        //Bullet.Update(gameTime);
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

        public void Update(GameTime gameTime)
        {
            firstAttack(gameTime);
            AddBullet();
        }

        private void AddBullet()
        {
            var bullet = Bullet.Clone() as BulletA;
            bullet.Direction = new Vector2(this.direction.X, 100);
            bullet.Position = this.position;
            bullet.LinearVelocity = this.Speed * 2;
            //return bullet;
        }


    }
}
