using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;
using rpg_game.Game_Classes.maze;
using rpg_game.Game_Classes.maze.math;

namespace rpg_game
{
    class Program
    {
        public static GameWorldController game;

        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            //Martins Labyrint
            // int[] mapArr = {
            //     1, 1, 1, 1, 1, 1, 1, 1, 1,
            //     1, 3, 1, 0, 0, 0, 0, 0, 1,
            //     1, 0, 1, 0, 1, 0, 1, 0, 1,
            //     1, 0, 0, 0, 1, 0, 1, 0, 1,
            //     1, 0, 1, 1, 1, 0, 1, 0, 1,
            //     1, 0, 0, 0, 1, 0, 1, 1, 1,
            //     1, 1, 1, 0, 1, 0, 0, 0, 1,
            //     1, 0, 1, 0, 1, 0, 1, 0, 1,
            //     1, 0, 0, 0, 1, 0, 1, 2, 1,
            //     1, 1, 1, 1, 1, 1, 1, 1, 1,
            // };

            // The following is used to test the maze, without actually walking
            // to it.

            // int[] mapArr = {
            //     1, 1,   1,   1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            //     1, 1,   0,   0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1,
            //     1, 1,   0,   1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1,
            //     1, 102, 100, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 101,
            //     1, 1,   0,   0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1,
            //     1, 1,   0,   0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1,
            //     1, 1,   1,   1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            // };
            // Map map = new Map(29, 7, mapArr);

            // Maze.StartMaze(map);
          
            gameStart();
        }
        public static void gameStart()
        {
            Console.Clear();
            print("Booting up Hellcrawler", ms: 200);
            game = new GameWorldController();
            bool runing = false;
            while (!runing)
            {
                runing = game.updateWorld();
            }
        }
        public static void clearKeys()
        {
            if (Console.KeyAvailable)
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey();
                }
            }
        }

        public static void sleep(int ms)
        {
            Thread.Sleep((int)MathF.Floor(ms*Player.textSpeedMulti));
        }

        public static void print(string str, int ms = 50, int delay = 0, int maxCharLen = 80, bool withNLine = true, string name = "", bool raw = false)
        {
            // B - making a print function to make story telling easier (hopefully)
            if (name != "") // B - if theres someone talking you can define their name and it will be added to the wraping of text
            {
                Console.Write("[" + name + "]: ");
                sleep(150);
            }

            Dictionary<int, int> delays = otherConvert(str);
            if (!raw)
            {
                str = convertToLen(str, maxCharLen, startVal: name.Length + 3); // B - wrap text

                // int index, int wait time
                str = deleteTimestamp(str);
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (delays.ContainsKey(i))
                    sleep(delays[i]);
                Console.Write(str[i]);
                sleep(ms);

                while (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == Player.select)
                    {
                        ms = 0;
                    }
                }
            }

            Console.CursorLeft = Console.CursorLeft - 1;
            if (withNLine)
                Console.Write("\n");
            sleep(delay);

            clearKeys();
        }

        public static Dictionary<int, int> otherConvert(string str)
        {
            Dictionary<int, int> delays = new Dictionary<int, int>();

            int wordNr = 0;
            string nString = "";

            string[] nStr = str.Split(" ");
            foreach (string word in nStr)
            {
                if (word.Length >= 3)
                {
                    if (word.Substring(0, 2) == "ms" || word.Substring(1, 2) == "ms")
                    {
                        int ms = Int32.Parse(word.Substring(0, 2) == "ms" ? word.Substring(2, word.Length - 2) : word.Substring(3, word.Length - 3));
                        delays.Add(nString.Length, ms);
                    }
                    else
                    {
                        nString += word + " ";
                        wordNr++;
                    }
                }
                else
                {
                    nString += word + " ";
                    wordNr++;
                }
            }

            return delays;
        }

        public static string deleteTimestamp(string str)
        {
            string[] nStr = str.Split(" ");
            string nString = "";

            foreach (string word in nStr)
            {
                if (word.Length >= 3)
                {
                    if (word.Substring(0, 2) != "ms" && word.Substring(1, 2) != "ms")
                    {
                        nString += word + " ";
                    }
                    if (word.Substring(1, 2) == "ms")
                    {
                        nString += "\n";
                    }
                }
                else
                {
                    nString += word + " ";
                }
            }

            str = nString;
            return str;
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
