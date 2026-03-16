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

        enum button
        {
            water, 
            log, 
            fertilize,
            settings,
            return_to_game,
            save_game,
            load_game,
            exit_game
        }

        public void update(button selected_button)
        {
            
        }

        public void draw()
        {
            foreach (Image_square image_square in _current_texture_group.Image_squares)
            {
                // I do not currently know how to draw but it might work something like this
                // some drawer class.draw(image_square)
            }
        }

        public void change_texture_group(Texture_group texture_group)
        {
            _current_texture_group = texture_group;
        }
    }
}
