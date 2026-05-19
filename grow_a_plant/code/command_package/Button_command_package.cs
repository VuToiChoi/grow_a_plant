using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Button_command_package : Command_package<Button_command_package.command_type>
    {
        public enum command_type
        {
            water,
            log,
            fertilize,
            settings,
            return_to_game,
            save_game,
            load_game,
            exit_game,
            understood,
            skip
        }

        public Button_command_package(command_type command) : base(command)
        {
        }
    }
}
