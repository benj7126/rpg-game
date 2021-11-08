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

                ConsoleKey ck = Console.ReadKey(true).Key;
                if (player.up == ck)
                {
                    selected = Math.Max(0, selected - 1);
                }
                else if (player.down == ck)
                {
                    selected = Math.Min(optionsCount - 1, selected + 1);
                }
                else if (player.select == ck)
                {
                    done = true;
                }

                if (!done)
                    Console.CursorTop = Console.CursorTop - optionsCount;
            }
            return selected;
        }
    }
}
