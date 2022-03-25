using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TRNBulletHell.Game.Bullet.BulletA;

namespace TRNBulletHell.Game.Entity.Enemy.Boss
{
    class FinalBoss : Boss
    {
        public float Speed;

        public int Step;
        public BulletA BulletClone;
        public float timer;

        public FinalBoss(Texture2D texture) : base(texture)
        {
            timer = 0f;
            Speed = 2f;
        }

        public void firstAttack(GameTime gameTime, List<AbstractEntity> entities)
        {
           /* timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 33)
            {
                switch (Step)
                {
                    case 0:
                        this.position.X += Speed;
                        shootBullet(entities);
                        if (this.position.X >= 80) Step++;
                        break;
                    case 1:
                        this.position.Y += Speed;
                        if (this.position.Y >= 200) Step++;
                        break;
                    case 2:
                        this.position.Y -= 0.4f * Speed;
                        this.position.X += Speed;
                        shootBullet(entities);
                        if (this.position.Y <= 70) Step++;
                        break;
                    case 3:
                        this.position.Y += Speed;
                        if (this.position.Y >= 210) Step++;
                        break;
                    case 4:
                        this.position.X -= Speed;
                        shootBullet(entities);
                        if (this.position.X <= 100) Step++;
                        break;
                    case 5:
                        shootBullet(entities);
                        this.position.X += 0.8f * Speed;
                        if (this.position.X >= 400) Step++;
                        break;
                    case 6:
                        this.position.Y -= 0.9f * Speed;
                        if (this.position.Y == -100) Step++;
                        break;
                    default:
                        break;
                }

            }*/
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
        {/*
            var bullet = BulletClone.Clone() as BulletA;
            bullet.direction = new Vector2(0, 1);
            bullet.position = this.position;
            bullet.speed = this.Speed * 2;
            entities.Add(bullet);
            counter++;*/
        }
    }
}
