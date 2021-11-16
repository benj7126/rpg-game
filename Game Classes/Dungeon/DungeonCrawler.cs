using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes
{
    class DungeonCrawler
    {
        Player plr;
        int layer;

        int[,] actualDungeon;

        public DungeonCrawler(ref Player p, int l)
        {
            actualDungeon = new int[Math.Max(l, 3), Math.Max(l, 3)];
            plr = p;
            layer = l;
        }
    }
}
