namespace grow_a_plant
{
    class Information_text_updater
    {
        public void update(Text_rectangle text_rectangle, Button_command_package button_command_package)
        {
            Button_command_package.command_type command = button_command_package.Command;

            if (command == Button_command_package.command_type.water)
            {
                text_rectangle.Text = "plant has been watered.";
            }
            else if (command == Button_command_package.command_type.fertilize)
            {
                text_rectangle.Text = "plant has been fertilized.";
            }
            else if (command == Button_command_package.command_type.log)
            {
                text_rectangle.Text = "logbook opened.";
            }
            else if (command == Button_command_package.command_type.save_game)
            {
                text_rectangle.Text = "the game is saved.";
            }
            else if (command == Button_command_package.command_type.load_game)
            {
                text_rectangle.Text = "the game is loaded.";
            }
        }
    }
}

