using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    internal class Plant_handler
    {
        // fertlize, water, update plant

        private Plant _plant;

        public Plant_handler(Plant plant/*saved_info, time, wheather*/)
        {
            _plant = plant;
            //humidity 2m
            //time
            //Cloud cover
        }

        private int water_plant()
        {
            return 10;
        }

        private int fertilize_plant()
        {
            return 10;
        }

        private void update_plant_growth_stage()
        {
            // logic to update growth stage
        }

        public void update_plant_info()
        {
            int water_loss = 5; // example value
            int fertilizer_loss = 3; // example value

            _plant.update_plant(_plant.Humidity - water_loss, _plant.Fertilizer - fertilizer_loss, _plant.Current_growth_stage);
        }

    }
}
