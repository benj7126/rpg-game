using System;
using System.Collections.Generic;
using System.Text;
using rpg_game.Game_Classes.Dungeon;

namespace rpg_game.Game_Classes
{
    class DungeonCrawler
    {
        Player plr;
        int layer;
        int dLength;
        int dir = 0; // 0: up, 1: left, 2: down, 3: right
        Dictionary<int, Vector> converter = new Dictionary<int, Vector>();
        Vector plrPosInDung = new Vector(0, 0);
        bool ongoing = true;

        int[,] actualDungeon;

        public DungeonCrawler(ref Player p, int l)
        {
            Random r = new Random();
            plr = p;
            layer = l;
            dLength = Math.Max(layer, 3);


            actualDungeon = new int[dLength, dLength];

            for (int x = 0; x < dLength; x++)
            {
                for (int y = 0; y < dLength; y++)
                {
                    actualDungeon[x, y] = r.Next(2, senario.senarioList.Count);
                }
            }
            converter.Add(0, new Vector(0, 1));
            converter.Add(1, new Vector(1, 0));
            converter.Add(2, new Vector(0, -1));
            converter.Add(3, new Vector(-1, 0));
        }

        public void gameLoop()
        {
            Program.print("While walking into this tower, you get the feeling of regret, you turn around ms300 the exit is gone.");
            Program.print("It's do or die now, you tell yourself.");
            Program.print("Entering dungeon level "+layer);

            while (ongoing)
            {
                ChoiceSelector CS = new ChoiceSelector();
                int Choice = CS.update(ref plr, new List<string>() {"Look forward", "Turn left", "Turn right", "Manage inventory"}, "What to do now?");

                Console.WriteLine(Choice);

                int x;
                int y;

                switch (Choice)
                {
                    case 0:

                        x = (int)plrPosInDung.x + (int)converter[dir].x;
                        y = (int)plrPosInDung.y + (int)converter[dir].y;
                        if (isNotWall(new Vector(x, y)))
                        {
                            senario.senarioList[actualDungeon[x, y]].onLook(ref plr, layer);
                            proced(new Vector(x, y));
                        }
                        else
                        {
                            Program.print("aaand, thats a wall");
                        }
                        break;
                    case 1:
                        dir = turn(dir, -1);
                        break;
                    case 2:
                        dir = turn(dir, 1);
                        break;
                    case 3:
                        InvScreen invS = new InvScreen();
                        invS.inv(ref plr);
                        Console.Clear();
                        break;
                }
            }
        }
        private bool isNotWall(Vector pos)
        {
            return pos.x > -1 && pos.x < dLength && pos.y > -1 && pos.y < dLength;
        }

        private bool proced(Vector pos)
        {
            ChoiceSelector CS = new ChoiceSelector();
            int Choice = CS.update(ref plr, new List<string>() { "Yes", "No" }, "Do you wish to proceed?");
            if (Choice == 0)
            {
                plrPosInDung = pos;
                int back = senario.senarioList[actualDungeon[(int)plrPosInDung.x, (int)plrPosInDung.y]].onEnter(ref plr, layer);
                if (back == 0)
                    actualDungeon[(int)plrPosInDung.x, (int)plrPosInDung.y] = 0;
                else if (back == 1)
                    ongoing = false;
                return true;
            }
            return false;
        }

        private int turn(int orig, int turnWith)
        {
            orig += turnWith;
            if (orig == 4)
                orig = 0;
            if (orig == -1)
                orig = 3;
            return orig;
        }
    }
}
