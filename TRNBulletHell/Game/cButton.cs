using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace TRNBulletHell.Game
{
    public class cButton
    {
        Texture2D texture;
        SpriteFont font;
        String text;
        int wordOffset;
        Vector2 position;
        Vector2 textMiddlePoint;
        Vector2 recMiddlePoint;

        Color color = new Color(255, 255, 255, 255);

        public Vector2 size;

        public virtual Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)texture.Width/3 , (int)texture.Height/3 );
            }
        }

        public cButton(Texture2D newTexture, GraphicsDevice graphics, SpriteFont newFont, String newText, int newWordOffset)
        {
            texture = newTexture;
            font = newFont;
            text = newText;
            wordOffset = newWordOffset;
            Vector2 textSize = font.MeasureString(text);
            textMiddlePoint = new Vector2(textSize.X / 2, textSize.Y / 2);

        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            //rectangle = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            
            if(mouseRectangle.Intersects(Rectangle))
            {
                if (color.A == 255) down = false;
                if (color.A == 0) down = true;
                if (down) color.A += 5; else color.A -= 5;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }
            else if (color.A < 255)
            {
                color.A += 5;
                isClicked = false;
            }
            
        }

        private int getXCenter()
        {
            return (int)position.X + Rectangle.Width / 2 - wordOffset;
        }

        private int getYCenter()
        {
            return (int)position.Y + Rectangle.Height / 2 - 20;
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, rectangle, color);
            
            spriteBatch.Draw(texture, Rectangle, color);
            spriteBatch.DrawString(font, text, new Vector2(getXCenter(), getYCenter()), Color.White);
        }
    }
}
