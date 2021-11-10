using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes
{
    class ChoiceSelector
    {
        public List<string> options = new List<string>();
        public int optionSelected = 0;
        public int update(ref Player player, List<string> allOptions, string preText="")
        {
            options = allOptions; // B - all the options that you can chose from
            int optionsCount = options.Count;

            int selected = 0;

            bool done = false;

            rpg_game.Program.print(preText);
            while (!done) // B - loops until you make a choice
            {
                for (int i = 0; i < optionsCount; i++)
                {
                    if (selected == i) // B - writes an arrow and sets the color of the line to indicate if its selcted or not
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.WriteLine(options[i]);

                    Console.ResetColor();
                }

                ConsoleKey ck = Console.ReadKey(true).Key; // B - wait for the next key and do stuff based on what was pressed
                if (Player.up == ck)
                {
                    selected = Math.Max(0, selected - 1);
                }
                else if (Player.down == ck)
                {
                    selected = Math.Min(optionsCount - 1, selected + 1);
                }
                else if (Player.select == ck)
                {
                    done = true;
                }

                if (!done) // B - if its not done you need to repeat (its a while loop). so it moves the cursor up so that it can overwrite it and make it look good
                    Console.CursorTop = Console.CursorTop - optionsCount;
            }
            return selected;
        }
    }
}
