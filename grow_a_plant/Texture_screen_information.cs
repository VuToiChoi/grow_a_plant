using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Texture_screen_information
    {
        public Button_command_package.command_type Selected_button { get; set; }

        public bool Button_is_pressed { get; private set; }

        public float Water_level { get; private set; }

        public float Fertilize_level { get; private set; }

        public float Growth_stage { get; private set; }
        
        public Texture_screen_information(Button_command_package.command_type selected_button, bool button_is_pressed, float water_level, float fertilize_level, float growth_stage)
        {
            Selected_button = selected_button;
            Button_is_pressed = button_is_pressed;
            Water_level = water_level;
            Fertilize_level = fertilize_level;
            Growth_stage = growth_stage;
        }
    }
}
