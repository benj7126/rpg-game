using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace rpg_game.Game_Classes
{
    class Travel
    {
        public bool doneTraveling = false;
        public float travelLeft = 0;
        public float travelTotal = 0;
        public Location destination = null;
        private int size = 50;

        public void run(ref Player plr, Location dest)
        {
            Console.Clear();
            Console.WriteLine("Traveling to " + dest.name + ".");
            Console.WriteLine("");
            destination = dest;
            travelTotal = Vector.distance(destination.pos, plr.pos);
            travelLeft = travelTotal;
            int lastPrint = -1;
            while (doneTraveling == false)
            {
                bool doWrite = false;
                Thread.Sleep(100);
                travelLeft -= 1;


                float p = Math.Abs(travelLeft/travelTotal-1)* size;
                string str = "[";

                //Console.WriteLine(p);

                for (int i = 0; i< size; i++)
                {
                    if (p >= i)
                    {
                        str += "#";
                        if (i > lastPrint)
                        {
                            lastPrint = i;
                            doWrite = true;
                        }
                    }
                    else
                    {
                        str += " ";
                    }
                }

                str += "]";
                if (doWrite)
                {
                    Console.CursorTop = Console.CursorTop - 1;
                    int tempInt = (int)MathF.Floor((MathF.Abs(travelLeft / travelTotal-1)*100));
                    tempInt = Math.Max(Math.Min(tempInt, 100), 0);
                    Console.WriteLine(str + " " + tempInt.ToString() + "/100");
                }


                if (travelLeft <= 0)
                {
                    Console.CursorTop = Console.CursorTop - 1;
                    int tempInt = (int)MathF.Floor((MathF.Abs(travelLeft / travelTotal - 1) * 100));
                    tempInt = Math.Max(Math.Min(tempInt, 100), 0);
                    Console.WriteLine(str + " " + tempInt.ToString() + "/100");
                    doneTraveling = true;

                    plr.pos = dest.pos;
                    plr.playerLocation = dest;
                }
            }
        }
    }
}
