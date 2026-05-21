using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant.code.user_interface.texture_screen
{
    public class Tutorial_slide_handler
    {
        private List<Tutorial_slide> _tutorial_slides;

        public int current_slide_index { get; private set; }

        public Tutorial_slide_handler()
        {
            _tutorial_slides = new List<Tutorial_slide>
            {
                new Tutorial_slide("Welcome to Grow a Plant!\nIn this game, you navigate through menus with the WASD buttons or with the arrow buttons. When you have navigated to the correct button you press z to select it.\n\nTry it out:"),
                new Tutorial_slide("Your goal is to take care of a plant. You therefore have to water and fertilize it. After a while it might grow into another growth level.\nKeep in mind though, watering and fertilizing the plant too much or too little won't do. You have do it just perfectly."),
                new Tutorial_slide("The water and fertilize level is visible in two bars to the left. Depending on the weather outside, the water could be depleeted slower or quicker. The fertilize level depleetes when the plant grows."),
                new Tutorial_slide("Even though the game is exited, the plant will still grow. So you have to enter the game from time to time just to make sure it is doing okay.\n\nThe game saves automaticalley when exited. So no need to worry about that (even though those buttons exist in the settings).")
            };

            current_slide_index = 0;
        }

        public void next_slide()
        {
            current_slide_index++;

            nudge_current_slide_index_into_valid_value();
        }

        public void previous_slide()
        {
            current_slide_index--;

            nudge_current_slide_index_into_valid_value();
        }

        private void nudge_current_slide_index_into_valid_value()
        {
            if (current_slide_index < 0) // sets the current slide index to the last slide if it is smaller than 0
            {
                current_slide_index = _tutorial_slides.Count - 1;
            }
            else if (current_slide_index >= _tutorial_slides.Count) // sets the current slide index to the first slide if it is bigger than the amount of slides
            {
                current_slide_index = 0;
            }
        }

        public string get_current_slide_information_text()
        {
            return _tutorial_slides[current_slide_index].Information_text;
        }

        public int get_total_amount_of_slides()
        {
            return _tutorial_slides.Count;
        }
    }
}
