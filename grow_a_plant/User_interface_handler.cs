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
        Texture_group _current_texture_group;

        public void update(Button_command_package.command_type selected_button)
        {
            
        }

        public void draw()
        {
            foreach (Image_rectangle image_rectangles in _current_texture_group.Image_rectangles)
            {
                // I do not currently know how to draw but it might work something like this
                // some drawer class.draw(image_rectangles)
            }
        }

        public void change_texture_group(Texture_group texture_group)
        {
            _current_texture_group = texture_group;
        }
    }
}
