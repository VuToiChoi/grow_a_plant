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
        bool _should_exit_game = false;

        Data_handler _data_handler;

        Time_handler _time_handler;

        Plant_handler _plant_handler;

        Sound_handler _sound_handler;

        Menu_handler_interface _menu_handler_interface;

        User_interface_interface _user_interface_interface;


        Dictionary<Menu_command_package.command_type, Button_command_package> _menu_command_package_command_type_to_button_command_package_dictionary = new Dictionary<Menu_command_package.command_type, Button_command_package>
        {
            { Menu_command_package.command_type.water, new Button_command_package(Button_command_package.command_type.water) },
            { Menu_command_package.command_type.open_log, new Button_command_package(Button_command_package.command_type.log) },
            { Menu_command_package.command_type.fertelize, new Button_command_package(Button_command_package.command_type.fertilize) },
            { Menu_command_package.command_type.open_settings, new Button_command_package(Button_command_package.command_type.settings) },
            { Menu_command_package.command_type.return_to_game, new Button_command_package(Button_command_package.command_type.return_to_game) },
            { Menu_command_package.command_type.save_game, new Button_command_package(Button_command_package.command_type.save_game) },
            { Menu_command_package.command_type.exit_game, new Button_command_package(Button_command_package.command_type.exit_game) },
            { Menu_command_package.command_type.previous_tutorial_slide, new Button_command_package(Button_command_package.command_type.previous_tutorial_slide) },
            { Menu_command_package.command_type.next_tutorial_slide, new Button_command_package(Button_command_package.command_type.next_tutorial_slide) },
            { Menu_command_package.command_type.exit_tutorial, new Button_command_package(Button_command_package.command_type.exit_tutorial) },
            { Menu_command_package.command_type.open_tutorial, new Button_command_package(Button_command_package.command_type.open_tutorial) },

        };

        public Main_handler(Data_handler data_handler, Time_handler time_handler, Plant plant, Weather_handler weather_handler, float offline_game_seconds, SpriteBatch sprite_batch, SpriteFont sprite_font, GraphicsDevice graphics_device, ContentManager content)
        {
            _data_handler =  data_handler;

            _time_handler = time_handler;

            _plant_handler = new Plant_handler(plant, weather_handler, offline_game_seconds);

            _sound_handler = new Sound_handler(content);

            _menu_handler_interface = new Menu_handler_interface();

            _user_interface_interface = new User_interface_interface(sprite_batch, sprite_font, graphics_device, content);
        }

        public bool update(float delta_game_time, TimeSpan time_of_day, long day_count)
        {
            // update plant
            _plant_handler.update_plant_info(delta_game_time);

            // update the menus based on input and get the information about what it looks like right now (if a button is pressed or what option in a menu is selected)
            Menu_handler_information menu_handler_information = _menu_handler_interface.update();

            // if a button is pressed, conduct the action related to that button
            if (menu_handler_information.Button_is_pressed)
            {
                conduct_action(menu_handler_information.Selected_button.Command);
            }

            // create the information needed to update the texture screen and update it
            Texture_screen_information texture_screen_information = new Texture_screen_information(_menu_command_package_command_type_to_button_command_package_dictionary[menu_handler_information.Selected_button.Command], menu_handler_information.Button_is_pressed, _plant_handler.get_plant().Water_level, _plant_handler.get_plant().Fertilize_level, (int)_plant_handler.get_plant().Current_growth_stage, time_of_day, (int)day_count);
            _user_interface_interface.update(texture_screen_information);


            if (_should_exit_game)
            {
                return false;
            }
            else
            {
                return true;
            }
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
                _data_handler.save_plant_data(_plant_handler.get_plant());
                var state = _time_handler.get_save_state();
                _data_handler.save_time_state(state.last_saved_utc_ticks, state.day_count, state.time_of_day_seconds);

            }
            else if (command == Menu_command_package.command_type.open_tutorial)
            {
                _menu_handler_interface.change_to_tutorial_menu();
                _user_interface_interface.change_to_tutorial_texture_screen();
            }
            else if (command == Menu_command_package.command_type.exit_game)
            {
                _should_exit_game = true;
            }
            else if (command == Menu_command_package.command_type.water)
            {
                _plant_handler.water_plant();
                _sound_handler.play_water_sound();
            }
            else if (command == Menu_command_package.command_type.open_log)
            {
                // open log
            }
            else if (command == Menu_command_package.command_type.fertelize)
            {
                _plant_handler.fertilize_plant();
            }
            else if (command == Menu_command_package.command_type.open_settings)
            {
                _menu_handler_interface.change_to_settings_menu();
                _user_interface_interface.change_to_settings_texture_screen();
            }
            else if (command == Menu_command_package.command_type.exit_tutorial)
            {
                _menu_handler_interface.change_to_start_menu();
                _user_interface_interface.change_to_start_texture_screen();
            }
        }

        public void draw()
        {
            _user_interface_interface.draw();
        }

        public Plant get_plant()
        {
            return _plant_handler.get_plant();
        }
    }
}
