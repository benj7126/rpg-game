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
            Fight.update();
            GameWorldController game = new GameWorldController();
            while (true)
            {
                game.updateWorld();
            }
        }

        public static void print(string str, int ms = 50, bool stringSplit = false, int delay = 0, int maxCharLen = 80)
        {
            string nString = "";
            bool addNLine = true;
            while (addNLine)
            {
                if (str.Length >= maxCharLen)
                {
                    nString += str.Substring(0, maxCharLen) + "\n";
                    str = str.Substring(maxCharLen, str.Length - maxCharLen);
                }
                else
                {
                    nString += str.Substring(0, str.Length);
                    addNLine = false;
                }
            }

            str = nString;

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
            Console.Write("\n");
            Thread.Sleep(delay);
        }
    }
}
