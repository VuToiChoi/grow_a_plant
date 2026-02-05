using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    public abstract class Menu_1d : Menu
    {
        public Menu_1d(string[] options) : base(options)
        {
            _options = options;
        }

        override public void step_right()
        {
            step_down();
        }

        override public void step_left()
        {
            step_up();
        }
    }
}
