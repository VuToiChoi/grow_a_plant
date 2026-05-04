using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Main_handler
    {
        Menu_handler_interface _menu_handler_inerface;

        Plant_handler _plant_handler;

        User_interface_handler _user_interface_handler;

        public Main_handler()
        {
            _menu_handler_inerface = new Menu_handler_interface(); // fix

            _plant_handler = new Plant_handler(); // fix

            _user_interface_handler = new User_interface_handler(); // fix
        }

        public void update()
        {
            Menu_handler_information menu_handler_information = _menu_handler_inerface.update();

            if (menu_handler_information.Button_is_pressed)
            {
                conduct_action(menu_handler_information.Selected_button.Command);
            }

            _plant_handler.update(); // fix

            _interface_handler.update(); // fix
        }

        private void conduct_action(Menu_command_package.command_type command)
        {
            if (command == Menu_command_package.command_type.return_to_game)
            {
                _menu_handler_inerface.change_to_start_menu();

                // change something in the interface for it to change proparly
            }
            else if (command == Menu_command_package.command_type.save_game)
            {
                // save game
            }
            else if (command == Menu_command_package.command_type.load_game)
            {
                // load game
            }
            else if (command == Menu_command_package.command_type.exit_game)
            {
                // exit game
            }
            else if (command == Menu_command_package.command_type.water)
            {
                // water plant
            }
            else if (command == Menu_command_package.command_type.open_log)
            {
                // open log
            }
            else if (command == Menu_command_package.command_type.fertelize)
            {
                // fertelize plant
            }
            else if (command == Menu_command_package.command_type.open_settings)
            {
                // open settings menu
            }
        }

        // draw, update
    }
}
