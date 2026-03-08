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

        public enum action
        {
            return_to_game,
            save_game,
            load_game,
            exit_game,
            water,
            open_log,
            fertelize,
            open_settings,
            none
        }

        private Dictionary<string, action> _menu_string_to_action_dictionary = new()
        {
            { "Return to Game", action.return_to_game },
            { "Save Game", action.save_game },
            { "Load Game", action.load_game },
            { "Exit Game", action.exit_game },
            { "Water", action.water },
            { "Log", action.open_log },
            { "Fertelize", action.fertelize },
            { "Settings", action.open_settings }
        };

        public Menu_handler(Menu menu_to_use_currently)
        {
            _current_menu = menu_to_use_currently;
            _pressed_keys_handler = new Pressed_keys_handler();
        }

        public action update()
        {
            _pressed_keys_handler.update();

            Input_handler.key first_pressed_key = _pressed_keys_handler.get_first_pressed_key();

            if (first_pressed_key == Input_handler.key.z) // option is selsected
            {
                return _menu_string_to_action_dictionary[_current_menu.get_selected_option()];
            }
            else
            {
                update_menu(first_pressed_key); // update what option in the menu is selected
                return action.none;
            }
        }

        private void update_menu(Input_handler.key pressed_key)
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
