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
            Texture_groups["background"].Image_rectangles.Add(new Image_rectangle(0, 0, _screen_width, _screen_height, _content.Load<Texture2D>("picture's\\backdrop")));


            // start menu
            Texture_groups.Add("start_menu", new Texture_group(0, 783, true));
            // images
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, _content.Load<Texture2D>("picture's\\background")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            // text
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Settings has been opened.", 0, 0, 100, 100));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41, 266, 69));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Fertilize", 1109, 41, 266, 69));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Log", 812, 136, 266, 69));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Settings", 1109, 136, 266, 69));


            //settings menus

            // settings menu with return to game selected
            Texture_groups.Add("settings_menu_return_to_game_selected", new Texture_group(1061, 71, true));
            // images
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 373, 688, _content.Load<Texture2D>("picture's\\settingslogbackground")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 70, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbuttonselect")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 135, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 200, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 265, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            // text
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", 16, 70, 342, 45));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", 16, 135, 342, 45));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", 16, 200, 342, 45));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", 16, 265, 342, 45));

            // settings menu with save game selected
            Texture_groups.Add("settings_menu_save_game_selected", new Texture_group(1061, 71, false));
            // images
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 373, 688, _content.Load<Texture2D>("picture's\\settingslogbackground")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 70, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 135, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbuttonselect")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 200, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 265, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            // text
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", 16, 70, 342, 45));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", 16, 135, 342, 45));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", 16, 200, 342, 45));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", 16, 265, 342, 45));

            // settings menu with load game selected
            Texture_groups.Add("settings_menu_load_game_selected", new Texture_group(1061, 71, false));
            // images
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 373, 688, _content.Load<Texture2D>("picture's\\settingslogbackground")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 70, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 135, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 200, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbuttonselect")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 265, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            // text
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", 16, 70, 342, 45));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", 16, 135, 342, 45));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", 16, 200, 342, 45));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", 16, 265, 342, 45));

            // settings menu with exit game selected
            Texture_groups.Add("settings_menu_exit_game_selected", new Texture_group(1061, 71, false));
            // images
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 373, 688, _content.Load<Texture2D>("picture's\\settingslogbackground")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 70, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 135, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 200, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbutton")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 265, 342, 45, _content.Load<Texture2D>("picture's\\settingslogbuttonselect")));
            // text
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", 16, 70, 342, 45));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", 16, 135, 342, 45));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", 16, 200, 342, 45));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", 16, 265, 342, 45));


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

        public override void update(Texture_screen_information texture_screen_information)
        {
            update_selected_button(texture_screen_information.Selected_button);

            update_growth_stage(texture_screen_information.Growth_stage);
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
                Texture_groups["settings_menu_save_game_selected"].Is_visible = true;
                Texture_groups["settings_menu_load_game_selected"].Is_visible = false;
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

