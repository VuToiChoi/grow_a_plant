using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grow_a_plant
{
    class User_interface_handler
    {
        private Texture_screen _texture_Screen;

        private User_interface_drawer _user_interface_drawer;

        public User_interface_handler(Texture_screen texture_screen_to_use_currently, SpriteBatch sprite_batch, SpriteFont sprite_font)
        {
            _texture_Screen = texture_screen_to_use_currently;
            _user_interface_drawer = new User_interface_drawer(sprite_batch, sprite_font);
        }

        public void update(Texture_screen_information texture_screen_information)
        {
            _texture_Screen.update(texture_screen_information);
        }

        public void draw()
        {
            foreach (Texture_group texture_group in _texture_Screen.Texture_groups.Values)
            {
                if (texture_group.Is_visible)
                {
                    foreach (Image_rectangle image_rectangle in texture_group.Image_rectangles)
                    {
                        _user_interface_drawer.draw(texture_group.X_position, texture_group.Y_position, image_rectangle);
                    }

                    foreach (Text_rectangle text_rectangle in texture_group.Text_rectangles)
                    {
                        _user_interface_drawer.draw(texture_group.X_position, texture_group.Y_position, text_rectangle);
                    }
                }
            }
        }

        public void change_texture_screen(Texture_screen texture_screen)
        {
            _texture_Screen = texture_screen;
        }
    }
}
