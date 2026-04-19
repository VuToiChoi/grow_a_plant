using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Start_texture_screen : Texture_screen
    {
        public Start_texture_screen() : base() 
        { 
            // in the fututre, this should probably be done by some config files or something 
            Texture_groups.Add("menu_water_selected", new Texture_group(0, 0, true)); // add something like this
            Texture_groups["menu_water_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, )); 
        }
    }
}
