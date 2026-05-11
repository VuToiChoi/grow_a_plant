using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;


namespace grow_a_plant
{
    internal class Weather_handler : IDisposable
    {
        private readonly HttpClient _httpClient = new();
        private Timer? _timer;
        private readonly string _latitude = "56.0467";
        private readonly string _longitude = "12.6944"; // Example: Helsinborg, Sweden
        private readonly object _lock = new();

        WeatherData? _weather_data;
        public bool Is_valid { get; private set; }

        public Weather_handler() {

        }

        // Start periodic automatic updates. Call from Game1.LoadContent or Initialize.
        public void start_periodic_updates(TimeSpan interval)
        {
            // Run immediately, then every 'interval'
            _timer = new Timer(_ => _ = fetch_and_set_weather_async(), null, TimeSpan.Zero, interval);
        }

        private void stop_periodic_updates()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            _timer?.Dispose();
            _timer = null;
        }

        private async Task fetch_and_set_weather_async()
        {
            //https://api.open-meteo.com/v1/forecast?latitude=56.0467&longitude=12.6944&current=temperature_2m,rain,snowfall,relative_humidity_2m,cloud_cover&timezone=Europe%2FBerlin&forecast_days=1
            var api_url = $"https://api.open-meteo.com/v1/forecast?" +
            $"latitude={_latitude}&" +
            $"longitude={_longitude}&" +
            $"current=temperature_2m,rain,snowfall,relative_humidity_2m,cloud_cover&timezone=Europe%2FBerlin&forecast_days=1";

            var response = await _httpClient.GetAsync(api_url);
            try
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                set_weather_data(JsonConvert.DeserializeObject<WeatherData>(content));
            }
            catch (Exception)
            {
                // Log or ignore transient network errors; do not throw from timer callback
            }
        }

        // existing code adapted to prefer calling from FetchAndSetWeatherAsync
        private void set_weather_data(WeatherData weather_data)
        {
            lock (_lock)
            {
                Is_valid = false;
                if (weather_data != null &&
                    weather_data.Units?.Temperature != null &&
                    weather_data.Units?.Rain != null &&
                    weather_data.Units?.Snowfall != null &&
                    weather_data.Units?.Relative_humidity != null &&
                    weather_data.Units?.Cloud_cover != null &&
                    weather_data.Data?.Time?.Length > 0 &&
                    weather_data.Data?.Temperature?.Length > 0)
                {
                    _weather_data = weather_data;
                    Is_valid = true;
                }
                else
                {
                    throw new Exception("Incorrect indata");
                }
            }
        }
        public void draw(SpriteBatch spriteBatch, SpriteFont font, Vector2 position)
        {
            if (spriteBatch == null || font == null) return;

            string text;
            lock (_lock)
            {
                if (!Is_valid || _weather_data == null)
                {
                    text = "Weather: N/A";
                }
                else
                {
                    var u = _weather_data.Units!;
                    var d = _weather_data.Data!;
                    var temp = d.Temperature ?? "N/A";
                    var rain = d.Rain ?? "N/A";
                    var humidity = d.Relative_humidity ?? "N/A";
                    var cloud = d.Cloud_cover ?? "N/A";
                    text = $"Temp: {temp}\nRain: {rain} {u.Rain}\nHumidity: {humidity}\nCloud: {cloud}";
                }
            }

            var lines = text.Split('\n');
            var pos = position;
            foreach (var line in lines)
            {
                spriteBatch.DrawString(font, line, pos, Color.White);
                pos.Y += font.MeasureString(line).Y + 2;
            }
        }

        public void Dispose()
        {
            stop_periodic_updates();
            _httpClient.Dispose();
        }

        // Public getters to expose current weather values (thread-safe snapshot)
        public (float temperature, float humidity_2m, float cloud_cover) get_latest_weather()
        {
            lock (_lock)
            {
                if (!Is_valid || _weather_data == null) return (0f, 0f, 0f);
                // convert parsed strings to floats; fall back to 0 on parse failure
                float.TryParse(_weather_data.Data!.Temperature ?? "0", out var temp);
                float.TryParse(_weather_data.Data!.Relative_humidity ?? "0", out var hum);
                float.TryParse(_weather_data.Data!.Cloud_cover ?? "0", out var cloud);
                Is_valid = true;
                return (temp, hum, cloud);
            }
        }

        public class WeatherData
        {
            [JsonProperty("current_units")]
            public Units? Units { get; set; }

            [JsonProperty("current")]
            public Data? Data { get; set; }
        }

        public class Units
        {
            [JsonProperty("temperature_2m")]
            public string? Temperature { get; set; }

            [JsonProperty("rain")]
            public string? Rain { get; set; }

            [JsonProperty("snowfall")]
            public string? Snowfall { get; set; }

            [JsonProperty("relative_humidity_2m")]
            public string? Relative_humidity { get; set; }

            [JsonProperty("cloud_cover")]
            public string? Cloud_cover { get; set; }
        }

        public class Data
        {
            [JsonProperty("time")]
            public string? Time { get; set; }

            [JsonProperty("temperature_2m")]
            public string? Temperature { get; set; }

            [JsonProperty("rain")]
            public string? Rain { get; set; }

            [JsonProperty("snowfall")]
            public string? Snowfall { get; set; }

            [JsonProperty("relative_humidity_2m")]
            public string? Relative_humidity { get; set; }

            [JsonProperty("cloud_cover")]
            public string? Cloud_cover { get; set; }
        }
    }
}
