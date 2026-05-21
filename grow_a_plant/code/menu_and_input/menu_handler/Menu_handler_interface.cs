using grow_a_plant.code.menu_and_input.menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public class Menu_handler_interface
    {
        Menu_handler _menu_handler;

        Start_menu _start_menu;

        Settings_menu _settings_menu;

        Tutorial_menu _tutorial_menu;

        public Menu_handler_interface()
        {
            _start_menu = new Start_menu();
            _settings_menu = new Settings_menu();
            _tutorial_menu = new Tutorial_menu();

            _menu_handler = new Menu_handler(_tutorial_menu);
        }

        public void change_to_start_menu()
        {
            _menu_handler.change_menu(_start_menu);
        }

        public void change_to_settings_menu()
        {
            _menu_handler.change_menu(_settings_menu);
        }

        public void change_to_tutorial_menu()
        {
            _menu_handler.change_menu(_tutorial_menu);
        }

        public Menu_handler_information update()
        {
            return _menu_handler.update();
        }
    }
}
