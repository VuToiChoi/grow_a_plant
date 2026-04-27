using System;
using System.IO;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace grow_a_plant
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Sound_handler _soundHandler;
        KeyboardState _prevKeyState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            _soundHandler = new Sound_handler(Content);
            _prevKeyState = Keyboard.GetState();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState currState = Keyboard.GetState();

            if (currState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (currState.IsKeyDown(Keys.P) && _prevKeyState.IsKeyUp(Keys.P))
            {
                _soundHandler.play_water_sound(Content);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
            _prevKeyState = currState;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
