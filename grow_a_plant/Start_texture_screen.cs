using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // the _screen_width and _screen_height could be implemented in the future



            // background
            Texture_groups.Add("background", new Texture_group(0, 0, true));
            Texture_groups["background"].Image_rectangles.Add(new Image_rectangle(0, 0, _screen_width, _screen_height, _content.Load<Texture2D>("picture's\\backdrop")));


            // water bar
            Texture_groups.Add("water_bar", new Texture_group(14, 228, true));
            Texture_groups["water_bar"].Image_rectangles.Add(new Image_rectangle(0, 0, 120, 520, _content.Load<Texture2D>("picture's\\waterbartubebackground")));
            Texture_groups["water_bar"].Image_rectangles.Add(new Image_rectangle(0, 0, 120, 0, _content.Load<Texture2D>("picture's\\waterbartube")));


            // fertilize bar
            Texture_groups.Add("fertilize_bar", new Texture_group(14, 176, true));
            Texture_groups["fertilize_bar"].Image_rectangles.Add(new Image_rectangle(0, 0, 120, 40, _content.Load<Texture2D>("picture's\\fertilizebartubebackground")));
            Texture_groups["fertilize_bar"].Image_rectangles.Add(new Image_rectangle(0, 0, 0, 40, _content.Load<Texture2D>("picture's\\fertilizebartube")));


            // start menus
            Start_menu_information_text_rectangle = new Text_rectangle("", 0, 0, 100, 100);

            // start menu with water selected
            Texture_groups.Add("start_menu_water_selected", new Texture_group(0, 783, true));
            // images
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41, 266, 69));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", 1109, 41, 266, 69));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Log", 812, 136, 266, 69));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Settings", 1109, 136, 266, 69));


            // start menu with fertilize selected
            Texture_groups.Add("start_menu_fertilize_selected", new Texture_group(0, 783, false));
            // images
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41, 266, 69));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", 1109, 41, 266, 69));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Log", 812, 136, 266, 69));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Settings", 1109, 136, 266, 69));


            // start menu with log selected
            Texture_groups.Add("start_menu_log_selected", new Texture_group(0, 783, false));
            // images
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41, 266, 69));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", 1109, 41, 266, 69));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Log", 812, 136, 266, 69));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Settings", 1109, 136, 266, 69));


            // start menu with settings selected
            Texture_groups.Add("start_menu_settings_selected", new Texture_group(0, 783, false));
            //images
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            // text
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41, 266, 69));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", 1109, 41, 266, 69));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Log", 812, 136, 266, 69));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Settings", 1109, 136, 266, 69));


            // plants

            // plant growth stage 1
            Texture_groups.Add("plant_growth_stage_1", new Texture_group(470, 145, true));
            Texture_groups["plant_growth_stage_1"].Image_rectangles.Add(new Image_rectangle(0, 0, 453, 453, _content.Load<Texture2D>("picture's\\firststage")));

            // plant growth stage 2
            Texture_groups.Add("plant_growth_stage_2", new Texture_group(470, 145, false));
            Texture_groups["plant_growth_stage_2"].Image_rectangles.Add(new Image_rectangle(0, 0, 453, 453, _content.Load<Texture2D>("picture's\\secondstage")));

            // plant growth stage 3
            Texture_groups.Add("plant_growth_stage_3", new Texture_group(470, 145, false));
            Texture_groups["plant_growth_stage_3"].Image_rectangles.Add(new Image_rectangle(0, 0, 453, 453, _content.Load<Texture2D>("picture's\\thirdstage")));

            // plant growth stage 4
            Texture_groups.Add("plant_growth_stage_4", new Texture_group(470, 145, false));
            Texture_groups["plant_growth_stage_4"].Image_rectangles.Add(new Image_rectangle(0, 0, 453, 453, _content.Load<Texture2D>("picture's\\fourthstage")));

            // plant growth stage 5
            Texture_groups.Add("plant_growth_stage_5", new Texture_group(470, 145, false));
            Texture_groups["plant_growth_stage_5"].Image_rectangles.Add(new Image_rectangle(0, 0, 453, 453, _content.Load<Texture2D>("picture's\\fifthstage")));


            // add more texture groups in the future, like the plant and the water and fertilize bars
        }

        override public void update(Texture_screen_information texture_screen_information)
        {
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

        private void update_water_bar(float water_amount)
        {
            Texture_groups["water_bar"].Image_rectangles[1].Height = (int)(water_amount * Texture_groups["water_bar"].Image_rectangles[0].Height);
            Texture_groups["water_bar"].Image_rectangles[1].Y_position = Texture_groups["water_bar"].Image_rectangles[0].Height - Texture_groups["water_bar"].Image_rectangles[1].Height;
        }

        private void update_fertilize_bar(float fertilize_amount)
        {
            Texture_groups["fertilize_bar"].Image_rectangles[1].Height = (int)(fertilize_amount * Texture_groups["fertilize_bar"].Image_rectangles[0].Width);
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
                Texture_groups["plant_growth_stage_4"].Is_visible = false;
                Texture_groups["plant_growth_stage_5"].Is_visible = false;
            }
            else if (growth_stage == 2)
            {
                Texture_groups["plant_growth_stage_1"].Is_visible = false;
                Texture_groups["plant_growth_stage_2"].Is_visible = true;
                Texture_groups["plant_growth_stage_3"].Is_visible = false;
                Texture_groups["plant_growth_stage_4"].Is_visible = false;
                Texture_groups["plant_growth_stage_5"].Is_visible = false;
            }
            else if (growth_stage == 3)
            {
                Texture_groups["plant_growth_stage_1"].Is_visible = false;
                Texture_groups["plant_growth_stage_2"].Is_visible = false;
                Texture_groups["plant_growth_stage_3"].Is_visible = true;
                Texture_groups["plant_growth_stage_4"].Is_visible = false;
                Texture_groups["plant_growth_stage_5"].Is_visible = false;
            }
            else if (growth_stage == 4)
            {
                Texture_groups["plant_growth_stage_1"].Is_visible = false;
                Texture_groups["plant_growth_stage_2"].Is_visible = false;
                Texture_groups["plant_growth_stage_3"].Is_visible = false;
                Texture_groups["plant_growth_stage_4"].Is_visible = true;
                Texture_groups["plant_growth_stage_5"].Is_visible = false;
            }
            else if (growth_stage >= 5)
            {
                Texture_groups["plant_growth_stage_1"].Is_visible = false;
                Texture_groups["plant_growth_stage_2"].Is_visible = false;
                Texture_groups["plant_growth_stage_3"].Is_visible = false;
                Texture_groups["plant_growth_stage_4"].Is_visible = false;
                Texture_groups["plant_growth_stage_5"].Is_visible = true;
            }
        }
    }
}
