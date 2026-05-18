using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D11;
namespace grow_a_plant
{
    class User_interface_drawer
    {
        private SpriteBatch _sprite_batch;

        private SpriteFont _sprite_font;

        public User_interface_drawer(SpriteBatch sprite_batch, SpriteFont sprite_font)
        {
            _sprite_batch = sprite_batch;
            _sprite_font = sprite_font;
        }

        public void draw(int relative_x_origin, int relative_y_origin, Image_rectangle image_rectangle) // the position of a Image_rectangle does not have to be relative to the origin of the screen. The y and x relative origins are therfore used to set this orgin. For an Image_rectangle in a Texture_group, this would be the position of the texture_group.
        {
            Rectangle rectangle_to_draw_image_onto = get_rectangle_to_draw_image_onto(relative_x_origin, relative_y_origin, image_rectangle);

            _sprite_batch.Begin();

            _sprite_batch.Draw(image_rectangle.Image, rectangle_to_draw_image_onto, Color.White);

            _sprite_batch.End();
        }

        private Rectangle get_rectangle_to_draw_image_onto(int relative_x_origin, int relative_y_origin, Image_rectangle image_rectangle) // the position of a Image_rectangle does not have to be relative to the origin of the screen. The y and x relative origins are therfore used to set this orgin. For an Image_rectangle in a Texture_group, this would be the position of the texture_group.
        {
            return new Rectangle(relative_x_origin + image_rectangle.X_position, relative_y_origin + image_rectangle.Y_position, image_rectangle.Width, image_rectangle.Height);
        }

        public void draw(int relative_x_origin, int relative_y_origin, Text_rectangle text_rectangle) // the position of a Image_rectangle does not have to be relative to the origin of the screen. The y and x relative origins are therfore used to set this orgin. For an Image_rectangle in a Texture_group, this would be the position of the texture_group.
        {
            float scale = get_scale_of_text_to_fit_text_rectangle(text_rectangle);

            _sprite_batch.Begin();

            _sprite_batch.DrawString(_sprite_font, text_rectangle.Text, new Vector2(relative_x_origin + text_rectangle.X_postition,relative_y_origin + text_rectangle.Y_postition), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            
            _sprite_batch.End();
        }

        private float get_scale_of_text_to_fit_text_rectangle(Text_rectangle text_rectangle)
        {
            Vector2 text_size = _sprite_font.MeasureString(text_rectangle.Text);

            float width_scale = text_rectangle.Width / text_size.X;
            float height_scale = text_rectangle.Height / text_size.Y;
            float scale = Math.Min(width_scale, height_scale); // get the smaller scale to maintain ratio of the font

            return scale;
        }
    }
}
