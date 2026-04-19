using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Texture_group
    {
        public int X_position { get; private set; } // position relative to the whole screen

        public int Y_position { get; private set; } // position relative to the whole screen

        public bool Is_visible { get; set; }

        public List<Image_rectangle> Image_rectangles { get; private set; }

        // will probably need more fields in the future, like animations and text


        public Texture_group(int x_position, int y_position, bool is_visible)
        {
            X_position = x_position;
            Y_position = y_position;
            Is_visible = is_visible;

            Image_rectangles = new List<Image_rectangle>();
        }
    }
}
