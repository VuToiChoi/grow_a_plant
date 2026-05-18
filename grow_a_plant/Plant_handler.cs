using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace grow_a_plant
{
    internal class Plant_handler
    {
        private Plant _plant;
        private Weather_handler _weather_handler;
        private float _delta_time;

        public Plant_handler(Plant plant, Weather_handler weather_handler, float delta_time = 0f)
        {
            _plant = plant;
            _weather_handler = weather_handler;
            _delta_time = delta_time;
        }

        public void water_plant()
        {
            _plant.update_plant(Math.Min(1f, _plant.Water_level + 0.1f), _plant.Fertilize_level, _plant.Current_growth_stage);
        }

        public void fertilize_plant()
        {
            _plant.update_plant(_plant.Water_level, Math.Min(1f, _plant.Fertilize_level + 0.1f), _plant.Current_growth_stage);
        }

        private float get_cloud_cover()
        {
            return _weather_handler?.get_latest_weather().cloud_cover ?? 0.5f;
        }

        private float get_humidity_2m()
        {
            return _weather_handler?.get_latest_weather().humidity_2m ?? 0.5f;
        }

        private float get_temperature()
        {
            return _weather_handler?.get_latest_weather().temperature ?? 12f;
        }

        private float calculate_water_loss_per_sec(float delta_time)
        {
            // water loss per sec: (sekunder*(2/(1+3*e^-0,09155102405568*temp))*(1.5-0.01*cloud_cover))/(0.01*humidity+0.5) * (0.1/(24*3600))
            return (delta_time * (2 / (1 + 3 * (float)Math.Exp(-0.09155102405568f * get_temperature()))) * (1.5f - 0.01f * get_cloud_cover())) / (0.01f * get_humidity_2m() + 0.5f) * (0.1f / (24 * 3600));
        }

        private float calculate_fertilize_loss_per_sec(float delta_time)
        {
            // fertelize loss per sec: average growth * 0.1
            return calculate_avrage_growth_per_sec(delta_time) * 0.1f;
        }

        private float calculate_avrage_growth_per_sec(float delta_time)
        {
            // Avrage growth per sec= (((0.5sin(2pi(water-1/4))+1) + 0.5sin(2pi(fertlize-1/4))+1)/2)*(1.5-0.01*cloud_cover) * second * (1/24*3600)
            // Fix integer-division bugs and use floating factors.
            if (_plant.Water_level == 0 && _plant.Fertilize_level == 0)
            {
                return 0f;
            }
            float waterPhase = _plant.Water_level - 0.25f;           // use 0.25f instead of (1/4)
            float fertPhase = _plant.Fertilize_level - 0.25f;
            float dayFactor = 1f / (24f * 3600f);                    // 1/(24*3600) as float

            float waterSin = 0.5f * (float)Math.Sin(2 * Math.PI * waterPhase) + 1f;
            float fertSin = 0.5f * (float)Math.Sin(2 * Math.PI * fertPhase) + 1f;
            float avgSin = (waterSin + fertSin) / 2f;
            
            return avgSin * (1.5f - 0.01f * get_cloud_cover()) * delta_time * dayFactor;
        }

        private float calculate_growth_stage_per_sec(float delta_time)
        {
            // Convert growth to growth stage per sec: 6.25*growth^2+0.25*growth
            float avg = calculate_avrage_growth_per_sec(delta_time);
            return 6.25f * (float)Math.Pow(avg, 2) + 0.25f * avg;
        }

        // new method: specify delta_time explicitly (use 1.0f for per-second updates)
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

        public Plant get_plant()
        { 
            return _plant;
        }

        public void draw_plant_info(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.DrawString(font, $"Water Level: {_plant.Water_level.ToString()}", new Vector2(500, 0), Color.White);
            spriteBatch.DrawString(font, $"Fertilize Level: {_plant.Fertilize_level.ToString()}", new Vector2(500, 100), Color.White);
            spriteBatch.DrawString(font, $"Growth Stage: {_plant.Current_growth_stage.ToString()}", new Vector2(500, 200), Color.White);
        }
    }
}
