using System;
using System.IO;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace grow_a_plant
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Plant_handler _plant_handler;
        private Data_handler _data_Handler;
        private Time_handler _timeHandler;
        private Weather_handler _weather_handler;
        private Sound_handler _soundHandler;
        private KeyboardState _prevKeyState;

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
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            _soundHandler = new Sound_handler(Content);
            _prevKeyState = Keyboard.GetState();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _data_Handler = new Data_handler();

            _font = Content.Load<SpriteFont>("File");

            // Load saved time state and pass into Time_handler
            var savedTime = _data_Handler.load_time_state(); // nullable tuple
            _timeHandler = new Time_handler(savedTime);

            // Start weather updates per 30 minutes
            _weather_handler = new Weather_handler();
            _weather_handler.start_periodic_updates(TimeSpan.FromMinutes(1)); // For testing, you might want to set this to a shorter interval like 5 minutes

            // Load plant and if the data file doesn't exist, create a new plant with default values
            Plant plant = _data_Handler.load_plant_data();
            _plant_handler = new Plant_handler(plant, _weather_handler, _timeHandler.get_offline_game_seconds(_data_Handler.load_time_state()?.LastSavedUtcTicks ?? DateTime.UtcNow.Ticks));
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

                // plays soundeffect when P is pressed

                // TODO: Add your update logic here

                base.Update(gameTime);
                _prevKeyState = currState;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw current in-game clock
            _spriteBatch.DrawString(_font, _timeHandler?.to_clock_string() ?? "00:00", new Vector2(100, 100), Color.White);
            _weather_handler.draw(_spriteBatch, _font, new Vector2(100,200));
            _plant_handler.draw_plant_info(_spriteBatch, _font);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void on_exiting(object sender, Microsoft.Xna.Framework.ExitingEventArgs args)
        {
            // Persist time state via Data_handler
            if (_timeHandler != null && _data_Handler != null)
            {
                var state = _timeHandler.get_save_state();
                _data_Handler.save_time_state(state.LastSavedUtcTicks, state.DayCount);
            }
            _weather_handler?.Dispose();
            base.OnExiting(sender, args);
        }
    }
}
