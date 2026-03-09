using System.Collections.Generic;

namespace grow_a_plant
{
    internal class Text_handler
    {

        private string _current_text;


        public enum action
        {
            water,
            fertilize,
            log,
            save_game,
            load_game,

        }

        public Text_handler()
        {
            _current_text = "";
        }


        public action update(action action)
        {
            if (action == action.water) { _current_text = "plants been watered."; }
            else if (action == action.fertilize) { _current_text = "plants been fertilized."; }
            else if (action == action.log) { _current_text = "logbook opened."; }
            else if (action == action.save_game) { _current_text = "The game is saved."; }
            else if (action == action.load_game) { _current_text = "The game is loaded."; }
        }



    }
}

