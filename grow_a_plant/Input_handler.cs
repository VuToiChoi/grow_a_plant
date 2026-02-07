using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Input_handler
    {
        KeyboardState _keyboard_state;

        public enum key
        {
            up,
            down,
            left,
            right,
            z,
            x,
            none
        }

        public Input_handler(KeyboardState keyboard_state)
        {
            _keyboard_state = keyboard_state;
        }

        public key get_pressed_key()
        {
            if (_keyboard_state.IsKeyDown(Keys.Up))
            {
                return key.up;
            }
            else if (_keyboard_state.IsKeyDown(Keys.Down))
            {
                return key.down;
            }
            else if (_keyboard_state.IsKeyDown(Keys.Left))
            {
                return key.left;
            }
            else if (_keyboard_state.IsKeyDown(Keys.Right))
            {
                return key.right;
            }
            else if (_keyboard_state.IsKeyDown(Keys.Z))
            {
                return key.z;
            }
            else if (_keyboard_state.IsKeyDown(Keys.X))
            {
                return key.x;
            }
            else
            {
                return key.none;
            }
        }
    }
}
