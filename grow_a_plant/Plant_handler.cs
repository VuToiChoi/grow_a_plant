using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public float water_plant()
        {
            return 0.1f;
        }

        public float fertilize_plant()
        {
            return 0.1f;
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

        private float calculate_water_loss_per_sec()
        {
            // water loss per sec: (sekunder*(2/(1+3*e^-0,09155102405568*temp))*(1.5-0.01*cloud_cover))/(0.01*humidity+0.5) * (0.1/(24*3600))
            return (_delta_time * (2 / (1 + 3 * (float)Math.Exp(-0.09155102405568f * get_temperature()))) * (1.5f - 0.01f * get_cloud_cover())) / (0.01f * get_humidity_2m() + 0.5f) * (0.1f / (24 * 3600));
        }
        private float calculate_fertilize_loss_per_sec()
        {
            // fertelize loss per sec: average growth * 0.1
            return calculate_avrage_growth_per_sec() * 0.1f;
        }

        private float calculate_avrage_growth_per_sec()
        {
            // Avrage growth per sec= (((0.5sin(2pi(water-1/4))+1) + 0.5sin(2pi(fertlize-1/4))+1)/2)*(1.5-0.01*cloud_cover) * second * (1/24*3600)
            return (((0.5f * (float)Math.Sin(2 * Math.PI * (_plant.Water_level - (1 / 4))) + 1) + 0.5f * (float)Math.Sin(2 * Math.PI * (_plant.Fertilize_level - (1 / 4))) + 1) / 2) * (1.5f - 0.01f * get_cloud_cover()) * _delta_time * (1 / 24 * 3600);
        }

        private float calculate_growth_stage_per_sec()
        {
            // Convert growth to growth stage per sec: 6.25*growth^2+0.25*growth
            return 6.25f * (float)Math.Pow(calculate_avrage_growth_per_sec(), 2) + 0.25f * calculate_avrage_growth_per_sec();
        }

        public void update_plant_info()
        {
            float water_loss = calculate_water_loss_per_sec();
            float fertilizer_loss = calculate_fertilize_loss_per_sec();


            _plant.update_plant(_plant.Water_level - water_loss, _plant.Fertilize_level - fertilizer_loss, calculate_growth_stage_per_sec());
        }

    }
}
