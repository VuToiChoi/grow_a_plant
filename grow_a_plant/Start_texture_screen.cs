using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;

namespace grow_a_plant
{
    class Start_texture_screen : Texture_screen
    {
        private Information_text_updater _information_text_updater;

        public Text_rectangle Start_menu_information_text_rectangle { get; private set; }


        public Start_texture_screen(GraphicsDevice graphics_device, ContentManager content) : base(graphics_device, content)
        {
            _information_text_updater = new Information_text_updater();

            int _screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int _screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;


            // in the future this would be done in a better way, probably with a json file or something, but for now this is fine
            // the _screen_width and _screen_height could be implemented in the future to make the design responsive



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


            // start menus
            int menu_width = _screen_width;
            int menu_height = (int)(_screen_height * 0.236);

            Start_menu_information_text_rectangle = new Text_rectangle("choose what to do.", (int)(menu_width * 0.156), (int)(menu_height * 0.411), (int)(menu_width * 0.219), (int)(menu_height * 0.178));

            // start menu with water selected
            Texture_groups.Add("start_menu_water_selected", new Texture_group(0, (int)(_screen_height * 0.765), true));
            // images
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, menu_width, menu_height, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.564), (int)(menu_height * 0.170), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.770), (int)(menu_height * 0.170), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.564), (int)(menu_height * 0.564), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.770), (int)(menu_height * 0.564), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Water", (int)(menu_width * 0.631), (int)(menu_height * 0.245), (int)(menu_width * 0.051), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", (int)(menu_width * 0.826), (int)(menu_height * 0.245), (int)(menu_width * 0.063), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Log", (int)(menu_width * 0.643), (int)(menu_height * 0.635), (int)(menu_width * 0.025), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Settings", (int)(menu_width * 0.830), (int)(menu_height * 0.635), (int)(menu_width * 0.065), (int)(menu_height * 0.116)));


            // start menu with fertilize selected
            Texture_groups.Add("start_menu_fertilize_selected", new Texture_group(0, (int)(_screen_height * 0.765), false));
            // images
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, menu_width, menu_height, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.564), (int)(menu_height * 0.170), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.770), (int)(menu_height * 0.170), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.564), (int)(menu_height * 0.564), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.770), (int)(menu_height * 0.564), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Water", (int)(menu_width * 0.631), (int)(menu_height * 0.245), (int)(menu_width * 0.051), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", (int)(menu_width * 0.826), (int)(menu_height * 0.245), (int)(menu_width * 0.063), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Log", (int)(menu_width * 0.643), (int)(menu_height * 0.635), (int)(menu_width * 0.025), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Settings", (int)(menu_width * 0.830), (int)(menu_height * 0.635), (int)(menu_width * 0.065), (int)(menu_height * 0.116)));


            // start menu with log selected
            Texture_groups.Add("start_menu_log_selected", new Texture_group(0, (int)(_screen_height * 0.765), false));
            // images
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, menu_width, menu_height, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.564), (int)(menu_height * 0.170), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.770), (int)(menu_height * 0.170), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.564), (int)(menu_height * 0.564), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.770), (int)(menu_height * 0.564), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Water", (int)(menu_width * 0.631), (int)(menu_height * 0.245), (int)(menu_width * 0.051), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", (int)(menu_width * 0.826), (int)(menu_height * 0.245), (int)(menu_width * 0.063), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Log", (int)(menu_width * 0.643), (int)(menu_height * 0.635), (int)(menu_width * 0.025), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Settings", (int)(menu_width * 0.830), (int)(menu_height * 0.635), (int)(menu_width * 0.065), (int)(menu_height * 0.116)));


            // start menu with settings selected
            Texture_groups.Add("start_menu_settings_selected", new Texture_group(0, (int)(_screen_height * 0.765), false));
            //images
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, menu_width, menu_height, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.564), (int)(menu_height * 0.170), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.770), (int)(menu_height * 0.170), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.564), (int)(menu_height * 0.564), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.770), (int)(menu_height * 0.564), (int)(menu_width * 0.185), (int)(menu_height * 0.286), _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            // text
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Water", (int)(menu_width * 0.631), (int)(menu_height * 0.245), (int)(menu_width * 0.051), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", (int)(menu_width * 0.826), (int)(menu_height * 0.245), (int)(menu_width * 0.063), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Log", (int)(menu_width * 0.643), (int)(menu_height * 0.635), (int)(menu_width * 0.025), (int)(menu_height * 0.116)));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Settings", (int)(menu_width * 0.830), (int)(menu_height * 0.635), (int)(menu_width * 0.065), (int)(menu_height * 0.116)));


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

        override public void update(Texture_screen_information texture_screen_information)
        {
            update_clock(texture_screen_information.Time_of_day);

            update_day_counter(texture_screen_information.Days_passed);

            update_water_bar(texture_screen_information.Water_level);

            update_fertilize_bar(texture_screen_information.Fertilize_level);

            update_selected_button(texture_screen_information.Selected_button);

            update_growth_stage(texture_screen_information.Growth_stage);

            if (texture_screen_information.Button_is_pressed)
            {
                _information_text_updater.update(Start_menu_information_text_rectangle, texture_screen_information.Selected_button);

                // add other things that should happen when a button is pressed, like adding animations
            }

            // add the updatating of the water and fertilize bars
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
            if (selected_button.Command == Button_command_package.command_type.water)
            {
                Texture_groups["start_menu_water_selected"].Is_visible = true;
                Texture_groups["start_menu_fertilize_selected"].Is_visible = false;
                Texture_groups["start_menu_log_selected"].Is_visible = false;
                Texture_groups["start_menu_settings_selected"].Is_visible = false;
            }
            else if (selected_button.Command == Button_command_package.command_type.fertilize)
            {
                Texture_groups["start_menu_water_selected"].Is_visible = false;
                Texture_groups["start_menu_fertilize_selected"].Is_visible = true;
                Texture_groups["start_menu_log_selected"].Is_visible = false;
                Texture_groups["start_menu_settings_selected"].Is_visible = false;
            }
            else if (selected_button.Command == Button_command_package.command_type.log)
            {
                Texture_groups["start_menu_water_selected"].Is_visible = false;
                Texture_groups["start_menu_fertilize_selected"].Is_visible = false;
                Texture_groups["start_menu_log_selected"].Is_visible = true;
                Texture_groups["start_menu_settings_selected"].Is_visible = false;
            }
            else if (selected_button.Command == Button_command_package.command_type.settings)
            {
                Texture_groups["start_menu_water_selected"].Is_visible = false;
                Texture_groups["start_menu_fertilize_selected"].Is_visible = false;
                Texture_groups["start_menu_log_selected"].Is_visible = false;
                Texture_groups["start_menu_settings_selected"].Is_visible = true;
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
