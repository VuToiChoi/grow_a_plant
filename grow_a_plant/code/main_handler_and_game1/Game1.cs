using System;
using System;
using System.IO;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace grow_a_plant
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Data_handler _data_handler;
        private Time_handler _time_handler;
        private Weather_handler _weather_handler;
        private Main_handler _main_handler;

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
            long last_saved_ticks = saved_time?.last_saved_utc_ticks ?? DateTime.UtcNow.Ticks;
            float offline_game_seconds = _time_handler.get_offline_game_seconds(last_saved_ticks);


            _main_handler = new Main_handler(plant, _weather_handler, offline_game_seconds, _spriteBatch, _font, GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            // update time once per frame
            _time_handler?.update(gameTime);

            // time since last Update as float (seconds)
            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            bool game_should_not_exit = _main_handler.update(deltaSeconds * (float)Time_handler.game_seconds_per_real_second, _time_handler.Time_of_day, _time_handler.Day_count);
            
            if (!game_should_not_exit)
            {
                Exit();
                return;
            }

            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _main_handler.draw();

            base.Draw(gameTime);
        }

        private void on_exiting(object sender, EventArgs e)
        {
            // save plant if needed
            _data_handler?.save_plant_data(_main_handler.get_plant());

            // Persist time state via Data_handler (now includes the in-game Time_of_day seconds)
            if (_time_handler != null && _data_handler != null)
            {
                var state = _time_handler.get_save_state();
                _data_handler.save_time_state(state.last_saved_utc_ticks, state.day_count, state.time_of_day_seconds);
            }

            _weather_handler?.Dispose();
        }
    }
}
