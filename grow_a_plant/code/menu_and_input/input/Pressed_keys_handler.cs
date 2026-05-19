using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Pressed_keys_handler
    {
        private List<Input_handler.key> _pressed_keys;
        private Input_handler _input_handler;
        private Input_handler.key _latest_pressed_key;

        public Pressed_keys_handler()
        {
            _pressed_keys = new List<Input_handler.key>();
            _input_handler = new Input_handler();
            _latest_pressed_key = Input_handler.key.none;
        }

        public void update()
        {
            Input_handler.key pressed_key = _input_handler.get_pressed_key();

            if (pressed_key != Input_handler.key.none && pressed_key != _latest_pressed_key) // only add the key if it is not none and if it has not been added already (if it is still being pressed)
            {
                _pressed_keys.Add(pressed_key);
            }

            _latest_pressed_key = pressed_key;
        }

        public Input_handler.key get_first_pressed_key()
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
    }
}
