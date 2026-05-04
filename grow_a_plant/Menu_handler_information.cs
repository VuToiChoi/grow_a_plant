using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Menu_handler_information
    {
        public Menu_command_package Selected_button { get; private set; }

        public bool Button_is_pressed { get; private set; }

        public Menu_handler_information(Menu_command_package selected_button, bool button_is_pressed)
        {
            Selected_button = selected_button;
            Button_is_pressed = button_is_pressed;
        }
    }
}
