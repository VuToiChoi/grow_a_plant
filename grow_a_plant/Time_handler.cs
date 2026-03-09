using Microsoft.Xna.Framework;
using System;

namespace grow_a_plant
{
    internal class Time_handler
    {
        // 24 in-game hours == 12 real minutes -> multiplier = 86400 / 720 = 120 game-seconds per real-second
        private const double _game_seconds_per_real_second = 120.0;
        private const double _max_real_seconds_per_update = 2;

        public TimeSpan TimeOfDay { get; private set; } = TimeSpan.Zero;
        public long DayCount { get; private set; } = 0;
        public bool IsPaused { get; set; } = false;

        // Accept optional saved state (last saved UTC ticks and saved day count)
        public Time_handler((long LastSavedUtcTicks, long DayCount)? savedState = null)
        {
            initialize_from_saved_state(savedState);
        }

        private void initialize_from_saved_state((long LastSavedUtcTicks, long DayCount)? savedState)
        {
            // Start with local real time display
            double initialSeconds = DateTime.Now.TimeOfDay.TotalSeconds;

            if (savedState.HasValue)
            {
                var lastSavedUtc = new DateTime(savedState.Value.LastSavedUtcTicks, DateTimeKind.Utc);
                double offlineRealSeconds = (DateTime.UtcNow - lastSavedUtc).TotalSeconds;
                if (offlineRealSeconds < 0) offlineRealSeconds = 0;

                double offlineGameSeconds = offlineRealSeconds * _game_seconds_per_real_second;
                initialSeconds += offlineGameSeconds;

                DayCount = savedState.Value.DayCount;

                if (initialSeconds >= 86400.0)
                {
                    long daysPassed = (long)(initialSeconds / 86400.0);
                    DayCount += daysPassed;
                    initialSeconds -= daysPassed * 86400.0;
                }
            }

            TimeOfDay = TimeSpan.FromSeconds(initialSeconds % 86400.0);
        }

        // Call from Game1.Update(gameTime)
        public void update(GameTime gameTime)
        {
            if (IsPaused) return;

            double realSeconds = gameTime.ElapsedGameTime.TotalSeconds;
            if (realSeconds <= 0) return;

            realSeconds = Math.Min(realSeconds, _max_real_seconds_per_update);

            double advanceGameSeconds = realSeconds * _game_seconds_per_real_second;
            double newTotalSeconds = TimeOfDay.TotalSeconds + advanceGameSeconds;

            if (newTotalSeconds >= 86400.0)
            {
                long daysPassed = (long)(newTotalSeconds / 86400.0);
                DayCount += daysPassed;
                newTotalSeconds -= daysPassed * 86400.0;
            }

            TimeOfDay = TimeSpan.FromSeconds(newTotalSeconds);
        }

        // Provide a tuple for persistence
        public (long LastSavedUtcTicks, long DayCount) get_save_state()
        {
            return (DateTime.UtcNow.Ticks, DayCount);
        }

        public float get_day_progress_normalized() => (float)(TimeOfDay.TotalSeconds / 86400.0);
        public bool is_daytime(int dawnHour = 6, int duskHour = 18) =>
            TimeOfDay.Hours >= dawnHour && TimeOfDay.Hours < duskHour;
        public string to_clock_string() => TimeOfDay.ToString(@"hh\:mm\:ss");
    }
}
