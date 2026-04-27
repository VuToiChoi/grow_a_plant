using Microsoft.Xna.Framework.Graphics;
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


        public Start_texture_screen(GraphicsDevice graphics_device) : base(graphics_device) 
        {
            _information_text_updater = new Information_text_updater();

            int _screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int _screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;


            // in the future this would be done in a better way, probably with a json file or something, but for now this is fine
            // the _screen_width and _screen_height could be implemented in the future



            // background
            Texture_groups.Add("background", new Texture_group(0, 0, true));
            Texture_groups["background"].Image_rectangles.Add(new Image_rectangle(0, 0, _screen_width, _screen_height, Texture2D.FromFile(graphics_device, "Content/picture's/backdrop.png")));



            // start menus
            Start_menu_information_text_rectangle = new Text_rectangle("", 0, 0);

            // start menu with water selected
            Texture_groups.Add("start_menu_water_selected", new Texture_group(0, 783, true));
            // images
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/picture's/background.png")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubuttonselect.png")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_water_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            // text
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", 812, 41));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Log", 812, 41));
            Texture_groups["start_menu_water_selected"].Text_rectangles.Add(new Text_rectangle("Settings", 812, 41));


            // start menu with fertilize selected
            Texture_groups.Add("start_menu_fertilize_selected", new Texture_group(0, 783, false));
            // images
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/picture's/background.png")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubuttonselect.png")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            // text
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", 812, 41));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Log", 812, 41));
            Texture_groups["start_menu_fertilize_selected"].Text_rectangles.Add(new Text_rectangle("Settings", 812, 41));


            // start menu with log selected
            Texture_groups.Add("start_menu_log_selected", new Texture_group(0, 783, false));
            // images
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/picture's/background.png")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubuttonselect.png")));
            Texture_groups["start_menu_log_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            // text
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", 812, 41));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Log", 812, 41));
            Texture_groups["start_menu_log_selected"].Text_rectangles.Add(new Text_rectangle("Settings", 812, 41));


            // start menu with settings selected
            Texture_groups.Add("start_menu_settings_selected", new Texture_group(0, 783, false));
            //images
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/picture's/background.png")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubuttonselect.png")));
            // text
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(Start_menu_information_text_rectangle);
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Fertilize", 812, 41));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Log", 812, 41));
            Texture_groups["start_menu_settings_selected"].Text_rectangles.Add(new Text_rectangle("Settings", 812, 41));


            // add more texture groups in the future, like the plant and the water and fertilize bars
        }

        override public void update(Texture_screen_information texture_screen_information)
        {
            select_correct_button(texture_screen_information.Selected_button);

            if (texture_screen_information.Button_is_pressed)
            {
                _information_text_updater.update(Start_menu_information_text_rectangle, texture_screen_information.Selected_button);

                // add other things that should happen when a button is pressed, like adding animations
            }

            // add the updatating of the plant and the water and fertilize bars
        }

        private void select_correct_button(Button_command_package selected_button)
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
    }
}
