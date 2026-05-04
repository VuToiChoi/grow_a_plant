using Microsoft.Xna.Framework;
using System;

namespace grow_a_plant
{
    internal class Time_handler
    {
        // 24 in-game hours == 12 real minutes -> multiplier = 86400 / 720 = 120 game-seconds per real-second
        private const double _game_seconds_per_real_second = 120.0;
        private const double _max_real_seconds_per_update = 2;

        public TimeSpan Time_of_day { get; private set; } = TimeSpan.Zero;
        public long Day_count { get; private set; } = 0;
        public bool Is_paused { get; set; } = false;

        // Accept optional saved state (last saved UTC ticks and saved day count)
        public Time_handler((long last_saved_utc_ticks, long day_count)? saved_state = null)
        {
            initialize_from_saved_state(saved_state);
        }

        private void initialize_from_saved_state((long last_saved_utc_ticks, long day_count)? saved_state)
        {
            // Start with local real time display
            double initial_seconds = DateTime.Now.TimeOfDay.TotalSeconds;

            if (saved_state.HasValue)
            {
                var last_saved_utc = new DateTime(saved_state.Value.last_saved_utc_ticks, DateTimeKind.Utc);
                double offline_real_seconds = (DateTime.UtcNow - last_saved_utc).TotalSeconds;
                if (offline_real_seconds < 0) offline_real_seconds = 0;

                double offline_game_seconds = offline_real_seconds * _game_seconds_per_real_second;
                initial_seconds += offline_game_seconds;

                Day_count = saved_state.Value.day_count;

                if (initial_seconds >= 86400.0)
                {
                    long days_passed = (long)(initial_seconds / 86400.0);
                    Day_count += days_passed;
                    initial_seconds -= days_passed * 86400.0;
                }
            }

            Time_of_day = TimeSpan.FromSeconds(initial_seconds % 86400.0);
        }

        // Call from Game1.Update(gameTime)
        public void update(GameTime gameTime)
        {
            if (Is_paused) return;

            double real_seconds = gameTime.ElapsedGameTime.TotalSeconds;
            if (real_seconds <= 0) return;

            real_seconds = Math.Min(real_seconds, _max_real_seconds_per_update);

            double advance_game_seconds = real_seconds * _game_seconds_per_real_second;
            double new_total_seconds = Time_of_day.TotalSeconds + advance_game_seconds;

            if (new_total_seconds >= 86400.0)
            {
                long days_passed = (long)(new_total_seconds / 86400.0);
                Day_count += days_passed;
                new_total_seconds -= days_passed * 86400.0;
            }

            Time_of_day = TimeSpan.FromSeconds(new_total_seconds);
        }

        // Provide a tuple for persistence
        public (long LastSavedUtcTicks, long DayCount) get_save_state()
        {
            return (DateTime.UtcNow.Ticks, Day_count);
        }

        // Return the real seconds elapsed since the supplied UTC ticks as a float (clamped to >= 0)
        public float get_offline_real_seconds(long last_saved_utc_ticks)
        {
            var last_saved_utc = new DateTime(last_saved_utc_ticks, DateTimeKind.Utc);
            double offline_real_seconds = (DateTime.UtcNow - last_saved_utc).TotalSeconds;
            if (offline_real_seconds < 0) offline_real_seconds = 0;
            return (float)offline_real_seconds;
        }

        // Return the game-seconds (after applying your multiplier) since the supplied UTC ticks as a float
        public float get_offline_game_seconds(long last_saved_utc_ticks)
        {
            float offline_real_seconds = get_offline_real_seconds(last_saved_utc_ticks);
            return offline_real_seconds * (float)_game_seconds_per_real_second;
        }

        public float get_day_progress_normalized() => (float)(Time_of_day.TotalSeconds / 86400.0);
        public bool is_daytime(int dawn_hour = 6, int dusk_hour = 18) =>
            Time_of_day.Hours >= dawn_hour && Time_of_day.Hours < dusk_hour;
        public string to_clock_string() => Time_of_day.ToString(@"hh\:mm\:ss");
    }
}
