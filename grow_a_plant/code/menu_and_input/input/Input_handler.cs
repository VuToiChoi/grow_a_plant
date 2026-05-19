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
        public enum key
        {
            up,
            down,
            left,
            right,
            w,
            s,
            a,
            d,
            z,
            x,
            none
        }

        public key get_pressed_key()
        {
            KeyboardState keyboard_state = Keyboard.GetState();


            if (keyboard_state.IsKeyDown(Keys.Up))
            {
                return key.up;
            }
            else if (keyboard_state.IsKeyDown(Keys.Down))
            {
                return key.down;
            }
            else if (keyboard_state.IsKeyDown(Keys.Left))
            {
                return key.left;
            }
            else if (keyboard_state.IsKeyDown(Keys.Right))
            {
                return key.right;
            }
            else if (keyboard_state.IsKeyDown(Keys.W))
            {
                return key.w;
            }
            else if (keyboard_state.IsKeyDown(Keys.S))
            {
                return key.s;
            }
            else if (keyboard_state.IsKeyDown(Keys.A))
            {
                return key.a;
            }
            else if (keyboard_state.IsKeyDown(Keys.D))
            {
                return key.d;
            }
            else if (keyboard_state.IsKeyDown(Keys.Z))
            {
                return key.z;
            }
            else if (keyboard_state.IsKeyDown(Keys.X))
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
