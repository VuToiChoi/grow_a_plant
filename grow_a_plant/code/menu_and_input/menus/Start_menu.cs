using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Start_menu : Menu_2d
    {
        public Start_menu() : base(new Menu_command_package[] { new Menu_command_package(Menu_command_package.command_type.water), 
                                                                new Menu_command_package(Menu_command_package.command_type.open_log), 
                                                                new Menu_command_package(Menu_command_package.command_type.fertelize), 
                                                                new Menu_command_package(Menu_command_package.command_type.open_settings) 
                                                              }, 2)
        {
        }
    }
}
