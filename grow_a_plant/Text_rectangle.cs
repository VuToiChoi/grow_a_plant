using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grow_a_plant
{
    class Text_rectangle
    {
        public string Text {  get; set; }

        public int X_postition { get; private set; }

        public int Y_postition { get; private set; }

        public Text_rectangle(string text, int x_postition, int y_postition)
        {
            Text = text;
            X_postition = x_postition;
            Y_postition = y_postition;
        }
    }
}
