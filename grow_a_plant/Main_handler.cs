using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace grow_a_plant
{
    public class Main_handler
    {
        Menu_handler_interface _menu_handler_interface;

        Plant_handler _plant_handler;

        User_interface_interface _user_interface_interface;

        Dictionary<Menu_command_package.command_type, Button_command_package> _menu_command_package_command_type_to_button_command_package_dictionary = new Dictionary<Menu_command_package.command_type, Button_command_package>
        {
            { Menu_command_package.command_type.water, new Button_command_package(Button_command_package.command_type.water) },
            { Menu_command_package.command_type.open_log, new Button_command_package(Button_command_package.command_type.log) },
            { Menu_command_package.command_type.fertelize, new Button_command_package(Button_command_package.command_type.fertilize) },
            { Menu_command_package.command_type.open_settings, new Button_command_package(Button_command_package.command_type.settings) },
            { Menu_command_package.command_type.return_to_game, new Button_command_package(Button_command_package.command_type.return_to_game) },
            { Menu_command_package.command_type.save_game, new Button_command_package(Button_command_package.command_type.save_game) },
            { Menu_command_package.command_type.load_game, new Button_command_package(Button_command_package.command_type.load_game) },
            { Menu_command_package.command_type.exit_game, new Button_command_package(Button_command_package.command_type.exit_game) }
        };

        public Main_handler(SpriteBatch sprite_batch, SpriteFont sprite_font, GraphicsDevice graphics_device, ContentManager content)
        {
            _menu_handler_interface = new Menu_handler_interface();

            _plant_handler = new Plant_handler(); // fix

            _user_interface_interface = new User_interface_interface(sprite_batch, sprite_font, graphics_device, content);
        }

        public void update()
        {
            Menu_handler_information menu_handler_information = _menu_handler_interface.update();

            if (menu_handler_information.Button_is_pressed)
            {
                conduct_action(menu_handler_information.Selected_button.Command);
            }

            // _plant_handler.update(); // fix

            Texture_screen_information texture_screen_information = new Texture_screen_information(_menu_command_package_command_type_to_button_command_package_dictionary[menu_handler_information.Selected_button.Command], menu_handler_information.Button_is_pressed, 0.5f, 0.5f, 3, 0);

            _user_interface_interface.update(texture_screen_information);
        }

        private void conduct_action(Menu_command_package.command_type command)
        {
            if (command == Menu_command_package.command_type.return_to_game)
            {
                _menu_handler_interface.change_to_start_menu();

                _user_interface_interface.change_to_start_texture_screen();
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
                _menu_handler_interface.change_to_settings_menu();

                _user_interface_interface.change_to_settings_texture_screen();
            }
        }

        public void draw()
        {
            _user_interface_interface.draw();
        }
    }
}
