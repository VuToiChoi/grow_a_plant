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
        public int Humidity { get; private set; }
        public int Fertilizer { get; private set; }
        public int Current_growth_stage { get; private set; }

        public Plant(int humidity, int fertilizer, int growth_stage) 
        {
            Humidity = humidity;
            Fertilizer = fertilizer;
            Current_growth_stage = growth_stage;
        }

        public void update_plant(int humidity, int fertilizer, int growth_stage)
        {
            Humidity = humidity;
            Fertilizer = fertilizer;
            Current_growth_stage = growth_stage;
        }
    }
}
