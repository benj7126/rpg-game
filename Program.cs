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

            gameStart(); // start game
        }
        public static void gameStart() // run to start game (also restart when you die)
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
        public static void clearKeys() // clears keys
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
            // making a print function to make story telling easier (hopefully)
            if (name != "") // if theres someone talking you can define their name and it will be added to the wraping of text
            {
                Console.Write("[" + name + "]: ");
                sleep(150);
            }

            Dictionary<int, int> delays = otherConvert(str); // mak a dictionary of all the waiting points in the string
            if (!raw)
            {
                str = convertToLen(str, maxCharLen, startVal: name.Length + 3); // wrap text

                str = deleteTimestamp(str); // delete all msXXX in the string
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (delays.ContainsKey(i)) // sleep if you are at a wait point
                    sleep(delays[i]);
                Console.Write(str[i]);
                sleep(ms);

                while (Console.KeyAvailable) // clear all keys
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

        public static Dictionary<int, int> otherConvert(string str) // this goes thru all words removes msXXX and ads them to a dictionary of the char index or something.
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

        public static string deleteTimestamp(string str) // Delete all the ms thingys from the text
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

        public static string convertToLen(string str, int maxCharLen, int startVal = 0) // takes a string and makes sure it wraps
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
