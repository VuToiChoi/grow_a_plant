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
        Menu_handler _menu_handler;

        Plant_handler _plant_handler;

        Interface_handler _interface_handler;

        public Main_handler()
        {
            _menu_handler = new Menu_handler(); // fix

            _plant_handler = new Plant_handler(); // fix

            _interface_handler = new Interface_handler(); // fix
        }

        public void update()
        {
            Menu_handler.action action = _menu_handler.update();

            conduct_action(action);

            _plant_handler.update(); // fix

            _interface_handler.update(); // fix
        }

        private void conduct_action(Menu_handler.action action)
        {
            if (action == Menu_handler.action.return_to_game)
            {
                // change menu
            }
            else if (action == Menu_handler.action.save_game)
            {
                // save game
            }
            else if (action == Menu_handler.action.load_game)
            {
                // load game
            }
            else if (action == Menu_handler.action.exit_game)
            {
                // exit game
            }
            else if (action == Menu_handler.action.water)
            {
                // water plant
            }
            else if (action == Menu_handler.action.open_log)
            {
                // open log
            }
            else if (action == Menu_handler.action.fertelize)
            {
                // fertelize plant
            }
            else if (action == Menu_handler.action.open_settings)
            {
                // open settings menu
            }
            else if (action == Menu_handler.action.none)
            {
                // do nothing
            }
        }

        // draw, update
    }
}
