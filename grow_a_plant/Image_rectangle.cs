using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Image_rectangle
    {
        public int X_position { get; private set; } // position relative to its texture group, not the whole screen

        public int Y_position { get; private set; } // position relative to its texture group, not the whole screen

        public Texture2D Image { get; private set; }
    }
}
