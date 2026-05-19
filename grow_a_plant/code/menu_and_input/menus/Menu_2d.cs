using grow_a_plant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
     public abstract class Menu_2d : Menu
    {
        // the index of the options are determined from up to down and then left to right. So like this:
        //  0   3   6   
        //  1   4   7
        //  2   5   8

        private int _height;

        public Menu_2d(Menu_command_package[] options, int height) : base(options)
        {
            _height = height;
        }

        override public void step_right()
        {
            _selected_option_index += _height;

            nudge_selected_option_index_inside_of_indexes();
        }

        override public void step_left()
        {
            _selected_option_index -= _height;

            nudge_selected_option_index_inside_of_indexes();
        }
    }
}
