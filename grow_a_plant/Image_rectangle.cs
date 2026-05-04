using Microsoft.Xna.Framework.Content;
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

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Texture2D Image { get; private set; }

        public Image_rectangle(int x_position, int y_position, int width, int height, Texture2D image)
        {
            X_position = x_position;
            Y_position = y_position;
            Width = width;
            Height = height;
            Image = image;
        }
    }
}
