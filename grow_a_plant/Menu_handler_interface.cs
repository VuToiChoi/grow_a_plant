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

        public Menu_handler_interface()
        {
            _start_menu = new Start_menu();
            _settings_menu = new Settings_menu();

            Menu_handler _menu_handler = new Menu_handler(_start_menu);
        }

        public void change_to_start_menu()
        {
            _menu_handler.change_menu(_start_menu);
        }

        public void change_to_settings_menu()
        {
            _menu_handler.change_menu(_settings_menu);
        }

        public Menu_handler_information update()
        {
            return _menu_handler.update();
        }
    }
}
