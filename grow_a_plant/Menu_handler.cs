using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Menu_handler
    {
        private Input_handler _input_handler = new();

        private Menu _current_menu;

        private List<Input_handler.key> _pressed_keys;

        private Dictionary<string, Main_handler.action> _menu_string_to_action_dictionary = new()
        {
            { "Return to Game", Main_handler.action.return_to_Game },
            { "Save Game", Main_handler.action.save_game },
            { "Load Game", Main_handler.action.load_game },
            { "Exit Game", Main_handler.action.exit_game },
            { "Water", Main_handler.action.water },
            { "Log", Main_handler.action.open_log },
            { "Fertelize", Main_handler.action.fertelize },
            { "Settings", Main_handler.action.open_settings }
        };

        public Menu_handler(Menu menu_to_use_currently)
        {
            _current_menu = menu_to_use_currently;
        }

        public Main_handler.action update()
        {
            update_pressed_keys();

            Input_handler.key first_pressed_key = get_first_pressed_key();

            if (first_pressed_key == Input_handler.key.z)
            {
                return _menu_string_to_action_dictionary[_current_menu.get_selected_option()];
            }
            else
            {
                update_menu(first_pressed_key); // update what option in the menu is selected
                return Main_handler.action.none;
            }
        }

        private void update_pressed_keys()
        {
            Input_handler.key pressed_key = _input_handler.get_pressed_key();

            if (pressed_key != Input_handler.key.none)
            {
                _pressed_keys.Add(pressed_key);
            }
        }

        private Input_handler.key get_first_pressed_key()
        {
            if (_pressed_keys.Count > 0)
            {
                Input_handler.key key_to_return = _pressed_keys[0];

                _pressed_keys.RemoveAt(0);

                return key_to_return;
            }
            else
            {
                return Input_handler.key.none;
            }
        }

        private void update_menu(Input_handler.key pressed_key)
        {
            if (pressed_key == Input_handler.key.up)
            {
                _current_menu.step_up();
            }
            else if (pressed_key == Input_handler.key.down)
            {
                _current_menu.step_down();
            }
            else if (pressed_key == Input_handler.key.right)
            {
                _current_menu.step_right();
            }
            else if (pressed_key == Input_handler.key.left)
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
