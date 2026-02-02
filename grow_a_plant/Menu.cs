using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    abstract class Menu
    {
        // options available in the menu, selected option index, step up, step down, step right, step left

        protected string[] _options;

        protected int _selected_option_index;

        public Menu(string[] options)
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

        public string get_selected_option()
        {
            return _options[_selected_option_index];
        }

        protected void nudge_selected_option_index_inside_of_indexes()
        {
            int mod = ((_selected_option_index % _options.Length) + _options.Length) % _options.Length;

            _selected_option_index = mod;
        }
    }
}
