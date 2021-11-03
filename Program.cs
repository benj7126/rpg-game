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
            GameWorldController game = new GameWorldController();
            while (true)
            {
                game.updateWorld();
            }
        }

        public static void print(string str, int ms = 50, bool stringSplit = false)
        {
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
        }
    }
}
