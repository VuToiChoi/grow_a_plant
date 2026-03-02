using Microsoft.Xna.Framework;
using System;

namespace grow_a_plant
{
    internal class Time_handler
    {
        // 24 in-game hours == 12 real minutes -> multiplier = 86400 / 720 = 120 game-seconds per real-second
        private const double _game_seconds_per_real_second = 120.0;
        private const double MaxRealSecondsPerUpdate = 0.5;

        public TimeSpan TimeOfDay { get; private set; } = TimeSpan.Zero;
        public long DayCount { get; private set; } = 0;
        public bool IsPaused { get; set; } = false;

        // Accept optional saved state (last saved UTC ticks and saved day count)
        public Time_handler((long LastSavedUtcTicks, long DayCount)? savedState = null)
        {
            InitializeFromSavedState(savedState);
        }

        private void InitializeFromSavedState((long LastSavedUtcTicks, long DayCount)? savedState)
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
        public void Update(GameTime gameTime)
        {
            if (IsPaused) return;

            double realSeconds = gameTime.ElapsedGameTime.TotalSeconds;
            if (realSeconds <= 0) return;

            realSeconds = Math.Min(realSeconds, MaxRealSecondsPerUpdate);

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
        public (long LastSavedUtcTicks, long DayCount) GetSaveState()
        {
            return (DateTime.UtcNow.Ticks, DayCount);
        }

        public float GetDayProgressNormalized() => (float)(TimeOfDay.TotalSeconds / 86400.0);
        public bool IsDaytime(int dawnHour = 6, int duskHour = 18) =>
            TimeOfDay.Hours >= dawnHour && TimeOfDay.Hours < duskHour;
        public string ToClockString() => TimeOfDay.ToString(@"hh\:mm\:ss");
    }
}
