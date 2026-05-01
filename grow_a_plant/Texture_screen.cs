using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    abstract class Texture_screen
    {
        public Dictionary<string, Texture_group> Texture_groups { get; private set; }

        protected GraphicsDevice _graphics_device;

        protected ContentManager _content;

        public Texture_screen(GraphicsDevice graphics_device, ContentManager content)
        {
            _graphics_device = graphics_device;

            _content = content;

            Texture_groups = new Dictionary<string, Texture_group>();
        }

        virtual public void update(Texture_screen_information texture_screen_information)
        {

        }
    }
}
