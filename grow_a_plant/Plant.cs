using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    internal class Plant
    {
        // humidity, fertilizer, image, growth stage
        public float Water_level { get; private set; }
        public float Fertilize_level { get; private set; }
        public float Current_growth_stage { get; private set; }

        public Plant(float water_level, float fertilize_level, float growth_stage) 
        {
            Water_level = water_level;
            Fertilize_level = fertilize_level;
            Current_growth_stage = growth_stage;
        }

        public void update_plant(float water_level, float fertilize_level, float growth_stage)
        {
            Water_level = water_level;
            Fertilize_level = fertilize_level;
            Current_growth_stage = growth_stage;
        }
    }
}
