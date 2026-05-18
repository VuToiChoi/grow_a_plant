using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Menu_handler
    {
        private Menu _current_menu;
        private Pressed_keys_handler _pressed_keys_handler;

        public Menu_handler(Menu menu_to_use_currently)
        {
            _current_menu = menu_to_use_currently;
            _pressed_keys_handler = new Pressed_keys_handler();
        }

        public Menu_handler_information update()
        {
            // update pressed keys and get the first pressed key
            _pressed_keys_handler.update();
            Input_handler.key first_pressed_key = _pressed_keys_handler.get_first_pressed_key();

            if (first_pressed_key == Input_handler.key.z) // when z is pressed selected option should be conducted
            {
                // returns the selected option and that the button is pressed
                Menu_handler_information menu_handler_information = new Menu_handler_information(_current_menu.get_selected_option(), true);
                return menu_handler_information;
            }
            else
            {
                // update what option in the menu is selected
                step_through_menu(first_pressed_key);

                // returns the selected option and that the button is not pressed
                Menu_handler_information menu_handler_information = new Menu_handler_information(_current_menu.get_selected_option(), false);
                return menu_handler_information;
            }
        }

        private void step_through_menu(Input_handler.key pressed_key)
        {
            if (pressed_key == Input_handler.key.up || pressed_key == Input_handler.key.w)
            {
                _current_menu.step_up();
            }
            else if (pressed_key == Input_handler.key.down || pressed_key == Input_handler.key.s)
            {
                _current_menu.step_down();
            }
            else if (pressed_key == Input_handler.key.right || pressed_key == Input_handler.key.d)
            {
                _current_menu.step_right();
            }
            else if (pressed_key == Input_handler.key.left || pressed_key == Input_handler.key.a)
            {
                _current_menu.step_left();
            }
        }

        public void change_menu(Menu menu)
        {
            _current_menu = menu;
        }
    }
}
