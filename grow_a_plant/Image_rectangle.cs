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
        public int X_position { get; private set; }

        public int Y_position { get; private set; }

        public Texture2D Image { get; private set; }

        public bool visible { get; set; }
    }
}
