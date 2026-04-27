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
        public Settings_texture_screen(GraphicsDevice graphics_device) : base(graphics_device)
        {
            int _screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int _screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;


            // in the future this would be done in a better way, probably with a json file or something, but for now this is fine
            // the _screen_width and _screen_height could be implemented in the future



            // background
            Texture_groups.Add("background", new Texture_group(0, 0, true));
            Texture_groups["background"].Image_rectangles.Add(new Image_rectangle(0, 0, _screen_width, _screen_height, Texture2D.FromFile(graphics_device, "Content/picture's/backdrop.png")));


            // start menu
            Texture_groups.Add("start_menu", new Texture_group(0, 783, true));
            // images
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/picture's/background.png")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            Texture_groups["start_menu"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/picture's/startmenubutton.png")));
            // text
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("settings opened.", 0, 0));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Water", 812, 41));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Fertilize", 812, 41));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Log", 812, 41));
            Texture_groups["start_menu"].Text_rectangles.Add(new Text_rectangle("Settings", 812, 41));


            //settings menus

            // settings menu with return to game selected
            Texture_groups.Add("settings_menu_return_to_game_selected", new Texture_group(1061, 71, true));
            // images
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 373, 688, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbackground.png")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 70, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbuttonselected.png")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 135, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 200, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_return_to_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 265, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            // text
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", 16, 70));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", 16, 135));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", 16, 200));
            Texture_groups["settings_menu_return_to_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", 16, 265));

            // settings menu with save game selected
            Texture_groups.Add("settings_menu_save_game_selected", new Texture_group(1061, 71, false));
            // images
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 373, 688, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbackground.png")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 70, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 135, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbuttonselected.png")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 200, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_save_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 265, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            // text
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", 16, 70));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", 16, 135));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", 16, 200));
            Texture_groups["settings_menu_save_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", 16, 265));

            // settings menu with load game selected
            Texture_groups.Add("settings_menu_load_game_selected", new Texture_group(1061, 71, false));
            // images
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 373, 688, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbackground.png")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 70, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 135, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 200, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbuttonselected.png")));
            Texture_groups["settings_menu_load_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 265, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            // text
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", 16, 70));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", 16, 135));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", 16, 200));
            Texture_groups["settings_menu_load_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", 16, 265));

            // settings menu with exit game selected
            Texture_groups.Add("settings_menu_exit_game_selected", new Texture_group(1061, 71, false));
            // images
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 373, 688, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbackground.png")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 70, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 135, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 200, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbutton.png")));
            Texture_groups["settings_menu_exit_game_selected"].Image_rectangles.Add(new Image_rectangle(16, 265, 342, 45, Texture2D.FromFile(graphics_device, "Content/picture's/settingslogbuttonselected.png")));
            // text
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Return to Game", 16, 70));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Save Game", 16, 135));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Load Game", 16, 200));
            Texture_groups["settings_menu_exit_game_selected"].Text_rectangles.Add(new Text_rectangle("Exit Game", 16, 265));
        }
    }
}
