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
                new Tutorial_slide("Welcome to Grow a Plant!\n\nIn this game you navigate through menus with the WASD buttons\nor with the arrow buttons. When you have navigated to the correct\nbutton you press z to select it.\n\nTry it out:"),
                new Tutorial_slide("Your goal is to take care of a plant.\n\nYou therefore have to water and fertilize it. After a while it might grow\ninto another growth level.\n\nKeep in mind though: watering and fertilizing the plant too much or too\nlittle won't do. If you want your plant to be at its best you have do it just\nperfectly."),
                new Tutorial_slide("The water and fertilize level is visible in two bars on the left.\n\nDepending on the weather outside the water could be\ndepleeted slower or quicker. The fertilize level depleetes\nwhen the plant grows.\n\nYour starter plant thrives at a medium water level and a\nmedium fertilize level."),
                new Tutorial_slide("Even though the game is exited the plant will still grow. So\nyou have to enter the game from time to time just to make \nsure it is doing okay.\n\nThe game saves automaticalley when exited. So no need to\nworry about that (even though those buttons exist in the settings).")
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
            if (current_slide_index < 0) // sets the current_slide_index to zero if becomes smaller than zero
            {
                current_slide_index = 0;
            }
            else if (current_slide_index >= _tutorial_slides.Count) // sets the current slide index to the last slide if it is bigger than the amount of slides
            {
                current_slide_index = _tutorial_slides.Count - 1;
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
