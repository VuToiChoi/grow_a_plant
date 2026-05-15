using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
     public abstract class Menu
    {
        // options available in the menu, selected option index, step up, step down, step right, step left

        protected Menu_command_package[] _options;

        protected int _selected_option_index;

        public Menu(Menu_command_package[] options)
        {
            _options = options;
            _selected_option_index = 0;
        }

        virtual public void step_up()
        {
            _selected_option_index--;

            nudge_selected_option_index_inside_of_indexes();

        }

        virtual public void step_down()
        {
            _selected_option_index++;

            nudge_selected_option_index_inside_of_indexes();
        }

        virtual public void step_right()
        {
        }

        virtual public void step_left()
        {
        }

        public Menu_command_package get_selected_option()
        {
            return _options[_selected_option_index];
        }

        protected void nudge_selected_option_index_inside_of_indexes() // is used to ensure that the option is in the range of the options. If the index is less than 0, it will wrap around to the end of the options. If the index is greater than the number of options, it will wrap around to the beginning of the options.    
        {
            int mod = ((_selected_option_index % _options.Length) + _options.Length) % _options.Length;

            _selected_option_index = mod;
        }
    }
}
