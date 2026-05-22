using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant.code.user_interface.texture_screen
{
    class Tutorial_texture_screen : Texture_screen
    {
        private Tutorial_slide_handler _tutorial_slide_handler;

        public Tutorial_texture_screen(GraphicsDevice graphics_device, ContentManager content) : base(graphics_device, content)
        {
            _tutorial_slide_handler = new Tutorial_slide_handler();

            int _screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int _screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            // background
            Texture_groups.Add("background", new Texture_group(0, 0, true));
            Texture_groups["background"].Image_rectangles.Add(new Image_rectangle(0, 0, _screen_width, (int)(_screen_height), _content.Load<Texture2D>("picture's\\tutorialbackground")));

            // text
            Texture_groups.Add("text", new Texture_group(0, 0, true));
            Texture_groups["text"].Text_rectangles.Add(new Text_rectangle("Tutorial", (int)(_screen_width * 0.410), (int)(_screen_height * 0.070), (int)(_screen_width * 0.180), (int)(_screen_height * 0.120)));
            Texture_groups["text"].Text_rectangles.Add(new Text_rectangle("", (int)(_screen_width * 0.100), (int)(_screen_height * 0.190), (int)(_screen_width * 0.800), (int)(_screen_height * 0.450)));


            // slide counter
            Texture_groups.Add("slide_counter", new Texture_group(0, 0, true));
            Texture_groups["slide_counter"].Text_rectangles.Add(new Text_rectangle("", (int)(_screen_width * 0.907), (int)(_screen_height * 0.650), (int)(_screen_width * 0.120), (int)(_screen_height * 0.075)));
            update_slide_counter();


            // menu
            int menu_width = _screen_width;
            int menu_height = (int)(_screen_height * 0.234);

            //  next tutorial slide button selected
            Texture_groups.Add("menu_previous_tutorial_slide_selected", new Texture_group(0, (int)(_screen_height * 0.766), true));
            // images
            Texture_groups["menu_previous_tutorial_slide_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.080), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            Texture_groups["menu_previous_tutorial_slide_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.378), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["menu_previous_tutorial_slide_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.677), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["menu_previous_tutorial_slide_selected"].Text_rectangles.Add(new Text_rectangle("previous slide", (int)(menu_width * 0.110), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));
            Texture_groups["menu_previous_tutorial_slide_selected"].Text_rectangles.Add(new Text_rectangle("next slide", (int)(menu_width * 0.440), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));
            Texture_groups["menu_previous_tutorial_slide_selected"].Text_rectangles.Add(new Text_rectangle("just let me play!", (int)(menu_width * 0.700), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));

            //  next tutorial slide button selected
            Texture_groups.Add("menu_next_tutorial_slide_selected", new Texture_group(0, (int)(_screen_height * 0.766), true));
            // images
            Texture_groups["menu_next_tutorial_slide_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.080), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["menu_next_tutorial_slide_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.378), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            Texture_groups["menu_next_tutorial_slide_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.677), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            // text
            Texture_groups["menu_next_tutorial_slide_selected"].Text_rectangles.Add(new Text_rectangle("previous slide", (int)(menu_width * 0.110), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));
            Texture_groups["menu_next_tutorial_slide_selected"].Text_rectangles.Add(new Text_rectangle("next slide", (int)(menu_width * 0.440), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));
            Texture_groups["menu_next_tutorial_slide_selected"].Text_rectangles.Add(new Text_rectangle("just let me play!", (int)(menu_width * 0.700), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));

            //  exit tutorial button selected
            Texture_groups.Add("menu_exit_tutorial_selected", new Texture_group(0, (int)(_screen_height * 0.766), true));
            // images
            Texture_groups["menu_exit_tutorial_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.080), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["menu_exit_tutorial_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.378), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebutton")));
            Texture_groups["menu_exit_tutorial_selected"].Image_rectangles.Add(new Image_rectangle((int)(menu_width * 0.677), (int)(menu_height * 0.290), (int)(menu_width * 0.243), (int)(menu_height * 0.418), _content.Load<Texture2D>("picture's\\startmenuebuttonselect")));
            // text
            Texture_groups["menu_exit_tutorial_selected"].Text_rectangles.Add(new Text_rectangle("previous slide", (int)(menu_width * 0.110), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));
            Texture_groups["menu_exit_tutorial_selected"].Text_rectangles.Add(new Text_rectangle("next slide", (int)(menu_width * 0.440), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));
            Texture_groups["menu_exit_tutorial_selected"].Text_rectangles.Add(new Text_rectangle("just let me play!", (int)(menu_width * 0.700), (int)(menu_height * 0.370), (int)(menu_width * 0.450), (int)(menu_height * 0.250)));

            update_information_text();
        }

        public override void update(Texture_screen_information texture_screen_information)
        {
            update_selected_button(texture_screen_information.Selected_button);

            if (texture_screen_information.Button_is_pressed)
            {
                update_slides(texture_screen_information.Selected_button);
            }
        }

        private void update_selected_button(Button_command_package selected_button_command_package)
        {
            if (selected_button_command_package.Command == Button_command_package.command_type.previous_tutorial_slide)
            {
                Texture_groups["menu_previous_tutorial_slide_selected"].Is_visible = true;
                Texture_groups["menu_next_tutorial_slide_selected"].Is_visible = false;
                Texture_groups["menu_exit_tutorial_selected"].Is_visible = false;
            }
            else if (selected_button_command_package.Command == Button_command_package.command_type.next_tutorial_slide)
            {
                Texture_groups["menu_previous_tutorial_slide_selected"].Is_visible = false;
                Texture_groups["menu_next_tutorial_slide_selected"].Is_visible = true;
                Texture_groups["menu_exit_tutorial_selected"].Is_visible = false;
            }
            else if (selected_button_command_package.Command == Button_command_package.command_type.exit_tutorial)
            {
                Texture_groups["menu_previous_tutorial_slide_selected"].Is_visible = false;
                Texture_groups["menu_next_tutorial_slide_selected"].Is_visible = false;
                Texture_groups["menu_exit_tutorial_selected"].Is_visible = true;
            }
        }

        private void update_slides(Button_command_package pressed_button_command_package)
        {
            if (pressed_button_command_package.Command == Button_command_package.command_type.previous_tutorial_slide)
            {
                _tutorial_slide_handler.previous_slide();
                update_slide_counter();
                update_information_text();
            }
            else if (pressed_button_command_package.Command == Button_command_package.command_type.next_tutorial_slide)
            {
                _tutorial_slide_handler.next_slide();
                update_slide_counter();
                update_information_text();
            }
        }

        private void update_slide_counter()
        {
            Texture_groups["slide_counter"].Text_rectangles[0].Text = $"{_tutorial_slide_handler.current_slide_index + 1}/{_tutorial_slide_handler.get_total_amount_of_slides()}";
        }

        private void update_information_text()
        {
            Texture_groups["text"].Text_rectangles[1].Text = _tutorial_slide_handler.get_current_slide_information_text();
        }
    }
}
