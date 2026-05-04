using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class User_interface_interface
    {
        User_interface_handler _user_interface_handler;

        Start_texture_screen _start_texture_screen;

        Settings_texture_screen _settings_texture_screen;

        public User_interface_interface(SpriteBatch sprite_batch, SpriteFont sprite_font, GraphicsDevice graphics_device, ContentManager content)
        {
            _start_texture_screen = new Start_texture_screen(graphics_device, content);
            _settings_texture_screen = new Settings_texture_screen(graphics_device, content);

            User_interface_handler _user_interface_handler = new User_interface_handler(_start_texture_screen, sprite_batch, sprite_font);
        }

        public void change_to_start_texture_screen()
        {
            _user_interface_handler.change_texture_screen(_start_texture_screen);
        }

        public void change_to_settings_texture_screen()
        {
            _user_interface_handler.change_texture_screen(_settings_texture_screen);
        }

        public void update(Texture_screen_information texture_screen_information)
        {
            _user_interface_handler.update(texture_screen_information);
        }

        public void draw()
        {
            _user_interface_handler.draw();
        }
    }
}
