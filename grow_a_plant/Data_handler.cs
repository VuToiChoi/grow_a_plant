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
            Directory.CreateDirectory(_folder);
            _plantPath = Path.Combine(_folder, "plant_data.txt");
            _timePath = Path.Combine(_folder, "time_state.json");
        }

        // Robust plant persistence
        public void save_plant_data(Plant plant)
        {
            try
            {
                File.WriteAllText(_plantPath, $"{plant.Water_level};{plant.Fertilize_level};{plant.Current_growth_stage}");
            }
            catch
            {
                // best-effort
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

                int humidity = int.TryParse(parts[0], out var h) ? h : 0;
                int fertilizer = int.TryParse(parts[1], out var f) ? f : 0;
                int growthStage = int.TryParse(parts[2], out var g) ? g : 0;
                return new Plant(humidity, fertilizer, growthStage);
            }
            catch
            {
                return new Plant(0, 0, 0);
            }
        }

        // Time persistence for Time_handler
        private class TimeState
        {
            public long LastSavedUtcTicks { get; set; }
            public long DayCount { get; set; }
        }

        public void save_time_state(long lastSavedUtcTicks, long dayCount)
        {
            try
            {
                var state = new TimeState { LastSavedUtcTicks = lastSavedUtcTicks, DayCount = dayCount };
                var json = JsonSerializer.Serialize(state);
                File.WriteAllText(_timePath, json);
            }
            catch
            {
                // best-effort
            }
        }

        // Returns null if no saved state
        public (long LastSavedUtcTicks, long DayCount)? load_time_state()
        {
            try
            {
                if (!File.Exists(_timePath)) return null;
                var json = File.ReadAllText(_timePath);
                var state = JsonSerializer.Deserialize<TimeState>(json);
                if (state == null) return null;
                return (state.LastSavedUtcTicks, state.DayCount);
            }
            catch
            {
                return null;
            }
        }
    }
}
