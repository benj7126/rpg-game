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
            print("adjsalk jdakajdakldjasdkasjdklasj ddsjj j j jj jjd jka jsld jsd kjlk jllkjadkldajsdda sdas dasd asd as das dasd asd asd");
            //Game_Scenes.Beginning scene = new Game_Scenes.Beginning();
            //scene.Start();
            //Fight.update();
            //GameWorldController game = new GameWorldController();
            while (true)
            {
                //game.updateWorld();
            }
        }

        public static void print(string str, int ms = 50, bool stringSplit = false, int delay = 0, int maxCharLen = 80, bool withNLine = true)
        {
            string[] nStr = str.Split(" ");
            int totalNR = 0;
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

            str = nString;

            if (stringSplit)
            {
                nStr = str.Split(" ");
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
    }
}
