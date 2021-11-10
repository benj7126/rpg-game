using System;
using System.Threading;
using System.Collections.Generic;
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
                print("asdasdd ms1000 aasda... well time ms520 is a time and ms100 time is wastin ms30 asdasdd ms1000 aasda... well time ms520 is a time and ms100 time is wastin ms30 asdasdd ms1000 aasda... well time ms520 is a time and ms100 time is wastin ms30");
                game.updateWorld();
            }
        }

        public static void sleep(int ms)
        {
            Thread.Sleep((int)MathF.Floor(ms*Player.textSpeedMulti));
        }

        public static void print(string str, int ms = 50, int delay = 0, int maxCharLen = 80, bool withNLine = true, string name = "")
        {
            // B - making a print function to make story telling easier (hopefully)
            if (name != "") // B - if theres someone talking you can define their name and it will be added to the wraping of text
            {
                Console.Write("[" + name + "]: ");
                sleep(150);
            }

            str = convertToLen(str, maxCharLen, startVal: name.Length+3); // B - wrap text

            // int index, int wait time
            Dictionary<int, int> delays = otherConvert(str);
            str = deleteTimestamp(str);

            for (int i = 0; i < str.Length; i++)
            {
                if (delays.ContainsKey(i))
                    sleep(delays[i]);
                Console.Write(str[i]);
                sleep(ms);
            }

            Console.CursorLeft = Console.CursorLeft - 1;
            if (withNLine)
                Console.Write("\n");
            sleep(delay);
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
