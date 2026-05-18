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
            // Use LocalApplicationData for better cross-platform support and to avoid permission issues
            _folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "grow_a_plant");
            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
            _plantPath = Path.Combine(_folder, "plant_data.txt");
            _timePath = Path.Combine(_folder, "time_state.json");
        }

        // Save plant data in a simple text format: "water_level;fertilize_level;current_growth_stage"
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

        // Load plant data, returning a Plant object. If loading fails, return a default Plant with 0 values.
        public Plant load_plant_data()
        {
            try
            {
                if (!File.Exists(_plantPath)) return new Plant(0, 0, 0);
                var text = File.ReadAllText(_plantPath);
                if (string.IsNullOrWhiteSpace(text)) return new Plant(0, 0, 0);
                var first_line = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var parts = first_line.Split(';');
                if (parts.Length < 3) return new Plant(0, 0, 0);

                float humidity = float.TryParse(parts[0].Trim(), out var h) ? h : 0;
                float fertilizer = float.TryParse(parts[1].Trim(), out var f) ? f : 0;
                float growth_stage = float.TryParse(parts[2].Trim(), out var g) ? g : 0;
                return new Plant(humidity, fertilizer, growth_stage);
            }
            catch (Exception ex)
            {
                return new Plant(0, 0, 0);
            }
        }

        // Class to represent the time state for JSON serialization
        private class TimeState
        {
            public long last_saved_utc_ticks { get; set; }
            public long day_count { get; set; }
            public double time_of_day_seconds { get; set; } // save in-game time-of-day in seconds
        }

        // Save last saved UTC ticks, day count, and the current in-game time-of-day seconds
        public void save_time_state(long last_saved_utc_ticks, long day_count, double time_of_day_seconds)
        {
            try
            {
                var state = new TimeState { last_saved_utc_ticks = last_saved_utc_ticks, day_count = day_count, time_of_day_seconds = time_of_day_seconds };
                var json = JsonSerializer.Serialize(state);
                File.WriteAllText(_timePath, json);
            }
            catch (Exception ex)
            {
            }
        }

        // Load time state, returning a tuple of (last saved UTC ticks, day count, in-game time-of-day seconds). If loading fails, return null.
        public (long last_saved_utc_ticks, long day_count, double time_of_day_seconds)? load_time_state()
        {
            try
            {
                if (!File.Exists(_timePath)) return null;
                var json = File.ReadAllText(_timePath);
                var state = JsonSerializer.Deserialize<TimeState>(json);
                if (state == null) return null;
                return (state.last_saved_utc_ticks, state.day_count, state.time_of_day_seconds);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
