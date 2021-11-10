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


            //rpg_game.Game_Classes.maze.Maze.Start();
            Console.CursorVisible = false;
            //Fight.update();
            GameWorldController game = new GameWorldController();
            while (true)
            {
                game.updateWorld();
            }
        }

        public static void sleep(int ms)
        {
            Thread.Sleep((int)MathF.Floor(ms*Player.textSpeedMulti));
        }

        public static void print(string str, int ms = 50, bool stringSplit = false, int delay = 0, int maxCharLen = 80, bool withNLine = true, string name = "")
        {
            // B - making a print function to make story telling easier (hopefully)
            if (name != "") // B - if theres someone talking you can define their name and it will be added to the wraping of text
            {
                Console.Write("[" + name + "]: ");
                sleep(150);
            }

            str = convertToLen(str, maxCharLen, startVal: name.Length+3); // B - wrap text

            if (stringSplit) // B - if it should write it word for word or if it should be char for char
            {
                string[] nStr = str.Split(" ");
                for (int i = 0; i < nStr.Length-1; i++)
                {
                    Console.Write(nStr[i]);
                    Console.Write(" ");
                    sleep(ms);
                }
                Console.Write(nStr[nStr.Length-1]);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(str[i]);
                    sleep(ms);
                }
            }
            if (withNLine)
                Console.CursorLeft = Console.CursorLeft - 1;
                Console.Write("\n");
            sleep(delay);
        }
        public static string convertToLen(string str, int maxCharLen, int startVal = 0) // B - takes a string and makes sure it wraps
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
