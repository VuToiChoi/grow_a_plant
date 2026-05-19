using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;

namespace grow_a_plant
{
    internal class Plant_handler
    {
        private Plant _plant;
        private Weather_handler _weather_handler;
        private float _delta_time;

        public Plant_handler(Plant plant, Weather_handler weather_handler, float delta_time)
        {
            _plant = plant;
            _weather_handler = weather_handler;
            _delta_time = delta_time;

            if (_delta_time == null)
            {
                _delta_time = 0;
            }
            apply_offline_time(delta_time);
        }

        //Adds 0.1 to the water level, but clamps it to a maximum of 1.0 to prevent overflow.
        public void water_plant()
        {
        _plant.update_plant(Math.Min(1f, _plant.Water_level + 0.1f), _plant.Fertilize_level, _plant.Current_growth_stage);
        }

        //Adds 0.1 to the fertilize level, but clamps it to a maximum of 1.0 to prevent overflow.
        public void fertilize_plant()
        {
            _plant.update_plant(_plant.Water_level, Math.Min(1f, _plant.Fertilize_level + 0.1f), _plant.Current_growth_stage);
        }

        // Returns the cloud cover from the latest weather data, or a default value of 0.5 if the weather handler is not available or has no data.
        private float get_cloud_cover()
        {
            return _weather_handler?.get_latest_weather().cloud_cover ?? 0.5f;
        }

        // Returns the humidity at 2 meters from the latest weather data, or a default value of 0.5 if the weather handler is not available or has no data.
        private float get_humidity_2m()
        {
            return _weather_handler?.get_latest_weather().humidity_2m ?? 0.5f;
        }

        // Returns the temperature from the latest weather data, or a default value of 12 degrees Celsius if the weather handler is not available or has no data.
        private float get_temperature()
        {
            return _weather_handler?.get_latest_weather().temperature ?? 12f;
        }


        /*The delta_time parameter allows you to specify the time interval for which to calculate the loss, so you can use it for per-second updates or for larger time steps.*/

        // Calculates the water loss per second based on the given formula and the current weather conditions.
        private float calculate_water_loss_per_sec(float delta_time)
        {
            // water loss per sec: (sekunder*(2/(1+3*e^-0,09155102405568*temp))*(1.5-0.01*cloud_cover))/(0.01*humidity+0.5) * (0.1/(24*3600))
            return (delta_time * (2 / (1 + 3 * (float)Math.Exp(-0.09155102405568f * get_temperature()))) * (1.5f - 0.01f * get_cloud_cover())) / (0.01f * get_humidity_2m() + 0.5f) * (0.1f / (24 * 3600));
        }

        // Calculates the fertilizer loss per second based on the average growth per second and a fixed factor of 0.1.
        private float calculate_fertilize_loss_per_sec(float delta_time)
        {
            // fertelize loss per sec: average growth * 0.1
            return calculate_avrage_growth_per_sec(delta_time) * 0.1f;
        }

        // Calculates the average growth per second based on the given formula and the current water and fertilizer levels, as well as the cloud cover.
        private float calculate_avrage_growth_per_sec(float delta_time)
        {
            // Avrage growth per sec= (((0.5sin(2pi(water-1/4))+1) + 0.5sin(2pi(fertlize-1/4))+1)/2)*(1.5-0.01*cloud_cover) * second * (1/24*3600)
            // Fix integer-division bugs and use floating factors.
            if (_plant.Water_level == 0 && _plant.Fertilize_level == 0)
            {
                return 0f;
            }
            float waterPhase = _plant.Water_level - 0.25f;
            float fertPhase = _plant.Fertilize_level - 0.25f;
            float dayFactor = 1f / (24f * 3600f);

            float waterSin = 0.5f * (float)Math.Sin(2 * Math.PI * waterPhase) + 1f;
            float fertSin = 0.5f * (float)Math.Sin(2 * Math.PI * fertPhase) + 1f;
            float avgSin = (waterSin + fertSin) / 2f;
            
            return avgSin * (1.5f - 0.01f * get_cloud_cover()) * delta_time * dayFactor;
        }

        // Calculates the growth stage increase per second based on the average growth per second and a quadratic formula.
        private float calculate_growth_stage_per_sec(float delta_time)
        {
            // Convert growth to growth stage per sec: 6.25*growth^2+0.25*growth
            float avg = calculate_avrage_growth_per_sec(delta_time);
            return 6.25f * (float)Math.Pow(avg, 2) + 0.25f * avg;
        }

        // Updates the plant's water level, fertilizer level, and growth stage based on the calculated losses and growth for the given time interval.
        public void update_plant_info(float delta_time)
        {
            float water_loss = calculate_water_loss_per_sec(delta_time);
            float fertilizer_loss = calculate_fertilize_loss_per_sec(delta_time);

            // Clamp levels to prevent negatives and treat growth as an increment
            float newWater = Math.Max(0f, _plant.Water_level - water_loss);
            float newFertilize = Math.Max(0f, _plant.Fertilize_level - fertilizer_loss);

            float growthDelta = calculate_growth_stage_per_sec(delta_time);
            float newGrowth = Math.Max(0f, _plant.Current_growth_stage + growthDelta);

            _plant.update_plant(newWater, newFertilize, newGrowth);
        }

        // Applies the offline time by calculating the total game-seconds that have passed during the offline duration and updating the plant information accordingly.
        // The maxDaysClamp parameter is used to limit the maximum offline duration to prevent excessive jumps in plant growth or decay.
        public void apply_offline_time(float offline_seconds, int max_days_clamp = 30)
        {
            // clamp to avoid huge jumps (optional)
            var max_seconds = max_days_clamp * 24 * 3600;
            var seconds = (float)Math.Min(offline_seconds, max_seconds);
            if (seconds <= 0f) return;

            // Reuse existing update logic which accepts seconds as delta_time
            update_plant_info(seconds);
        }

        public Plant get_plant()
        { 
            return _plant;
        }

        // Draws the plant information (water level, fertilizer level, growth stage) on the screen using the provided SpriteBatch and SpriteFont.
        public void draw_plant_info(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Graphics.SpriteFont font)
        {
            spriteBatch.DrawString(font, $"Water Level: {_plant.Water_level.ToString()}", new Vector2(500, 0), Color.White);
            spriteBatch.DrawString(font, $"Fertilize Level: {_plant.Fertilize_level.ToString()}", new Vector2(500, 100), Color.White);
            spriteBatch.DrawString(font, $"Growth Stage: {_plant.Current_growth_stage.ToString()}", new Vector2(500, 200), Color.White);
        }
    }
}
