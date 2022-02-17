using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TRNBulletHell.Game.Entity.Player;
namespace TRNBulletHell
{
    public class GameDriver : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D enemyASprite;
        Texture2D playerSprite;
        Texture2D backgroundSprite;


        Player player;
       

        public GameDriver()
        {
            _graphics = new GraphicsDeviceManager(this);           
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            player = new Player(Content.Load<Texture2D>("player"));
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            enemyASprite = Content.Load<Texture2D>("enemyA");
            playerSprite = player.getImage();
            backgroundSprite = Content.Load<Texture2D>("background");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            player.checkIfPlayersMoving(state);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(enemyASprite, new Vector2(300, 0), Color.White);
            _spriteBatch.Draw(playerSprite, player.getPosition(), Color.White);
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
