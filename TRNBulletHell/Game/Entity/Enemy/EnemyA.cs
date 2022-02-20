using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        public BulletA BulletClone;

        public EnemyA(Texture2D texture) : base(texture)
        {
            Speed = 2f;
        }

        public void firstAttack(GameTime gameTime, List<AbstractEntity> entities)
        {

                switch (Step)
                {
                    case 0:
                    shootBullet(entities);
                        this.position.X += Speed;
                        if (this.position.X == 230) Step++;
                        break;
                    case 1:
                        this.position.Y += Speed;
                        if (this.position.Y == 150) Step++;
                        break;
                    case 2:
                        this.position.X += Speed;
                    shootBullet(entities);
                    if (this.position.X == 400) Step++;
                        break;
                    case 3:
                        this.position.Y += Speed;
                        if (this.position.Y == 300) Step++;
                        break;
                    case 4:
                        this.position.X += Speed;
                    shootBullet(entities);
                    if (this.position.X == 500) Step++;
                        break;
                    case 5:
                        this.position.Y -= Speed;
                        if (this.position.Y == 100) Step++;
                        break;
                    case 6:
                        this.position.X -= Speed;
                    shootBullet(entities);
                    if (this.position.X == 100) Step++;
                        break;
                    default:
                        break;
                }
        }

        public override void Update(GameTime gameTime, List<AbstractEntity> entities)
        {
            counter++;
            firstAttack(gameTime, entities);
        }

        public void shootBullet(List<AbstractEntity> entities)
        {
            if ((counter % 25) == 0)
            {
                AddBullet(entities);
            }
        }

        private void AddBullet(List<AbstractEntity> entities)
        {
            var bullet = BulletClone.Clone() as BulletA;
            bullet.direction = new Vector2(0, 1);
            bullet.position = this.position;
            bullet.speed = this.Speed * 2;
            entities.Add(bullet);
            counter++;
        }


    }
}
