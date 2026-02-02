using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Start_menu : Menu_2d
    {
        public  Start_menu() : base(new string[] { "Water", "Log", "Fertelize", "Settings" }, 2)
        {
        }
    }
}
