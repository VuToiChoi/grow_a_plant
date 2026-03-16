using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Settings_texture_group : Texture_group
    {
        public Settings_texture_group() : base()
        {
            Image_rectangles.Add("water", new Image_rectangle() { X_position = 0, Y_position = 0, Image = Game1.Water_image }); // add something like this
        }
    }
}
