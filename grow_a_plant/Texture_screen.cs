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

        public Texture_screen()
        {
            Texture_groups = new Dictionary<string, Texture_group>();
        }

        virtual public void update(Texture_screen_information texture_screen_information)
        {

        }
    }
}
