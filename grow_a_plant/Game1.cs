using Microsoft.Xna.Framework;
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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _data_Handler = new Data_handler();

            _font = Content.Load<SpriteFont>("File");

            // Load plant (use Data_handler.LoadPlantData if desired)
            Plant plant = new Plant(0, 0, 0);
            _plant_handler = new Plant_handler(plant);

            // Load saved time state and pass into Time_handler
            var savedTime = _data_Handler.load_time_state(); // nullable tuple
            _timeHandler = new Time_handler(savedTime);

            // Start weather updates per 30 minutes
            _weather_handler = new Weather_handler();
            _weather_handler.start_periodic_updates(TimeSpan.FromMinutes(30)); // For testing, you might want to set this to a shorter interval like 5 minutes

            // Example: save plant after initial update
            _data_Handler.save_plant_data(plant);
            _plant_handler.update_plant_info();
            _data_Handler.save_plant_data(plant);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _timeHandler?.update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw current in-game clock
            _spriteBatch.DrawString(_font, _timeHandler?.to_clock_string() ?? "00:00", new Vector2(100, 100), Color.White);


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
