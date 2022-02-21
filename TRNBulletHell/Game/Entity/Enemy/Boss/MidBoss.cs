using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Bullet.BulletA;

namespace TRNBulletHell.Game.Entity.Enemy.Boss
{
    class MidBoss : Boss
    {
        public float Speed;

        public int Step;
        public BulletA BulletClone;

        public MidBoss(Texture2D texture) : base(texture)
        {
            Speed = 2f;
        }

        public void firstAttack(GameTime gameTime, List<AbstractEntity> entities)
        {
            switch (Step)
            {
                case 0:
                    this.position.X += 0.8f * Speed;
                    this.position.Y += Speed;
                    shootBullet(entities);
                    if (this.position.Y == 250) Step++;
                    break;
                case 1:
                    this.position.X += 0.8f * Speed;
                    this.position.Y -= Speed;
                    if (this.position.Y <= 200 && this.position.X >= 360) Step++;
                    break;
                case 2:
                    this.position.Y += Speed;
                    this.position.X += 0.8f * Speed;
                    shootBullet(entities);
                    if (this.position.Y >= 250) Step++;
                    break;
                case 3:
                    this.position.X -= Speed;
                    this.position.Y -= 0.6f * Speed;
                    if (this.position.Y <= 100) Step++;
                    break;
                case 4:
                    this.position.X += Speed;
                    shootBullet(entities);
                    if (this.position.X >= 500) Step++;
                    break;
                case 5:
                    this.position.X -= 0.8f * Speed;
                    this.position.Y += 0.6f * Speed;
                    if (this.position.Y >= 280) Step++;
                    break;
                case 6:
                    this.position.X += Speed;
                    this.position.Y -= 0.75f * Speed;
                    shootBullet(entities);
                    if (this.position.Y <= 180) Step++;
                    break;
                case 7:
                    this.position.Y -= 0.2f * Speed;
                    if (this.position.Y <= 100) Step++;
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
