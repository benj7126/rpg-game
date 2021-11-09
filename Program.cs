using System;
using System.Threading;
using rpg_game;
using rpg_game.Game_Classes;

namespace rpg_game
{
    class Program   
    {
        static void Main(string[] args)
        {
            rpg_game.Game_Classes.maze.Maze.Start();
            Console.CursorVisible = false;
            Fight.update();
            GameWorldController game = new GameWorldController();
            while (true)
            {
                game.updateWorld();
            }
        }

        public static void print(string str, int ms = 50, bool stringSplit = false, int delay = 0, int maxCharLen = 80, bool withNLine = true, string name = "")
        {
            if (name != "")
            {
                Console.Write("[" + name + "]: ");
                Thread.Sleep(150);
            }

            str = convertToLen(str, maxCharLen, startVal: name.Length+2);

            if (stringSplit)
            {
                string[] nStr = str.Split(" ");
                for (int i = 0; i < nStr.Length-1; i++)
                {
                    Console.Write(nStr[i]);
                    Console.Write(" ");
                    Thread.Sleep(ms);
                }
                Console.Write(nStr[nStr.Length-1]);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(str[i]);
                    Thread.Sleep(ms);
                }
            }
            if (withNLine)
                Console.Write("\n");
            Thread.Sleep(delay);
        }
        public static string convertToLen(string str, int maxCharLen, int startVal = 0)
        {
            string[] nStr = str.Split(" ");
            int totalNR = startVal;
            string nString = "";

            foreach (string word in nStr)
            {
                if (totalNR + word.Length > maxCharLen)
                {
                    nString = nString + "\n";
                    totalNR = 0;
                }

                nString = nString + word + " ";
                totalNR = totalNR + word.Length;
            }

            return nString;
        }
    }
}
