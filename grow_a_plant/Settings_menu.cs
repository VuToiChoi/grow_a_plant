using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    internal class Settings_menu : Menu_1d
    {
        public Settings_menu() : base(new[] { "Return to Game", "Save Game", "Load Game", "Exit Game" })
        {
        }
    }
}
