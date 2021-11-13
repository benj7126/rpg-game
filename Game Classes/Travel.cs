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
        private int size = 100;

        public void run(ref Player plr, Location dest)
        {
            Console.Clear();
            Console.WriteLine("");
            destination = dest;
            travelTotal = Vector.distance(destination.pos, plr.pos);
            travelLeft = travelTotal;
            int lastPrint = -1;
            while (doneTraveling == false)
            {
                bool doWrite = false;
                Thread.Sleep(10);
                travelLeft -= 0.2f;
                plr.pos.moveTowards(destination.pos, 0.2f);

                List<procentNMonsters> encounterList = new List<procentNMonsters>();

                foreach (MonsterArea ma in MonsterArea.areas)
                {
                    if (Vector.distance(ma.pos, plr.pos) < ma.radius)
                    {
                        foreach (int mid in ma.enemies)
                        {
                            encounterList.Add(new procentNMonsters(ma.encounterRate + (encounterList.Count == 0 ? 0 : encounterList[encounterList.Count - 1].chance), mid));
                        }
                    }
                }

                // do travel stuff
                Random r = new Random();
                float rNR = (float)r.Next(0, 10000) / 10000;
                foreach (procentNMonsters procentNMonsters in encounterList)
                {
                    if (procentNMonsters.chance > rNR)
                    {
                        Program.print("While wandering the planes of hell you encounter a demon.");
                        Program.print("The demon seems hungry, well, for you that is.");
                        Fight.StartFight(ref plr, Enemy.getById(procentNMonsters.enemyId));
                        Program.sleep(500);
                        Console.Clear();
                        break;
                    }
                }

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
                    Console.CursorTop = 0;
                    Console.WriteLine("Traveling to " + dest.name + ".");
                    int tempInt = (int)MathF.Floor((MathF.Abs(travelLeft / travelTotal-1)*100));
                    tempInt = Math.Max(Math.Min(tempInt, 100), 0);
                    Console.WriteLine(str + " " + tempInt.ToString() + "/100%");
                }


                if (travelLeft <= 0)
                {
                    Console.CursorTop = 0;
                    Console.WriteLine("Traveling to " + dest.name + ".");
                    Console.WriteLine(str + " 100/100%");
                    doneTraveling = true;

                    plr.pos = dest.pos;
                    dest.enterLocation(ref plr, ref dest);
                }
            }
        }
    }

    class procentNMonsters
    {
        public int enemyId;
        public float chance;
        public procentNMonsters(float c, int id)
        {
            chance = c;
            enemyId = id;
        }
    }
}
