using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Main_handler
    {
        // draw, update

        public enum action
        {
            return_to_Game,
            save_game,
            load_game,
            exit_game,
            water,
            open_log,
            fertelize,
            open_settings,
            none
        }
    }
}
