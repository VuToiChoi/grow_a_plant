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
        private Data_handler _data_handler;
        private Time_handler _time_handler;
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

            // Save on exit
            this.Exiting += on_exiting;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _data_handler = new Data_handler();

            _font = Content.Load<SpriteFont>("File");

            // Load saved time state and create a single Time_handler
            var saved_time = _data_handler.load_time_state();
            _time_handler = new Time_handler(saved_time);

            // Start weather updates
            _weather_handler = new Weather_handler();
            _weather_handler.start_periodic_updates(TimeSpan.FromMinutes(1));

            // Load plant
            Plant plant = _data_handler.load_plant_data();

            // Compute offline game-seconds once from the saved ticks and pass into Plant_handler
            long last_saved_ticks = saved_time?.LastSavedUtcTicks ?? DateTime.UtcNow.Ticks;
            float offline_game_seconds = _time_handler.get_offline_game_seconds(last_saved_ticks);

            _plant_handler = new Plant_handler(plant, _weather_handler, offline_game_seconds);

            // Do NOT recreate a Time_handler or replay the offline time again here.
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState currState = Keyboard.GetState();

            if (currState.IsKeyDown(Keys.Escape))
            {
                Exit();
                return;
            }

            // update time once per frame
            _time_handler?.update(gameTime);

            // time since last Update as float (seconds)
            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _plant_handler?.update_plant_info(deltaSeconds * 120f);

            if (currState.IsKeyDown(Keys.W))
                _plant_handler?.water_plant();

            if (currState.IsKeyDown(Keys.F))
                _plant_handler?.fertilize_plant();

            if (currState.IsKeyDown(Keys.P) && _prevKeyState.IsKeyUp(Keys.P))
                _soundHandler?.play_water_sound(Content);

            _prevKeyState = currState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Draw current in-game clock
            _spriteBatch.DrawString(_font, _time_handler?.to_clock_string() ?? "00:00", new Vector2(100, 100), Color.White);
            _weather_handler.draw(_spriteBatch, _font, new Vector2(100,200));
            _plant_handler.draw_plant_info(_spriteBatch, _font);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void on_exiting(object sender, EventArgs e)
        {
            // save plant if needed
            _data_handler?.save_plant_data(_plant_handler?.get_plant());

            // Persist time state via Data_handler (now includes the in-game Time_of_day seconds)
            if (_time_handler != null && _data_handler != null)
            {
                var state = _time_handler.get_save_state();
                _data_handler.save_time_state(state.LastSavedUtcTicks, state.DayCount, state.TimeOfDaySeconds);
            }

            _weather_handler?.Dispose();
        }
    }
}
