using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes
{
    class ChoiceSelector
    {
        public List<string> options = new List<string>();
        public int optionSelected = 0;
        public int update(ref Player player, ref gameStates gameState, List<string> allOptions, string preText="")
        {
            options = allOptions;
            int optionsCount = options.Count;

            int selected = 0;

            bool done = false;

            rpg_game.Program.print(preText);
            while (!done)
            {
                for (int i = 0; i < optionsCount; i++)
                {
                    if (selected == i)
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

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(optionsCount - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                }

                if (!done)
                    Console.CursorTop = Console.CursorTop - optionsCount;
            }
            return selected;
        }
    }
}
