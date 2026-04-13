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
        Texture_screen _texture_Screen;

        public void update(Texture_screen_information texture_screen_information)
        {
            _texture_Screen.update(texture_screen_information);
        }

        public void draw()
        {
            foreach (Texture_group texture_group in _texture_Screen.Texture_groups.Values)
            {
                foreach (Image_rectangle image_rectangle in texture_group.Image_rectangles)
                {
                    // I do not currently know how to draw but it might work something like this
                    // some drawer class.draw(image_rectangle)
                }
            }
        }

        public void change_texture_screen(Texture_screen texture_screen)
        {
            _texture_Screen = texture_screen;
        }
    }
}
