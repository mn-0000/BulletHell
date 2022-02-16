using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TRNBulletHell
{
    public class GameDriver : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D enemySprite;
        Texture2D playerSprite;
        Texture2D backgroundSprite;

        Vector2 playerPosition = new Vector2(100, 100);
        const int enemyRadius = 75;
        int score = 0;
        SpriteFont gameFont;
        public GameDriver()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            enemySprite = Content.Load<Texture2D>("enemy");
            playerSprite = Content.Load<Texture2D>("player");
            backgroundSprite = Content.Load<Texture2D>("background");
            gameFont = Content.Load<SpriteFont>("galleryFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //should be key??

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape) )
            {
                Exit();
            }
            if (state.IsKeyDown(Keys.Left))
            {
                playerPosition.X = playerPosition.X + -5;
                //move player left
            }
            if (state.IsKeyDown(Keys.Right))
            {
                playerPosition.X = playerPosition.X + 5;
                //move player right
            }
            if (state.IsKeyDown(Keys.Up))
            {
                playerPosition.Y = playerPosition.Y + -5;
                //move player forward 
            }
            if (state.IsKeyDown(Keys.Down))
            {
                playerPosition.Y = playerPosition.Y + 5;
                //move player backwards
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(gameFont, "Hello World", new Vector2(100, 100), Color.White);
            _spriteBatch.Draw(enemySprite, new Vector2(300, 300), Color.White);
            _spriteBatch.Draw(playerSprite, playerPosition, Color.White);
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
