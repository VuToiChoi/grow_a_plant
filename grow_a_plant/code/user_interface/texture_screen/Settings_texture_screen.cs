using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grow_a_plant
{
    class Settings_texture_screen : Texture_screen
    {
        public Settings_texture_screen(GraphicsDevice graphics_device, ContentManager content) : base(graphics_device, content)
        {
            int _screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int _screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;


            // in the future this would be done in a better way, probably with a json file or something, but for now this is fine
            // the _screen_width and _screen_height could be implemented in the future



            // background
            Texture_groups.Add("background", new Texture_group(0, 0, true));
            Texture_groups["background"].Image_rectangles.Add(new Image_rectangle(0, 0, _screen_width, (int)(_screen_height * 0.765), _content.Load<Texture2D>("picture's\\backdrop")));


            // clock
            Texture_groups.Add("clock", new Texture_group((int)(_screen_width * 0.014), (int)(_screen_height * 0.020), true));
            Texture_groups["clock"].Text_rectangles.Add(new Text_rectangle("", 0, 0, (int)(_screen_width * 0.152), (int)(_screen_height * 0.070)));


            // day counter
            Texture_groups.Add("day_counter", new Texture_group((int)(_screen_width * 0.014), (int)(_screen_height * 0.100), true));
            Texture_groups["day_counter"].Text_rectangles.Add(new Text_rectangle("", 0, 0, (int)(_screen_width * 0.152), (int)(_screen_height * 0.070)));


            // water bar
            Texture_groups.Add("water_bar", new Texture_group((int)(_screen_width * 0.009), (int)(_screen_height * 0.222), true));
            Texture_groups["water_bar"].Image_rectangles.Add(new Image_rectangle(0, 0, (int)(_screen_width * 0.085), (int)(_screen_height * 0.506), _content.Load<Texture2D>("picture's\\waterbartubebackground")));
            Texture_groups["water_bar"].Image_rectangles.Add(new Image_rectangle((int)(_screen_width * 0.002), (int)(_screen_height * 0.002), (int)(_screen_width * 0.082), 0, _content.Load<Texture2D>("picture's\\waterbartube")));


            // fertilize bar
            Texture_groups.Add("fertilize_bar", new Texture_group((int)(_screen_width * 0.009), (int)(_screen_height * 0.169), true));
            Texture_groups["fertilize_bar"].Image_rectangles.Add(new Image_rectangle(0, 0, (int)(_screen_width * 0.085), (int)(_screen_height * 0.047), _content.Load<Texture2D>("picture's\\soilbartubebackground")));
            Texture_groups["fertilize_bar"].Image_rectangles.Add(new Image_rectangle((int)(_screen_width * 0.002), (int)(_screen_height * 0.002), 0, (int)(_screen_height * 0.043), _content.Load<Texture2D>("picture's\\soilbartube")));


            // start menu
            int start_menu_width = _screen_width;
            int start_menu_height = (int)(_screen_height * 0.236);

            Texture_groups.Add("start_menu", new Texture_group(0, (int)(_screen_height * 0.765), true));
            // images
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(0, 0, start_menu_width, start_menu_height, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle((int)(start_menu_width * 0.564), (int)(start_menu_height * 0.170), (int)(start_menu_width * 0.185), (int)(start_menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle((int)(start_menu_width * 0.770), (int)(start_menu_height * 0.170), (int)(start_menu_width * 0.185), (int)(start_menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle((int)(start_menu_width * 0.564), (int)(start_menu_height * 0.564), (int)(start_menu_width * 0.185), (int)(start_menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle((int)(start_menu_width * 0.770), (int)(start_menu_height * 0.564), (int)(start_menu_width * 0.185), (int)(start_menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Settings has been opened.", (int)(start_menu_width * 0.156), (int)(start_menu_height * 0.411), (int)(start_menu_width * 0.219), (int)(start_menu_height * 0.178)));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Water", (int)(start_menu_width * 0.631), (int)(start_menu_height * 0.245), (int)(start_menu_width * 0.051), (int)(start_menu_height * 0.116)));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Fertilize", (int)(start_menu_width * 0.826), (int)(start_menu_height * 0.245), (int)(start_menu_width * 0.063), (int)(start_menu_height * 0.116)));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Log", (int)(start_menu_width * 0.643), (int)(start_menu_height * 0.635), (int)(start_menu_width * 0.025), (int)(start_menu_height * 0.116)));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Settings", (int)(start_menu_width * 0.830), (int)(start_menu_height * 0.635), (int)(start_menu_width * 0.065), (int)(start_menu_height * 0.116)));


            //settings menus
            int settings_menu_width = (int)(_screen_width * 0.259);
            int settings_menu_height = (int)(_screen_height * 0.672);

            // settings menu with return to game selected
            Texture_groups.Add("settings_menu_return_to_game_selected", new Texture_group((int)(_screen_width * 0.741), (int)(_screen_height * 0.069), true));
            // images
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, settings_menu_width, settings_menu_height, _content.Load<Texture2D>("picture's\\settingslogbackground")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.055), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbuttonselect")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.168), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.280), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.393), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            // text
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.055), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.168), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.280), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.393), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));

            // settings menu with save game selected
            Texture_groups.Add("settings_menu_save_game_selected", new Texture_group((int)(_screen_width * 0.741), (int)(_screen_height * 0.069), false));
            // images
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, settings_menu_width, settings_menu_height, _content.Load<Texture2D>("picture's\\settingslogbackground")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.055), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.168), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbuttonselect")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.280), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.393), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            // text
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.055), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.168), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.280), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.393), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));

            // settings menu with load game selected
            Texture_groups.Add("settings_menu_load_game_selected", new Texture_group((int)(_screen_width * 0.741), (int)(_screen_height * 0.069), false));
            // images
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, settings_menu_width, settings_menu_height, _content.Load<Texture2D>("picture's\\settingslogbackground")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.055), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.168), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.280), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbuttonselect")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.393), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            // text
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.055), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.168), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.280), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.393), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));

            // settings menu with exit game selected
            Texture_groups.Add("settings_menu_exit_game_selected", new Texture_group((int)(_screen_width * 0.741), (int)(_screen_height * 0.069), false));
            // images
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, settings_menu_width, settings_menu_height, _content.Load<Texture2D>("picture's\\settingslogbackground")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.055), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.168), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.280), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle((int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.393), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073), _content.Load<Texture2D>("picture's\\settingslogbuttonselect")));
            // text
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.055), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.168), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.280), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", (int)(settings_menu_width * 0.049), (int)(settings_menu_height * 0.393), (int)(settings_menu_width * 0.917), (int)(settings_menu_height * 0.073)));


            // stool
            Texture_groups.Add("stool", new Texture_group((int)(_screen_width * 0.334), (int)(_screen_height * 0.292), true));
            Texture_groups["stool"].Image_rectangles.Add(new Image_rectangle(0, 0, (int)(_screen_width * 0.332), (int)(_screen_height * 0.576), _content.Load<Texture2D>("picture's\\stool")));


            // plants

            // plant growth stage 1
            Texture_groups.Add("plant_growth_stage_1", new Texture_group((int)(_screen_width * 0.321), (int)(-1 * _screen_height * 0.230), true));
            Texture_groups["plant_growth_stage_1"].Image_rectangles.Add(new Image_rectangle(0, 0, (int)(_screen_width * 0.668), (int)(_screen_height * 1.200), _content.Load<Texture2D>("picture's\\firststage"))); // the names of image might be a bit confusing, the first and second stage images were pretty much the same

            // plant growth stage 2
            Texture_groups.Add("plant_growth_stage_2", new Texture_group((int)(_screen_width * 0.219), (int)(-1 * _screen_height * 0.054), false));
            Texture_groups["plant_growth_stage_2"].Image_rectangles.Add(new Image_rectangle(0, 0, (int)(_screen_width * 0.450), (int)(_screen_height * 0.900), _content.Load<Texture2D>("picture's\\secondstage"))); // the names of image might be a bit confusing, the third and fourth stage images were pretty much the same

            // plant growth stage 3
            Texture_groups.Add("plant_growth_stage_3", new Texture_group((int)(_screen_width * 0.165), (int)(-1 * _screen_height * 0.020), false));
            Texture_groups["plant_growth_stage_3"].Image_rectangles.Add(new Image_rectangle(0, 0, (int)(_screen_width * 0.403), (int)(_screen_height * 0.833), _content.Load<Texture2D>("picture's\\thirdstage")));

            // add more texture groups in the future, like animations
        }

        public override void update(Texture_screen_information texture_screen_information)
        {
            update_clock(texture_screen_information.Time_of_day);

            update_day_counter(texture_screen_information.Days_passed);

            update_water_bar(texture_screen_information.Water_level);

            update_fertilize_bar(texture_screen_information.Fertilize_level);

            update_selected_button(texture_screen_information.Selected_button);

            update_growth_stage(texture_screen_information.Growth_stage);
        }

        private void update_clock(TimeSpan time_of_day)
        {
            Texture_groups["clock"].Text_rectangles[0].Text = time_of_day.ToString(@"hh\:mm");
        }

        private void update_day_counter(int days_passed)
        {
            Texture_groups["day_counter"].Text_rectangles[0].Text = $"Days passed: {days_passed}";
        }

        private void update_water_bar(float water_level)
        {
            Texture_groups["water_bar"].Image_rectangles[1].Height = (int)(water_level * Texture_groups["water_bar"].Image_rectangles[0].Height);
            Texture_groups["water_bar"].Image_rectangles[1].Y_position = Texture_groups["water_bar"].Image_rectangles[0].Height - Texture_groups["water_bar"].Image_rectangles[1].Height;
        }

        private void update_fertilize_bar(float fertilize_level)
        {
            Texture_groups["fertilize_bar"].Image_rectangles[1].Width = (int)(fertilize_level * Texture_groups["fertilize_bar"].Image_rectangles[0].Width);
        }

        private void update_selected_button(Button_command_package selected_button)
        {
            if (selected_button.Command == Button_command_package.command_type.return_to_game)
            {
                Texture_groups["settings_menu_return_to_game_selected"].Is_visible = true;
                Texture_groups["settings_menu_save_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_load_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_exit_game_selected"].Is_visible = false;
            }
            else if (selected_button.Command == Button_command_package.command_type.save_game)
            {
                Texture_groups["settings_menu_return_to_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_save_game_selected"].Is_visible = true;
                Texture_groups["settings_menu_load_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_exit_game_selected"].Is_visible = false;
            }
            else if (selected_button.Command == Button_command_package.command_type.load_game)
            {
                Texture_groups["settings_menu_return_to_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_save_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_load_game_selected"].Is_visible = true;
                Texture_groups["settings_menu_exit_game_selected"].Is_visible = false;
            }
            else if (selected_button.Command == Button_command_package.command_type.exit_game)
            {
                Texture_groups["settings_menu_return_to_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_save_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_load_game_selected"].Is_visible = false;
                Texture_groups["settings_menu_exit_game_selected"].Is_visible = true;
            }
        }


        private void update_growth_stage(int growth_stage)
        {
            if (growth_stage == 1)
            {
                Texture_groups["plant_growth_stage_1"].Is_visible = true;
                Texture_groups["plant_growth_stage_2"].Is_visible = false;
                Texture_groups["plant_growth_stage_3"].Is_visible = false;
            }
            else if (growth_stage == 2)
            {
                Texture_groups["plant_growth_stage_1"].Is_visible = false;
                Texture_groups["plant_growth_stage_2"].Is_visible = true;
                Texture_groups["plant_growth_stage_3"].Is_visible = false;
            }
            else
            {
                Texture_groups["plant_growth_stage_1"].Is_visible = false;
                Texture_groups["plant_growth_stage_2"].Is_visible = false;
                Texture_groups["plant_growth_stage_3"].Is_visible = true;
            }
        }
    }
}

