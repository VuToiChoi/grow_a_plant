using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Menu_command_package : Command_package<Menu_command_package.command_type>
    {
        public enum command_type
        {
            return_to_game,
            save_game,
            load_game,
            exit_game,
            water,
            open_log,
            fertelize,
            open_settings,
            none
        }

        public Menu_command_package(command_type command) : base(command)
        {
        }
    }
}
