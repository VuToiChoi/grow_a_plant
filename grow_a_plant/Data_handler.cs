using System;
using System.IO;
using System.Text.Json;

namespace grow_a_plant
{
    internal class Data_handler
    {
        private readonly string _folder;
        private readonly string _plantPath;
        private readonly string _timePath;

        public Data_handler()
        {
            _folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "grow_a_plant");
            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
            _plantPath = Path.Combine(_folder, "plant_data.txt");
            _timePath = Path.Combine(_folder, "time_state.json");
        }

        // Robust plant persistence
        public void save_plant_data(Plant plant)
        {
            try
            {
                var dir = Path.GetDirectoryName(_plantPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.WriteAllText(_plantPath, $"{plant.Water_level};{plant.Fertilize_level};{plant.Current_growth_stage}");
            }
            catch (Exception ex)
            {
            }
        }

        public Plant load_plant_data()
        {
            try
            {
                if (!File.Exists(_plantPath)) return new Plant(0, 0, 0);
                var text = File.ReadAllText(_plantPath);
                if (string.IsNullOrWhiteSpace(text)) return new Plant(0, 0, 0);
                var firstLine = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var parts = firstLine.Split(';');
                if (parts.Length < 3) return new Plant(0, 0, 0);

                float humidity = float.TryParse(parts[0].Trim(), out var h) ? h : 0;
                float fertilizer = float.TryParse(parts[1].Trim(), out var f) ? f : 0;
                float growthStage = float.TryParse(parts[2].Trim(), out var g) ? g : 0;
                return new Plant(humidity, fertilizer, growthStage);
            }
            catch (Exception ex)
            {
                return new Plant(0, 0, 0);
            }
        }

        // Time persistence for Time_handler
        private class TimeState
        {
            public long LastSavedUtcTicks { get; set; }
            public long DayCount { get; set; }
            public double TimeOfDaySeconds { get; set; } // save in-game time-of-day in seconds
        }

        // Save last saved UTC ticks, day count, and the current in-game time-of-day seconds
        public void save_time_state(long lastSavedUtcTicks, long dayCount, double timeOfDaySeconds)
        {
            try
            {
                var state = new TimeState { LastSavedUtcTicks = lastSavedUtcTicks, DayCount = dayCount, TimeOfDaySeconds = timeOfDaySeconds };
                var json = JsonSerializer.Serialize(state);
                File.WriteAllText(_timePath, json);
            }
            catch (Exception ex)
            {
            }
        }

        // Returns null if no saved state
        public (long LastSavedUtcTicks, long DayCount, double TimeOfDaySeconds)? load_time_state()
        {
            try
            {
                if (!File.Exists(_timePath)) return null;
                var json = File.ReadAllText(_timePath);
                var state = JsonSerializer.Deserialize<TimeState>(json);
                if (state == null) return null;
                return (state.LastSavedUtcTicks, state.DayCount, state.TimeOfDaySeconds);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
