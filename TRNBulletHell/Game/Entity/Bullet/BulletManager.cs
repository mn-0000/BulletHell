using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TRNBulletHell.Game.Entity.Bullet
{
    public class BulletManager
    {
        public PlayerBullet playerBullet;
        private List<AbstractEntity> bulletList = new List<AbstractEntity>();
        public Texture2D bulletSprite;
        public Vector2 PlayerPosition;

        public BulletManager()
        {

        }

        public void Update()
        {

        }

        public void getBulletSprite(Texture2D x)
        {
            this.bulletSprite = x; 
        }

        public void getPlayerPosition(Vector2 position)
        {
            PlayerPosition = new Vector2(position.X, position.Y);
        }

        public void createBullet(List<AbstractEntity> entities)
        {
            PlayerBullet bullet = playerBullet.Clone() as PlayerBullet;
            bullet.movement.direction = new Vector2(0, 1);
            bullet.movement.position = new Vector2(PlayerPosition.X, PlayerPosition.Y);
            entities.Add(bullet);
        }
    }
}
