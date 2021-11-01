using System;
using System.Threading;

namespace rpg_game
{
    class Program
    {
        static void Main(string[] args)
        {
            print("My world that is hell");
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
