using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Settings_menu : Menu_1d
    {
        public Settings_menu() : base(new Menu_command_package[] { new Menu_command_package(Menu_command_package.command_type.return_to_game), 
                                                                   new Menu_command_package(Menu_command_package.command_type.save_game),
                                                                   new Menu_command_package(Menu_command_package.command_type.load_game),
                                                                   new Menu_command_package(Menu_command_package.command_type.exit_game)
                                                                 })
        {
        }
    }
}
