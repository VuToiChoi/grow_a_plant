using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace grow_a_plant
{
    internal class Weather_handler : IDisposable
    {
        private readonly HttpClient _httpClient = new();
        private Timer? _timer;
        private readonly string _latitude = "56.0467"; 
        private readonly string _longitude = "12.6944"; // Example: Helsinborg, Sweden

        WeatherData? _weather_data;
        public bool Is_valid { get; private set; }

        public Weather_handler() { }

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
            try
            {
                var api_url = $"https://api.open-meteo.com/v1/forecast?" +
                    $"latitude={_latitude}&" +
                    $"longitude={_longitude}&" +
                    $"current=temperature_2m,rain,snowfall,relative_humidity_2m,cloud_cover&timezone=Europe%2FBerlin&forecast_days=1";

                using var response = await _httpClient.GetAsync(api_url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var data = JsonConvert.DeserializeObject<WeatherData>(content);
                if (data != null)
                {
                    set_weather_data(data);
                }
            }
            catch (Exception)
            {
                // Log or ignore transient network errors; do not throw from timer callback
            }
        }

        // existing code adapted to prefer calling from FetchAndSetWeatherAsync
        private void set_weather_data(WeatherData weather_data)
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

        public void Dispose()
        {
            stop_periodic_updates();
            _httpClient.Dispose();
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
        public long[]? Time { get; set; }

        [JsonProperty("temperature_2m")]
        public string[]? Temperature { get; set; }

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
