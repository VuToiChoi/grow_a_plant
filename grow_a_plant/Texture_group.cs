using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    abstract class Texture_group
    {
        public List<Image_rectangle> Image_rectangles { get; private set; }

        // will probably need more fields in the future, like animations and text

        public bool Is_visible { get; set; }

        public Texture_group()
        {
            Image_rectangles = new List<Image_rectangle>();
        }
    }
}
