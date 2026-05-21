using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant.code.menu_and_input.menus
{
    class Tutorial_menu : Menu_1d
    {
        public Tutorial_menu() : base(new Menu_command_package[] { new Menu_command_package(Menu_command_package.command_type.previous_tutorial_slide),
                                                                   new Menu_command_package(Menu_command_package.command_type.next_tutorial_slide),
                                                                   new Menu_command_package(Menu_command_package.command_type.exit_tutorial)
                                                                 })
        {
        }
    }
}
