using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Start_texture_screen : Texture_screen
    {
        public Start_texture_screen(GraphicsDevice graphics_device) : base(graphics_device) 
        {
            // in the fututre, this should probably be done by some config files or something 

            int screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            // background
            Texture_groups.Add("background", new Texture_group(0, 0, true));
            Texture_groups["background"].Image_rectangles.Add(new Image_rectangle(0, 0, screen_width, screen_height, Texture2D.FromFile(graphics_device, "Content/pictures/background.png")));

            // start menu when the water button is selected
            Texture_groups.Add("menu_water_selected", new Texture_group(0, 0, true));
            Texture_groups["menu_water_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/pictures/background.png")));
            Texture_groups["menu_water_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubuttonselect.png")));
            Texture_groups["menu_water_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_water_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_water_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));

            // start menu when the fertilize button is selected
            Texture_groups.Add("menu_fertilize_selected", new Texture_group(0, 0, false));
            Texture_groups["menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/pictures/background.png")));
            Texture_groups["menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubuttonselect.png")));
            Texture_groups["menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_fertilize_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));

            // start menu when the log button is selected
            Texture_groups.Add("menu_log_selected", new Texture_group(0, 0, false));
            Texture_groups["menu_log_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/pictures/background.png")));
            Texture_groups["menu_log_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_log_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_log_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubuttonselect.png")));
            Texture_groups["menu_log_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));

            // start menu when the settings menu is selected 
            Texture_groups.Add("menu_settings_selected", new Texture_group(0, 0, false));
            Texture_groups["menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(0, 0, 1440, 241, Texture2D.FromFile(graphics_device, "Content/pictures/background.png")));
            Texture_groups["menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(812, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(1109, 41, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(812, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubutton.png")));
            Texture_groups["menu_settings_selected"].Image_rectangles.Add(new Image_rectangle(1109, 136, 266, 69, Texture2D.FromFile(graphics_device, "Content/pictures/startmenubuttonselect.png")));


        }
    }
}
